using System;
namespace vefast_src.Domain.Exceptions.AttributeValue
{
    public class AttributeValueNotFoundException : Exception
    {
        public AttributeValueNotFoundException(string message) : base(message)
        {
        }
    }
}
