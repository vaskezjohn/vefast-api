namespace vefast_src.Domain.Entities.Products
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using vefast_src.Domain.Entities.Stores;
    using vefast_src.Domain.Entities.Brands;
    using vefast_src.Domain.Entities.Categories;
    using vefast_src.Domain.Entities.ProductTypes;

    public class Products : BaseEntity
    {
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(15)]
        public string Sku { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "Text")]
        public string Description { get; set; }

        [ForeignKey("ProductTypes")]
        public Guid ID_ProductType { get; set; }

        [ForeignKey("Brands")]
        public Guid ID_Brand { get; set; }

        [ForeignKey("Categories")]
        public Guid ID_Category { get; set; }

        [ForeignKey("Stores")]
        public Guid ID_Store { get; set; }        
        public bool Availability { get; set; }
        public virtual ProductTypes ProductType { get; set; }
        public virtual Brands Brand { get; set; }
        public virtual Categories Category { get; set; }
        public virtual Stores Store { get; set; }
    }
}
