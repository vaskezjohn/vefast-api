﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vefast_src.DTO.Users
{
    public class RefreshTokenRequest
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
    }
}
