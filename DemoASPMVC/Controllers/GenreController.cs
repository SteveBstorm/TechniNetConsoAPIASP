using DemoASPMVC.Models;
using DemoASPMVC.Tools;
using DemoASPMVC_DAL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DemoASPMVC.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        public IActionResult Index()
        {
            return View(_genreService.GetAll());
        }

        [AdminRequired]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GenreForm f)
        {
            _genreService.Add(f.Label);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return RedirectToAction("Index","Game", new { id });
        }
    }
}
