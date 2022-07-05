using System;
namespace vefast_src.Domain.Exceptions.Brands
{
    public class BrandsNotFoundException : Exception
    {
        public BrandsNotFoundException(string message)
            : base(message)
        {
        }
    }
}
