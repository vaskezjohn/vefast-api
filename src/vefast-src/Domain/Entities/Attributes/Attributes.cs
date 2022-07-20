namespace vefast_src.Domain.Entities.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using vefast_src.Domain.Entities.AttributeValues;
    using System.ComponentModel.DataAnnotations;

    public class Attributes : BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<AttributeValues> AttributeValues { get; set; }
    }
}
