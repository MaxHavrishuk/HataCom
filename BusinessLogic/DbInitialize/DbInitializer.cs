using BusinessLogic.Contexts;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace BusinessLogic.DbInitialize
{
	public class DbInitializer : DropCreateDatabaseAlways<HataContext>
	{
		protected override void Seed(HataContext context)
		{
			//іконки для альбому
			//var albumICo1 = HostingEnvironment.MapPath(@"../Content/img/TestAlbum/1.jpg"); //віртуальний шлях до корню проекта
			var albumICo1 = StaticConstants.PathsToContent.PhotosPath + "1.jpg"; //віртуальний шлях до корню проекта
			var albumICo2 = StaticConstants.PathsToContent.PhotosPath + "2.jpg"; //віртуальний шлях до корню проекта

			string testDesription = @"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it.";

			//Самі фото для альбому 1
			List<Photo> photos = new List<Photo>();

			for (int i = 0; i < 5; i++)
			{
				photos.Add(new Photo()
				{
					ImageLink = StaticConstants.PathsToContent.PhotosPath + "1.jpg",
					Title = "Test",
					UserId = 1
				});
			}


			context.PhotoAlbums.Add(new PhotoAlbum() { Title = "Test1", UserId = 1, Photos = photos, IconLink = albumICo1, Description= testDesription });
			//context.Photos.AddRange(new List<Photo>(photos));


			//Самі фото для альбому 2

			List<Photo> photos1 = new List<Photo>();
			for (int i = 0; i < 5; i++)
			{
				photos1.Add(new Photo()
				{
					ImageLink = StaticConstants.PathsToContent.PhotosPath + "2.jpg",
					Title = "Test",
					UserId = 1
				});
			}

			context.PhotoAlbums.Add(new PhotoAlbum() { Title = "Test2", UserId = 1, Photos = photos1, IconLink = albumICo2, Description = testDesription });
			//context.Photos.AddRange(new List<Photo>(photos1));



			//context.Photos.Add(new Photo() { ImageLink = "/Content/img/TestAlbum/2.jpg", Title = "Test", UserId = 1,  });

			context.SaveChanges();
			base.Seed(context);
		}
	}
}
