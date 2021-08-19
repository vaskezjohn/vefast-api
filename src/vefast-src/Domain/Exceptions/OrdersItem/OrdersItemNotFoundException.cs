using System;
namespace vefast_src.Domain.Exceptions.OrdersItem
{
    public class OrdersItemNotFoundException : Exception
    {
        public OrdersItemNotFoundException(string message) : base(message)
        {
        }
    }
}
