using BusinessLogic.Contexts;
using BusinessLogic.DbInitialize;
using BusinessLogic.Models;
using HataCom.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HataCom.Repositories
{
    public class PhotoRepository : IRepository<Photo>
    {
		private HataContext db = new HataContext();

		DbInitializer dbInitializer = new DbInitializer();//ініціалізатор для уникання міграцій (dropAndCreateDB) - створення екземплеяра класа

		public Photo Get(int id)
		{
			return db.Photos.Find(id);
		}

		public IEnumerable<Photo> GetAll()
		{
			return db.Photos;
		}

		public IEnumerable<Photo> GetPhotosByAlbumId(int albumId)
		{
			var photos = db.Photos.Where(e => e.PhotoAlbumId == albumId);
			return photos;
		}

		public bool Remove(int id)
		{
			Photo photo = db.Photos.Find(id);
			try
			{
				db.Photos.Remove(photo);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool Add(Photo entity)
		{
			try
			{
				db.Photos.Add(entity);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool Update(Photo enitity)
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

		private bool disposed = false;
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					db.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}