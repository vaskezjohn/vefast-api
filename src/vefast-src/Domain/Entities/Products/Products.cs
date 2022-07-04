namespace vefast_src.Domain.Entities.Products
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using vefast_src.Domain.Entities.Stores;
    using vefast_src.Domain.Entities.Brands;
    using vefast_src.Domain.Entities.Categories;
    using vefast_src.Domain.Entities.ProductsType;

    public class Products : BaseEntity
    {
        [StringLength(255)]
        public string name { get; set; }
        [StringLength(15)]
        public string sku { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        [Column(TypeName = "Text")]
        public string description { get; set; }
        [ForeignKey("TipoProducto")]
        public Guid tipoProductoID { get; set; }
        [ForeignKey("Brands")]
        public Guid brand_id { get; set; }
        [ForeignKey("Categories")]
        public Guid category_id { get; set; }
        [ForeignKey("Stores")]
        public Guid store_id { get; set; }        
        public bool availability { get; set; }

        public virtual ProductsType TipoProducto { get; set; }
        public virtual Brands Brands { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual Stores Stores { get; set; }
    }
}
