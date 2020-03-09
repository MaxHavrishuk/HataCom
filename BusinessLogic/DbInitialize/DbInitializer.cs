using BusinessLogic.Contexts;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DbInitialize
{
	public class DbInitializer : DropCreateDatabaseAlways<HataContext>
	{
		protected override void Seed(HataContext context)
		{
			List<Photo> photos = new List<Photo>();
			for (int i = 0; i < 25; i++)
			{
				photos.Add(new Photo()
				{
					ImageLink = "/Content/img/TestAlbum/2.jpg",
					Title = "Test",
					UserId = 1
				});
			}
			
			context.PhotoAlbums.Add(new PhotoAlbum() { Title = "Test", UserId = 1, Photos = photos });
			//context.Photos.AddRange(new List<Photo>(photos));

			List<Photo> photos1 = new List<Photo>();
			for (int i = 0; i < 25; i++)
			{
				photos1.Add(new Photo()
				{
					ImageLink = "/Content/img/TestAlbum/2.jpg",
					Title = "Test",
					UserId = 1
				});
			}

			context.PhotoAlbums.Add(new PhotoAlbum() { Title = "Test", UserId = 1, Photos = photos1 });
			//context.Photos.AddRange(new List<Photo>(photos1));



			//context.Photos.Add(new Photo() { ImageLink = "/Content/img/TestAlbum/2.jpg", Title = "Test", UserId = 1,  });

			context.SaveChanges();
			base.Seed(context);
		}
	}
}
