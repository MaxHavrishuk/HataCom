using BusinessLogic.DbInitialize;
using BusinessLogic.Models;
using BusinessLogic.Models.Authorization;
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
		static HataContext()//ініціалізація бд в статичному конструкторі класа контекста.
		{
			Database.SetInitializer<HataContext>(new DbInitializer());
		}
		public DbSet<PhotoAlbum> PhotoAlbums { get; set; }
		public DbSet<Photo> Photos { get; set; }
		
		public DbSet<UserModel> Users { get; set; }

		//Таблиця з ролями користувачів
		public DbSet<Role> Roles { get; set; }

	}

}
