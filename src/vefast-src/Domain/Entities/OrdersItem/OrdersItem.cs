using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace vefast_src.Domain.Entities.OrdersItem
{
    using vefast_src.Domain.Entities.Products;
    public class OrdersItem : BaseEntity
    {
        public int order_id { get; set; }
        [ForeignKey("Products")]
        public Guid product_id { get; set; }
        public int quantity { get; set; } /*cantidad de producto*/
        public int rate { get; set; } /*valoracion del producto*/
        public double amount { get; set; } /*monto del producto*/

        public virtual Products Products { get; set; }
    }
}
