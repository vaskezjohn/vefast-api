using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace vefast_src.Domain.Entities.Stock
{
    using vefast_src.Domain.Entities.Products;
    public class Stock : BaseEntity
    {
        public int cantidad { get; set; }
        [ForeignKey("Products")]
        public Guid IDProducts {get;set;}
        public virtual Products Products { get; set; }
    
    }
}
