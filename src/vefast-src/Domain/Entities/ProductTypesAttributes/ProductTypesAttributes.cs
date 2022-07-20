namespace vefast_src.Domain.Entities.ProductTypesAttributes
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using vefast_src.Domain.Entities.ProductTypes;
    using vefast_src.Domain.Entities.Attributes;

    public class ProductTypesAttributes : BaseEntity
    {

        [Required]
        [ForeignKey("ProductType")]
        public string ID_ProductType { get; set; }
        public virtual ProductTypes ProductType { get; set; }

        [Required]
        [ForeignKey("Attribute")]
        public string ID_Attribute { get; set; }
        public virtual Attributes Attribute { get; set; }
    }
}
