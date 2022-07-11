using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vefast_src.DTO.Company
{
    public class CompaniesRequest
    {
		public string CompanyName { get; set; }
		public string ServiceChargeValue { get; set; }
		public string VatChargeValue { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public string Country { get; set; }
		public string Message { get; set; }
		public string Currency { get; set; }
	}
}
