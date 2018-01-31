using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using practiceNet.Models;
using practiceNet.ViewModels;

namespace practiceNet.Controllers
{
    public class MoviesController : Controller
    {

        public ActionResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }


        //
        // GET: /Movies/Random

        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Sherk!" };
            

            //ViewData["Movie"] = movie;
            //ViewBag.RandomMovie = movie;


            //******* modo de enviar viewmodel ***************
            //var viewResult = new ViewResult();

            var customers = new List<Customer>
            {
                new Customer { Name= "Customer 1"},
                new Customer { Name= "Customer 2"},
                new Customer { Name= "Customer 3"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);

            //*************************************************

            
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

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";


        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}

        //{month:regex(\\d{4})}
        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + " / " + month);
        }


        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Sherk"},
                new Movie { Id = 1, Name = "Wall-e"}
            };
        }
    }
}