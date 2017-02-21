using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult Random()
		{
			Movie m = new Movie() { Name = "Gladiator", Studio = "Miramax" };

			//return Content(m.Name);
			//return HttpNotFound();
			//return new EmptyResult();
			return RedirectToAction("About","Home",new { age=23,name="David" });
		}

		public ActionResult Edit(int? id,string name)
		{
			return Content(String.Format("Id = {0}, Name = {1}", id,name));
		}



	}
}