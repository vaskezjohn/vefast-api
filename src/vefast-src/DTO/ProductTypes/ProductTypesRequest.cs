using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace vefast_src.DTO.ProductTypes
{
    using vefast_src.Domain.Entities.Products;
    using vefast_src.DTO.Products;

    public class ProductTypesRequest
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public Guid ID_Product { get; set; }
        public ProductsRequest Product { get; set; }
    }
}
