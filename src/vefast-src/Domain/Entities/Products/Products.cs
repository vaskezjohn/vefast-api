namespace vefast_src.Domain.Entities.Products
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using vefast_src.Domain.Entities.Stores;
    using vefast_src.Domain.Entities.Brands;
    using vefast_src.Domain.Entities.Categories;
    using vefast_src.Domain.Entities.ProductTypes;
    using vefast_src.Domain.Entities.Prices;
    using System.Collections.Generic;

    public class Products : BaseEntity
    {
        [Required]
        public string CodVFS { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(1000)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Sku { get; set; }
        public virtual ICollection<Prices> Price { get; set; }

        [Required]
        [Column(TypeName = "decimal(15,2)")]
        public double CostFOB { get; set; }

        [Required]
        [Column(TypeName = "decimal(15,2)")]
        public double Expenses { get; set; }        

        [Required]
        [Column(TypeName = "int")]
        public int Quantity { get; set; }

        [Column(TypeName = "int")]
        public int QuantityPackage { get; set; }

        [Column(TypeName = "int")]
        public int QuantityFailed { get; set; }

        [Column(TypeName = "int")]
        public int ReorderPoint { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string UnitMeasurement { get; set; }

        public bool Availability { get; set; }

        [Required]
        [ForeignKey("Brand")]
        public Guid ID_Brand { get; set; }
        public virtual Brands Brand { get; set; }

        [Required]
        [ForeignKey("Category")]
        public Guid ID_Category { get; set; }
        public virtual Categories Category { get; set; }

        [Required]
        [ForeignKey("Store")]
        public Guid ID_Store { get; set; }
        public virtual Stores Store { get; set; }


    }
}
