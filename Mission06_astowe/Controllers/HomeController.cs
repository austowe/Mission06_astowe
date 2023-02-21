﻿using Microsoft.AspNetCore.Mvc;
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
            movieContext.Add(nm);
            movieContext.SaveChanges();
            return View("Confirmation", nm);
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

    }
}
