using System;

namespace vefast_src.Domain.Exceptions.OrderItems
{
    public class OrderItemsNotFoundException : Exception
    {
        public OrderItemsNotFoundException(string message) : base(message)
        {
        }
    }
}
