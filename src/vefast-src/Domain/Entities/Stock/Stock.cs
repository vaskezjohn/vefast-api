using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace vefast_src.Domain.Entities.Stock
{
    using vefast_src.Domain.Entities.Products;
    public class Stock : BaseEntity
    {
        public int Cantidad { get; set; }

        [ForeignKey("Products")]
        public Guid ID_Product {get;set;}
        public virtual Products Product { get; set; }
    
    }
}
