using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vefast_src.Domain.Entities.Companes
{
    public class Companes : BaseEntity
    {
        [StringLength(255)]
        public string company_name { get; set; }
        [StringLength(255)]
        public string service_charge_value { get; set; }
        [StringLength(255)]
        public string vat_charge_value { get; set; }
        [StringLength(255)]
        public string address { get; set; }
        [StringLength(255)]
        public string phone { get; set; }
        [StringLength(255)]
        public string country { get; set; }
        [StringLength(255)]
        public string message { get; set; }
        [StringLength(255)]
        public string currency { get; set; }
    }
}
