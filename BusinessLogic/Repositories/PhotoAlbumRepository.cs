using BusinessLogic.Contexts;
using HataCom.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BusinessLogic.Repositories
{
    public class PhotoAlbumRepository : IRepository<PhotoAlbum>
    {
        HataContext db = new HataContext();
        public bool Add(PhotoAlbum entity)
        {
            if (db.PhotoAlbums.Where(e=>e.PhotoAlbumId == entity.PhotoAlbumId).Any())
            {
                return false;
            }
            else
            {
                db.PhotoAlbums.Add(entity);
                db.SaveChanges();
                return true;
            }
           
        }

        public PhotoAlbum Get(int id)
        {
            return db.PhotoAlbums.Find(id);
        }

        public IEnumerable<PhotoAlbum> GetAll()
        {
            return db.PhotoAlbums;
        }

        public bool Remove(PhotoAlbum entity)
        {
            if (db.PhotoAlbums.Where(e=>e.PhotoAlbumId != entity.PhotoAlbumId).Any())
            {
                return false;
            }
            else
            {
                db.PhotoAlbums.Remove(entity);
                db.SaveChanges();
                return true;
            }
        }
    }
}
