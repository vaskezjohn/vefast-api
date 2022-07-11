using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace vefast_src.DTO.Brands
{
    using vefast_src.DTO.Products;
    using vefast_src.DTO.ProductTypes;

    public class BrandsRequest
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public Guid ID_Product { get; set; }
        public Guid ID_ProductType { get; set; }
        public ProductsRequest Product { get; set; }
        public ProductTypesRequest ProductType { get; set; }
    }
}
