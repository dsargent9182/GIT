using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index(int? pageIndex, string sortBy)
        {
			if(!pageIndex.HasValue)
			{
				pageIndex = 1;
			}

			if(String.IsNullOrWhiteSpace(sortBy))
			{
				sortBy = "Name";
			}
			return Content(String.Format("pageIndex={0}&sortBy={1}",pageIndex,sortBy));
        }
		//[Route("movie/released/{year}/{month:regex(\\d{4}:range(1,12))}")]
		public ActionResult ByReleaseDate(int year,int? month)
		{
			return Content(String.Format("<h2>{0} - {1}</h2>",month,year));
		}

		public ActionResult Random()
		{
			Movie m = new Movie() { Name = "Ghostbusters" };
			List<Customer> lstCustomers = new List<Customer>();
			//{
			//	new Customer {Id = 1, Name = "David" },
			//	new Customer {Id = 2, Name = "Eric" }
			//};

			RandomMovieViewModel vm = new RandomMovieViewModel()
			{
				Customers = lstCustomers,
				Movie = m
			};

			return View(vm);
		}

    }
}