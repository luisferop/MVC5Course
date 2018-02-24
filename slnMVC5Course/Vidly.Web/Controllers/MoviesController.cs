using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Web.Constants;
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
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            return View("ReadOnlyList");
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
        [Authorize(Roles =(RoleName.CanManageMovies))]
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
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.AddedDate = DateTime.Now;
                _context.Movie.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movie.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
        [Authorize(Roles = (RoleName.CanManageMovies))]
        public ActionResult Edit(int id)
        {
            Movie movie = GetMovies().Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (movie == null)
            {
                return HttpNotFound();
            }
            var genres = _context.Genres.ToList();
            MovieFormViewModel viewModel = new MovieFormViewModel(movie)
            {
                Genres = genres
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