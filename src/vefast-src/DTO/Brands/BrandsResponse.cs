using System;
using System.ComponentModel.DataAnnotations.Schema;
using vefast_src.DTO.Products;
using vefast_src.DTO.ProductTypes;

namespace vefast_src.DTO.Brands
{
    public class BrandsResponse
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public Guid ID_Product { get; set; }
        public Guid ID_ProductType { get; set; }
        public ProductsResponse Product { get; set; }
        public ProductTypesResponse ProductType { get; set; }
    }
}
