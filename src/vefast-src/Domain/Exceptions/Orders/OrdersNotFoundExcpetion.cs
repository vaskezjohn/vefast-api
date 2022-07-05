using System;
namespace vefast_src.Domain.Exceptions.Orders
{
    public class OrdersNotFoundException : Exception
    {
        public OrdersNotFoundException(string message) : base(message)
        {
        }
    }
}
