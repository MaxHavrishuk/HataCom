using BusinessLogic.Contexts;
using BusinessLogic.DbInitialize;
using BusinessLogic.Models;
using BusinessLogic.StaticConstants;
using HataCom.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLogic.BusinessLogicMethods
{
	public class PhotoAlbumsRepository : IRepository<PhotoAlbum>
	{
		private HataContext db = new HataContext();

		DbInitializer dbInitializer = new DbInitializer();//ініціалізатор для уникання міграцій (dropAndCreateDB) - створення екземплеяра класа

		public PhotoAlbum Get(int id)
		{
			return db.PhotoAlbums.Find(id);
		}

		public IEnumerable<PhotoAlbum> GetAll()
		{

			return db.PhotoAlbums;
		}

		public bool Remove(int id)
		{
			PhotoAlbum album = db.PhotoAlbums.Find(id);
			try
			{
				db.PhotoAlbums.Remove(album);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool Add(PhotoAlbum entity)
		{
			try
			{
				db.PhotoAlbums.Add(entity);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool AddWithPhotos(PhotoAlbum entity)
		{
			try
			{
				//Перевірка чи є в списку фото з відміткою про обложку, якщо ні то обрати перше фото
				//db.PhotoAlbums.Add(entity).IconLink = photos.Where(e => e.IsCover == 1).FirstOrDefault().ImageLink;
				if (entity.Photos.Any(e=>e.IsCover == true))
				{
					entity.IconLink = entity.Photos.Where(e => e.IsCover == true).FirstOrDefault().ImageLink;
					db.PhotoAlbums.Add(entity);
					db.SaveChanges();
				}
				else
				{
					entity.IconLink = entity.Photos.First().ImageLink;
					db.PhotoAlbums.Add(entity);
					db.SaveChanges();
				}
				
			


				//foreach (var photo in photos)
				//{
				//	db.Photos.Add(new Photo() { PhotoAlbumId = entity.PhotoAlbumId, Title = photo.Title, ImageLink = photo.ImageLink });
				//	db.SaveChanges();
				//}

				return true;
			}
			catch (Exception e)
			{
				var tets = e.Message;
				return false;
			}
		}



		////перевантажений метод додавання з файлами!!!!
		//public bool Add(PhotoAlbum entity, IEnumerable<HttpPostedFileBase> files)
		//{
		//	try
		//	{
		//		db.PhotoAlbums.Add(entity);

		//		return true;
		//	}
		//	catch (Exception)
		//	{
		//		return false;
		//	}
		//}


		public bool Update(PhotoAlbum enitity)
		{
			try
			{
				db.Entry(enitity).State = EntityState.Modified;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public void Save()
		{
			db.SaveChanges();
		}

		//private bool disposed = false;
		//protected virtual void Dispose(bool disposing)
		//{
		//	if (!this.disposed)
		//	{
		//		if (disposing)
		//		{
		//			db.Dispose();
		//		}
		//	}
		//	this.disposed = true;
		//}

		//public void Dispose()
		//{
		//	Dispose(true);
		//	GC.SuppressFinalize(this);
		//}

	}
}
