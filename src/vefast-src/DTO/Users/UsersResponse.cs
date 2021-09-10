using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vefast_src.DTO.Users
{
    public class UsersResponse
    {
		public Guid ID { get; set; }
		public string user { get; set; }
		public string password { get; set; }
		public string email { get; set; }
		public string firstname { get; set; }
		public string lastname { get; set; }
		public string phone { get; set; }
		public int gender { get; set; }
		public string token { get; set; }
		public DateTime? tokenExpires { get; set; }
		public string refreshToken { get; set; }
		public bool changePassword { get; set; }
		public bool downLogic { get; set; }
	}
}
