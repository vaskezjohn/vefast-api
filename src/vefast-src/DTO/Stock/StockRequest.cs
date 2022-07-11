using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace vefast_src.DTO.Stock
{
    using vefast_src.Domain.Entities.Products;
    using vefast_src.DTO.Products;

    public class StockRequest
    {
        public int Cantidad { get; set; }
        public Guid ID_Product { get; set; }
        public ProductsRequest Product { get; set; }
    }
}
