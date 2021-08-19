﻿using System;
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
		public string user { get; set; }
		public string password { get; set; }
		public string email { get; set; }
		public string firstname { get; set; }
		public string lastname { get; set; }
		public string phone { get; set; }
		public int gender { get; set; }
	}
}