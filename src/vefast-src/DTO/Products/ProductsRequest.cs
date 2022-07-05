using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vefast_src.DTO.Products
{
    public class ProductsRequest
    {
        public string name { get; set; }        
        public string sku { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }        
        public string description { get; set; }
        public Guid attribute_value_id { get; set; }
        public Guid brand_id { get; set; }
        public Guid category_id { get; set; }
        public Guid store_id { get; set; }
        public bool availability { get; set; }
    }
}
