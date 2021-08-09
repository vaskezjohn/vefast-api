using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vafast_src.Domain.Entities.User
{
    public class User
    {
		public Guid ID { get; set; }
		public string user { get; set; }
		public string password { get; set; }
		public string email { get; set; }
		public string firstname { get; set; }
		public string lastname { get; set; }
		public string phone { get; set; }
		public int gender { get; set; }
	}
}
