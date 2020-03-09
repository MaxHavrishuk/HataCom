using BusinessLogic.Contexts;
using BusinessLogic.DbInitialize;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessLogicMethods
{
	public class PhotoAlbumsMethods
	{
		HataContext hataDb = new HataContext();

		DbInitializer dbInitializer = new DbInitializer();//ініціалізатор для уникання міграцій (dropAndCreateDB)
		public IEnumerable<PhotoAlbum> GetPhotoAlbums()
		{
			dbInitializer.InitializeDatabase(hataDb);//ініціалізатор для уникання міграцій (dropAndCreateDB)
			IEnumerable<PhotoAlbum> photoAlbums = hataDb.PhotoAlbums;
			return photoAlbums;
		}
	}
}
