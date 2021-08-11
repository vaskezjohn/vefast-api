using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vafast_src.Domain.Entities.Products
{
    public class Products : BaseEntity
    {
        [StringLength(255)]
        public string name { get; set; }
        [StringLength(15)]
        public string sku { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        [Column(TypeName = "Text")]
        public string description { get; set; }
        public Guid attribute_value_id { get; set; }
        public Guid brand_id { get; set; }
        public Guid category_id { get; set; }
        public Guid store_id { get; set; }
        public bool availability { get; set; }
    }
}
