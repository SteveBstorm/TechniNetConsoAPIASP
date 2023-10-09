using DemoASPMVC.Models.ViewModel;
using DemoASPMVC.Tools;
using DemoASPMVC_DAL.Interface;
using DemoASPMVC_DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DemoASPMVC.Controllers
{
    public class UserController : Controller
    {
        
        private readonly IUserService _userService;
        private readonly SessionManager _session;

        public UserController(IUserService userService, SessionManager session)
        {
            _userService = userService;
            _session = session;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterForm u)
        {
            if (!ModelState.IsValid)
            {
                return View(u);
            }

            if (_userService.Register(u.Email, u.Password, u.Nickname))
            {
                return RedirectToAction("Index", "Game");
            }

            return View();

        }

        public IActionResult Login()
        {
            ViewData["toto"] = DateTime.Now;
            TempData["bidule"] = "jean maurice";
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginForm u)
        {
            try
            {
                string token = _userService.Login(u.Email, u.Password);
                JwtSecurityToken jwt = new JwtSecurityToken(token);
                int id = int.Parse(jwt.Claims.First(x => x.Type == ClaimTypes.Sid).Value);
                User connectedUser = _userService.GetById(id);
                _session.Token = token;
                _session.ConnectedUser = connectedUser;
                return RedirectToAction("Index", "Game");

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public IActionResult Logout()
        {
            _session.Logout();
            return RedirectToAction("Index", "Game");
        }

        public IActionResult GetById(int id)
        {
            return Ok(_userService.GetById(id));
        }

        [AdminRequired]
        public IActionResult AllUser()
        {
            return View(_userService.GetUsers(_session.Token));
        }

        [AdminRequired]
        public IActionResult SetRole(int id)
        {
            if (_userService.SetRole(id, 3, _session.Token))
            {
                return RedirectToAction("AllUser");
            }
            else
            {
                return View();
            }
        }
    }
}
