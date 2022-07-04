using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace vefast_src.DTO.AttributeValueTipoProducto
{
    using vefast_src.Domain.Entities.AttributeValue;
    using vefast_src.Domain.Entities.ProductsType;

    public class AttributeValueTipoProductoResponse
    {
        [ForeignKey("AttributeValue")]
        public Guid IDAttributeValue { get; set; }
        public virtual AttributeValue AttributeValue { get; set; }

        [ForeignKey("TipoProducto")]
        public Guid IDTipoProducto { get; set; }
        public virtual ProductsType TipoProducto { get; set; }
    }
}
