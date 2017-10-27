using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using practiceNet.Models;

namespace practiceNet.Controllers
{
    public class MoviesController : Controller
    {
        //
        // GET: /Movies/Random

        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Sherk!" };
            ViewData["Movie"] = movie;
            ViewBag.a = movie;
            return View();
            //return Content("HELLO WORLD");
            //return HttpNotFound();
            //return RedirectToAction("Index", "Home");
        }

        [Route("movies/edit/{movieId?}")]
        public ActionResult Edit(string movieId)
        {
            if (String.IsNullOrEmpty(movieId))
            {
                return Content("id -> No hay");
            }
            return Content("id -> " + movieId);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";


            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + " / " + month);
        }
    }
}