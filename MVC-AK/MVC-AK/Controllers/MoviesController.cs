using Microsoft.AspNetCore.Mvc;
using MVC_AK.Models;
using MVC_AK.ViewModels;

namespace MVC_AK.Controllers
{
    public class MoviesController : Controller
    {
        private List<Customer> customers = new List<Customer>
        {
                new Customer() { Name="Anthony"},
                new Customer() { Name="Arran"},
                new Customer() { Name="Tim"}
        };

        public IActionResult All()
        {
            var movie = new Movie() { mName = "Shrek The Third" };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public List<string> Get(string name)
        {
            var found = new List<string>();

            customers.ForEach(x =>
            {
                if (x.Name.Contains(name))
                {
                    found.Add(x.Name);
                }
            });

            return found;
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
