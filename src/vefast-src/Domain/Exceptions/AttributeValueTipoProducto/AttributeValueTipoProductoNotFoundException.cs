using System;
namespace vefast_src.Domain.Exceptions.AttributeValueTipoProducto
{
    public class AttributeValueTipoProductoNotFoundException : Exception
    {
        public AttributeValueTipoProductoNotFoundException(string message)
            :base(message)
        {
        }
    }
}
