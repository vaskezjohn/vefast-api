using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace vefast_src.DTO.ProductTypes
{
    using vefast_src.Domain.Entities.Products;
    public class ProductTypesRequest
    {
        public string tipoProduct { get; set; }
        public bool active { get; set; }
        [ForeignKey("Products")]
        public Guid ProductsID { get; set; }
        public virtual Products Products { get; set; }
    }
}
