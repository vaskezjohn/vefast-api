using System;

namespace vefast_src.Domain.Exceptions.AttributeValues
{
    public class AttributeValuesNotFoundException : Exception
    {
        public AttributeValuesNotFoundException(string message) : base(message)
        {
        }
    }
}
