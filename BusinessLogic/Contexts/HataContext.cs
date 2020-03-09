using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Contexts
{
	/// <summary>
	/// Контекст бази даних (описання таблиць)
	/// </summary>
	public class HataContext : DbContext
	{
		//public HataContext() : base("name=DefaultConnection") { } // передати connrctionString Name для підключення до БД.

		public DbSet<PhotoAlbum> PhotoAlbums { get; set; }
		public DbSet<Photo> Photos { get; set; }

	}

}
