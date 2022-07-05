using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace vefast_src.DTO.AttributeValuesProductTypes
{
    using vefast_src.Domain.Entities.AttributeValues;
    using vefast_src.Domain.Entities.ProductTypes;

    public class AttributeValuesProductTypesRequest
    {
        [ForeignKey("AttributeValue")]
        public Guid IDAttributeValue { get; set; }
        public virtual AttributeValues AttributeValue { get; set; }

        [ForeignKey("TipoProducto")]
        public Guid IDTipoProducto { get; set; }
        public virtual ProductTypes TipoProducto { get; set; }
    }
}
