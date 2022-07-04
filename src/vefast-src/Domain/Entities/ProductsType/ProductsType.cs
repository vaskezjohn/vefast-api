using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace vefast_src.Domain.Entities.ProductsType
{
    using System.Collections.Generic;
    using vefast_src.Domain.Entities.Products;
    public class ProductsType : BaseEntity
    {
        public string tipoProduct { get; set; }
        public bool active { get; set; }
        public virtual IEnumerable<Products> Products { get; set; }
    }
}

