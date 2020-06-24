using BusinessLogic;
using BusinessLogic.BusinessLogicMethods;
using BusinessLogic.Contexts;
using BusinessLogic.DbInitialize;
using BusinessLogic.Models;
using BusinessLogic.Models.ViewModels;
using BusinessLogic.StaticConstants;
using HataCom.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace HataCom.Controllers
{
	public class HomeController : Controller
	{
		PhotoAlbumsRepository photoAlbums = new PhotoAlbumsRepository();
		PhotoRepository photos = new PhotoRepository();
		public ActionResult Index()
		{
			return View();
		}

		//Test begin


		public ActionResult PhotoAlbum()
		{
			AddAlbumView addAlbumView = new AddAlbumView();

			addAlbumView.PhotoAlbums = photoAlbums.GetAll();

			return View(addAlbumView);
		}

		[HttpGet]
		public ActionResult Photos(int Id)
		{
			var test = photos.GetPhotosByAlbumId(Id);

			return View(test);
		}

		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Upload(AddAlbumView model)
		{
			
			if (ModelState.IsValid)
			{

				//Потрібно зробити перевірку на формати!!! можливо покращити перевірку на наявність файлів
				//Вдосконалити перевірку на те чи обрана обложка
			
					List<Photo> photos = new List<Photo>();
					int c = 0;
					foreach (var file in model.Files)
					{
						string fileName = Path.GetFileName(file.FileName);
						var finalName = Guid.NewGuid() + file.ContentType.Replace('/', '.');
						string link = Server.MapPath(PathsToContent.PhotosPath + finalName);
						file.SaveAs(link);
						photos.Add(new Photo() { ImageLink = PathsToContent.PhotosPath + finalName, Title = model.PhotoAlbum.Photos[c].Title, IsCover = model.PhotoAlbum.Photos[c].IsCover });
						c++;
					}
					//photos[0].IsCover = true;//!!!!!!!!!!!!!!!!!!!!!!!!!!

					model.PhotoAlbum.Photos = photos;
					photoAlbums.AddWithPhotos(model.PhotoAlbum);
				
				
			}
			//Фізичне завнатаження файлі на сервер

			return RedirectToAction("PhotoAlbum");
		}
		//if (upload != null)
		//{
		//	// получаем имя файла
		//	string fileName = System.IO.Path.GetFileName(upload.FileName);
		//	// сохраняем файл в папку Files в проекте
		//	upload.SaveAs(Server.MapPath("~/Content/testFiles/" + fileName));

		//}
		//return View("PhotoAlbum");
		//return RedirectToAction("Index");

		//Test end

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

		public ActionResult Music()
		{
			return View();
		}

	}
}