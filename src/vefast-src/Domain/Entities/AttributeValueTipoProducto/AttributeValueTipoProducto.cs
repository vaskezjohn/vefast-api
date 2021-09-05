using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace vefast_src.Domain.Entities.AttributeValueTipoProducto
{
    using vefast_src.Domain.Entities.AttributeValue;
    using vefast_src.Domain.Entities.TipoProducto;
    public class AttributeValueTipoProducto : BaseEntity
    {
        [ForeignKey ("AttributeValue")]
        public Guid IDAttributeValue{ get; set; }
        public virtual AttributeValue AttributeValue { get; set; }

        [ForeignKey("TipoProducto")]
        public Guid IDTipoProducto { get; set; }
        public virtual TipoProducto TipoProducto { get; set; }
    }
}
