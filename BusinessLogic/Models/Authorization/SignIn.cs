using System;
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
		public string Login { get; set; }
		public string Password { get; set; }
	}

}
