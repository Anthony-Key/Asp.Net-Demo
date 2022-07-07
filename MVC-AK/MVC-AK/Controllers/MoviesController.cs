using Microsoft.AspNetCore.Mvc;
using MVC_AK.Models;
using MVC_AK.ViewModels;

namespace MVC_AK.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Random()
        {
            var movie = new Movie() { mName = "bob" };

            var customers = new List<Customer>
            {
                new Customer() { Name="Customer 1"},
                new Customer() { Name="Customer 2"},
                new Customer() { Name="Customer 3"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            //return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "name";
            }

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
