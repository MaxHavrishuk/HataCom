﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.Models.Enum.Enum;

namespace BusinessLogic.Models
{
	public class SignIn
	{
<<<<<<< HEAD
		[Required(ErrorMessage = "Заповніть це поле")]
		public string Login { get; set; }

		[Required(ErrorMessage = "Заповніть це поле")]
		[DataType(DataType.Password)]
=======
		public string Login { get; set; }
>>>>>>> Max_View
		public string Password { get; set; }
	}

}
