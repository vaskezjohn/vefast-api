using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace vefast_src.DTO.ProductTypes
{
    using vefast_src.Domain.Entities.Products;
    using vefast_src.DTO.Products;

    public class ProductTypesResponse
    {
        public string TipoProduct { get; set; }
        public bool Active { get; set; }
        public Guid ID_Product { get; set; }
        public ProductsResponse Product { get; set; }
    }
}
