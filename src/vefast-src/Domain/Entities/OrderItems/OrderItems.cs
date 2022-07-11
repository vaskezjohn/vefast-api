namespace vefast_src.Domain.Entities.OrderItems
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using vefast_src.Domain.Entities.Products;
    using vefast_src.Domain.Entities.Orders;

    public class OrderItems : BaseEntity
    {
        [ForeignKey("Orders")]
        public Guid ID_Order { get; set; }

        [ForeignKey("Products")]
        public Guid ID_Product { get; set; }
        public int Quantity { get; set; } /*cantidad de producto*/
        public int Rate { get; set; } /*valoracion del producto*/
        public double Amount { get; set; } /*monto del producto*/
        public virtual Products Products { get; set; }
        public virtual Orders Orders { get; set; }
    }
}
