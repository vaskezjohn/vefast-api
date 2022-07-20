namespace vefast_src.Domain.Entities.Brands
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using vefast_src.Domain.Entities.Products; 
    public class Brands : BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
