using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace vefast_src.DTO.Stock
{
    using vefast_src.Domain.Entities.Products;
    public class StockRequest
    {
        public int cantidad { get; set; }
        [ForeignKey("Products")]
        public Guid IDProducts { get; set; }
        public virtual Products Products { get; set; }
    }
}
