
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Vidly2.Models;
using System.Data.Entity;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
{
    public class MoviesController : Controller
    {


        private MyDBContext _context;

        public MoviesController()
        {
            _context = new MyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // For executing raw queries 
        public ViewResult get()
        {
            //Ex for reading data 
            using (var db = new MyDBContext())
            {
                var movies = db.Movies.SqlQuery("Select * from Movies").ToList();

                return View(movies);
            }
            
        }
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Titanic" };


            var customers = new List<Customer>
            {
                new Customer {Name = "Joseph" },
                new Customer {Name = "Eric"}
            };

            var viewModel = new RandomViewModel()
            {

                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

          
            return View(movies);
        }

        [HttpGet]
        public ActionResult New()
        {
            /* var genres = _context.Genres.ToList();*/
            return View("MovieForm");
        }


        // Lect 11

        public ActionResult Details(int? id)
        {
            var movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

        

            // Here we return the movie and the genre together 
            return View(movies);

        }
        public ActionResult Index2(int? pageNumber, string sortBy)
        {
            if (pageNumber.HasValue)
            {
                pageNumber = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageNumber={0}&sortBy={1}", pageNumber, sortBy));
        }

        //L12
        [Route("movies/released/{years}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}