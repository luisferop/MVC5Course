using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Web.Models;
using Vidly.Web.ViewModels;

namespace Vidly.Web.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View(GetMovies());
        }
        [Route("Movies/Details/{id:int}")]
        public ActionResult Details(int id)
        {
            Movie movie = GetMovies().Where(x => x.Id.Equals(1)).FirstOrDefault();
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        public ActionResult MovieForm()
        {
            var genres = _context.Genres.ToList();
            MovieFormViewModel viewModel = new MovieFormViewModel()
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MovieFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var genres = _context.Genres.ToList();
                MovieFormViewModel viewModel = new MovieFormViewModel()
                {
                    Genres = genres,
                    Movie = model.Movie
                };
                return View("MovieForm", viewModel);
            }
            if (model.Movie.Id.Equals(0))
            {
                model.Movie.AddedDate = DateTime.Now;
                _context.Movie.Add(model.Movie);
            }
            else
            {
                Movie movieInDB = GetMovies().Where(x => x.Id.Equals(model.Movie.Id)).Single();
                
                movieInDB.GenreId = model.Movie.GenreId;
                movieInDB.Name = model.Movie.Name;
                movieInDB.NumberInStock = model.Movie.NumberInStock;
                movieInDB.ReleaseDate = model.Movie.ReleaseDate;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Edit(int id)
        {
            Movie movie = GetMovies().Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (movie == null)
            {
                return HttpNotFound();
            }
            var genres = _context.Genres.ToList();
            MovieFormViewModel viewModel = new MovieFormViewModel()
            {
                Genres = genres,
                Movie = movie
            };
            return View("MovieForm", viewModel);
        }
        private IEnumerable<Movie> GetMovies()
        {
            return _context.Movie.Include("Genre");
        }

        //// GET: Movies
        //public ActionResult Random()
        //{
        //    Movie movie = new Movie() {
        //        Name = "Shrek!"
        //    };
        //    List<Customer> customers = new List<Customer>()
        //    {
        //        new Customer(){Name = "Customer 1" },
        //        new Customer(){ Name = "Customer 2"}
        //    };
        //    RandomMovieCustomersViewModel viewModel = new RandomMovieCustomersViewModel()
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };
        //    return View(viewModel);
        //    //return Content("Oi Luis");
        //}
        //[Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content($"Year {year} / Month {month}");
        //}
    }
}