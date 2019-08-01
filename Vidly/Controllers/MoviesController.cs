using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller

    {
        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            var viewModel = new ViewModels.MovieViewModel()
            {
                Genres = genre
            };
            return View("MovieForm",viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ViewModels.MovieViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else {
                var moviesInDb = _context.Movies.Single(c => c.Id == movie.Id);
                moviesInDb.Name = movie.Name;
                moviesInDb.GenreID = movie.GenreID;
                moviesInDb.DateAdded = movie.DateAdded;
                moviesInDb.ReleaseDate = movie.ReleaseDate;
                moviesInDb.NoOfStocks = movie.NoOfStocks;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Index()
        {
           if(User.IsInRole(RoleName.CanManageMovies))
             return View("List");
            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id) {
            var movies = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movies == null)
                return HttpNotFound();
            var viewModel = new ViewModels.MovieViewModel(movies)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Shreik" };
        //    //var customers = new List<Customer> {
        //    //    new Customer{ Name="Customer1"},
        //    //    new Customer { Name="Customer2"}

        //    //};
        //    var viewModel = new ViewModels.RandomMovieViewModel
        //    {
        //        Movie = movie,
        //       // Customers = customers
        //    };
        //    return View(viewModel);
        //}
      

        public ActionResult Details(int? id) {
            var movies = _context.Movies.Include(c => c.GenreType).SingleOrDefault(c => c.Id == id);
            if (movies == null)
                return HttpNotFound();
            return View(movies);
        }

      
       // [Route("movies/released/{year}/{month}")]
     /*   public ActionResult ByReleaseDate(int year, int month) {
            return Content(year + "/" + month);*/

         
    }
}