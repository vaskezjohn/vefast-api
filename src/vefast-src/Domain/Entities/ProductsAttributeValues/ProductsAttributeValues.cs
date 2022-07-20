namespace vefast_src.Domain.Entities.ProductsAttributeValues
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using vefast_src.Domain.Entities.AttributeValues;
    using vefast_src.Domain.Entities.ProductTypes;

    public class ProductsAttributeValues : BaseEntity
    {
        [ForeignKey("AttributeValues")]
        public Guid ID_AttributeValue { get; set; }
        public virtual AttributeValues AttributeValue { get; set; }

        [ForeignKey("ProductsType")]
        public Guid ID_ProductType { get; set; }
        public virtual ProductTypes ProductType { get; set; }
    }
}
