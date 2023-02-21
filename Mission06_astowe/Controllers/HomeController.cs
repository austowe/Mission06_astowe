using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private MovieContext movieContext { get; set; }
        //constructor
        public HomeController(MovieContext mc)
        {
            movieContext = mc;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(NewMovie nm)
        {
            if (ModelState.IsValid)
            {
                movieContext.Add(nm);
                movieContext.SaveChanges();
                return View("Confirmation", nm);
            }

            else
            {
                ViewBag.Categories = movieContext.Categories.ToList();

                return View();
            }
            
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            var movies = movieContext.movies
                .Include(x => x.Category)
                .OrderBy(x => x.Year)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            var movie = movieContext.movies.Single(x => x.MovieId == movieid);

            return View("AddMovie", movie);
        }

        [HttpPost]
        public IActionResult Edit(NewMovie nm)
        {
            movieContext.Update(nm);
            movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = movieContext.movies.Single(x => x.MovieId == movieid);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(NewMovie nm)
        {
            movieContext.movies.Remove(nm);
            movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

    }
}
