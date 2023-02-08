namespace vefast_src.Domain.Entities.Categories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using vefast_src.Domain.Entities.Products;
    public class Categories : BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Products> Products { get; set; }

        [ForeignKey("Category")]
        public Guid ID_ParentCategory { get; set; }
        public virtual Categories Category { get; set; }

    }
}
