
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
{
    public class MoviesController : Controller
    {




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


        // Lect 11

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