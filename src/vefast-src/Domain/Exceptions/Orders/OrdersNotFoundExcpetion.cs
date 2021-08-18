using System;
namespace vefast_src.Domain.Exceptions.Orders
{
    public class OrdersNotFoundExcpetion : Exception
    {
        public OrdersNotFoundExcpetion(string message) : base(message)
        {
        }
    }
}
