using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vefast_src.Domain.Entities.Users
{
    public class Users : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string AccessToken { get; set; }
		public DateTime? TokenExpiryTime { get; set; }
		public string RefreshToken { get; set; }
		public DateTime? RefreshTokenExpiryTime { get; set; }

		[ForeignKey("User")]
		public string ID_InsertUser { get; set; }
		public virtual Users User { get; set; }
		public DateTime? InsertDate { get; set; }
	}
}
