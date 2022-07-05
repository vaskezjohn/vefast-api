using System;
namespace vefast_src.DTO.OrdersItem
{
    public class OrdersItemResponse
    {
        public int order_id { get; set; }
        public Guid product_id { get; set; }
        public int quantity { get; set; } /*cantidad de producto*/
        public int rate { get; set; } /*valoracion del producto*/
        public double amount { get; set; } /*monto del producto*/
    }
}
