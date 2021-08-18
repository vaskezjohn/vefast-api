using System;
namespace vefast_src.Domain.Entities.Orders_item
{
    public class Orders_item : BaseEntity
    {
        public int order_id { get; set; }
        public Guid product_id { get; set; }
        public int quantity { get; set; } /*cantidad de producto*/
        public int rate { get; set; } /*valoracion del producto*/
        public double amount { get; set; } /*monto del producto*/
    }
}
