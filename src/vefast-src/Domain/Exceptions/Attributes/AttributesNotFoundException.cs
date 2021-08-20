using System;
namespace vefast_src.Domain.Exceptions.Attributes
{
    public class AttributesNotFoundException : Exception
    {
        public AttributesNotFoundException(string message) : base(message)
        {
        }
    }
}
