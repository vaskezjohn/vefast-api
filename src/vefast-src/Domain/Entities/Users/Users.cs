using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vefast_src.Domain.Entities.Users
{
    public class Users
    {
		[Key]
		public Guid ID { get; set; }
		public string User { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Phone { get; set; }
		public int Gender { get; set; }

		public DateTime InsertDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public virtual Users UpdateUser { get; set; }
		public virtual Users InsertUser { get; set; }
	}
}
