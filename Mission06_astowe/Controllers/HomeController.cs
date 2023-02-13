using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission06_astowe.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_astowe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext movieContext { get; set; }
        //constructor
        public HomeController(ILogger<HomeController> logger, MovieContext mc)
        {
            _logger = logger;
            movieContext = mc;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(NewMovie nm)
        {
            movieContext.Add(nm);
            movieContext.SaveChanges();
            return View("Confirmation", nm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
