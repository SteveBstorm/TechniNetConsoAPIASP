using DemoASPMVC.Models;
using DemoASPMVC_DAL.Interface;
using DemoASPMVC.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DemoASPMVC.Models.ViewModel;

namespace DemoASPMVC.Controllers
{
    public class GameController : Controller
    {
        //Injection de l'instance du service via le constructeur du controller
        //GameService gameService { get; set; }
        
        private readonly IGameService gameService;
        private readonly IGenreService _genreService;
        private readonly SessionManager _sessionManager;
        public GameController(IGameService gs, IGenreService genreService, SessionManager sessionManager)
        {
            gameService = gs;
            _genreService = genreService;
            _sessionManager = sessionManager;
        }
        public IActionResult Index(int id = 0)
        {
            if(id == 0)
                return View(gameService.GetGames().Select(g => g.ToASP()));
            return View(gameService.GetGames().Where(g => g.IdGenre == id).Select(g => g.ToASP()));
        }

        public IActionResult Details(int id)
        {
            Game g = gameService.GetById(id).ToASP();
            //g.Genre = _genreService.GetById(g.IdGenre).Label;
            return View(g);
        }

        [CustomAuthorize]
        public IActionResult Create()
        {
            GameForm game = new GameForm();
            game.GenreList = _genreService.GetAll();
            return View(game);
        }

        [HttpPost]
        public IActionResult Create(GameForm g)
        {
            gameService.Create(g.ToDal(), _sessionManager.Token);
            return RedirectToAction("Index");
        }
        [AdminRequired]
        public IActionResult Delete(int id)
        {
            //scoped => on garde l'instance durant tout le traitement de l'action Delete
            //Game game = gameService.GetById(id);
            gameService.Delete(id);
            return RedirectToAction("Index");

            //Transient => on crée une nouvelle instance, à chaque fois que le service est appelé
        }

        [CustomAuthorize]
        public IActionResult AddFavorite(int id)
        {
            try
            {
                gameService.AddFavorite(_sessionManager.ConnectedUser.Id, id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [CustomAuthorize]
        public IActionResult ViewFavorite()
        {
            return View(gameService.GetByUserId(_sessionManager.ConnectedUser.Id, _sessionManager.Token).Select(x => x.ToASP()));
        }
    }
}
