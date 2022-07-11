using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vefast_src.DTO.Products
{
    public class ProductsRequest
    {
        public string Name { get; set; }        
        public string Sku { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }        
        public string Description { get; set; }
        public Guid ID_AttributeValue { get; set; }
        public Guid ID_Brand { get; set; }
        public Guid ID_Category { get; set; }
        public Guid ID_Store { get; set; }
        public bool Availability { get; set; }
    }
}
