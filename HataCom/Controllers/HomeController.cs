using BusinessLogic.BusinessLogicMethods;
using BusinessLogic.Contexts;
using BusinessLogic.DbInitialize;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HataCom.Controllers
{
	public class HomeController : Controller
	{

		PhotoAlbumsMethods photoAlbums = new PhotoAlbumsMethods();
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			var test = photoAlbums.GetPhotoAlbums();
			ViewBag.Message = "Your application description page.";
			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";
			return View();
		}

		public ActionResult Music()
		{
			
			return View();
		}

	}
}