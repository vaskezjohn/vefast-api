using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace vefast_src.Domain.Entities.AttributeValue
{    
    using vefast_src.Domain.Entities.AttributeValueTipoProducto;
    public class AttributeValue : BaseEntity
    {
        public string value { get; set; }
        public Guid attribute_parent_id { get; set; }      
        //public Guid products_id { get; set; }
        public Guid attributes_id { get; set; }
        [ForeignKey("AttributeValueTipoProducto")]
        public Guid AttributeValueTipoProductoID { get; set; }

        public virtual AttributeValueTipoProducto AttributeValueTipoProducto { get; set; }
    }
}
