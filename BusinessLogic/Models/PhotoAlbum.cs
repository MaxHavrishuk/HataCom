using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace BusinessLogic
{
	public class PhotoAlbum
	{
		[Key]
		public int PhotoAlbumId { get; set; }

		public int UserId { get; set; }

		[StringLength(50)]
		public string Title { get; set; }

		
		public List<Photo> Photos { get; set; }
		public PhotoAlbum()
		{
			Photos = new List<Photo>();
		}
	}
}
