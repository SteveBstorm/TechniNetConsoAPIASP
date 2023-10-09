using DemoASPMVC.Models;
using DemoASPMVC_DAL.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoASPMVC.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        

        public IActionResult Index()
        {
            return View();
        }

     
        public IActionResult Privacy()
        {
            List<string> maliste = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                maliste.Add(Guid.NewGuid().ToString());
            }
            return View(maliste);
        }

        public IActionResult Test()
        {
            Client c = new Client();
            c.Id = 1;
            c.Firstname = "Arthur";
            c.Lastname = "Bidule";
            return View(c);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult NotFound()
        {
            return View();
        }
    }
}