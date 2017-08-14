using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using VideoRental.Models;
using VideoRental.ViewModels;

namespace VideoRental.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Titanic 2"};

            var viewModel = new RandomViewModel
            {
                Movie = movie,
                Customers = new List<Customer>
                {
                    new Customer{CustomerId = 1, Name = "Pankaj"},
                    new Customer{CustomerId = 2, Name = "Vashishta"},
                }
            };

            return View(viewModel);

            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new{test = "Test"});
        }

        public ActionResult Edit(int MovieId)
        {
            return Content("MovieId : " + MovieId);
        }

        public ActionResult Show(int? pageNumber, string sortBy)
        {
            if (!pageNumber.HasValue)
                pageNumber = 1;

            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content($"pageNumber : {pageNumber} & SortBy : {sortBy}");
        }

        public ActionResult ReleasedByDate(int year, int month)
        {
            return Content($"Convetion based routing : {year}/{month}");
        }

        [Route("movies/releasedByYear/{year:regex(\\d{4})}/{month:regex(\\d{2})}")]
        public ActionResult ReleasedByDateA(int year, int month)
        {
            return Content($"Attribute base routiung : {year}/{month}");
        }
    }
}