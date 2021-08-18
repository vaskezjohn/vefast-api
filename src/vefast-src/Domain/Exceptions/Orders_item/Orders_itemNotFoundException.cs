using System;
namespace vefast_src.Domain.Exceptions.Orders_item
{
    public class Orders_itemNotFoundException : Exception
    {
        public Orders_itemNotFoundException(string message) : base(message)
        {
        }
    }
}
