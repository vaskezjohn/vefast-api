using System;
namespace vefast_src.DTO.OrdersItem
{
    public class OrdersItemRequest
    {
        public Guid ID_Order { get; set; }
        public Guid ID_Product { get; set; }
        public int Quantity { get; set; } /*cantidad de producto*/
        public int Rate { get; set; } /*valoracion del producto*/
        public double Amount { get; set; } /*monto del producto*/
    }
}
