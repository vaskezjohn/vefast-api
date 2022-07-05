using System;

namespace vefast_src.Domain.Exceptions.AttributeValuesProductTypes
{
    public class AttributeValuesProductTypesNotFoundException : Exception
    {
        public AttributeValuesProductTypesNotFoundException(string message)
            : base(message)
        {
        }
    }
}
