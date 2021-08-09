﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vafast_src.DTO.Company
{
    public class CompanyResponse
    {
		public Guid id { get; set; }
		public string company_name { get; set; }
		public string service_charge_value { get; set; }
		public string vat_charge_value { get; set; }
		public string address { get; set; }
		public string phone { get; set; }
		public string country { get; set; }
		public string message { get; set; }
		public string currency { get; set; }
	}
}
