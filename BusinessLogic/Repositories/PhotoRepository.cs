using BusinessLogic.Models;
using HataCom.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HataCom.Repositories
{
    public class PhotoRepository : IRepository<Photo>
    {
        public void Add(Photo entity)
        {
            throw new NotImplementedException();
        }

        public Photo Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Photo> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Photo entity)
        {
            throw new NotImplementedException();
        }
    }
}