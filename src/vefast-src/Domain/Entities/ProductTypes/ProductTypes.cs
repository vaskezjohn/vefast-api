using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace vefast_src.Domain.Entities.ProductTypes
{
    using System.Collections.Generic;
    using vefast_src.Domain.Entities.Products;
    public class ProductTypes : BaseEntity
    {
        public string ProductType { get; set; }
        public bool Active { get; set; }
        public virtual IEnumerable<Products> Products { get; set; }
    }
}

