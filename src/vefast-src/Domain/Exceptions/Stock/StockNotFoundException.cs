using System;
namespace vefast_src.Domain.Exceptions.Stock
{
    public class StockNotFoundException : Exception
    {
        public StockNotFoundException(string message)
            : base(message)
        {
        }
    }
}
