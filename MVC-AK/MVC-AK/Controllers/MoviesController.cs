using Microsoft.AspNetCore.Mvc;
using MVC_AK.Models;
using MVC_AK.ViewModels;

namespace MVC_AK.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieDbContext _dbContext;

        private List<Customer> customers = new List<Customer>
        {
                new Customer() { Name="Anthony"},
                new Customer() { Name="Arran"},
                new Customer() { Name="Tim"}
        };

        public MoviesController(MovieDbContext context)
        {
            _dbContext = context;
        }

        public IActionResult All(string name)
        {

            //add tolower
            var movies = new List<string>();

            _dbContext.Movies.ToList().ForEach(movie =>
            {
                if (String.IsNullOrEmpty(name))
                {
                    movies.Add(movie.mName);
                } else
                {
                    if (movie.mName.Contains(name))
                    {
                        movies.Add(movie.mName);
                    }
                }
            });

            var viewModel = new MoviesViewModel();
            viewModel.mNames = movies;

            return View(viewModel);
        }

        public List<string> Get(string name)
        {
            var found = new List<string>();

            _dbContext.Movies.ToList().ForEach(x =>
            {
                if (x.mName.Contains(name))
                {
                    found.Add(x.mName);
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
