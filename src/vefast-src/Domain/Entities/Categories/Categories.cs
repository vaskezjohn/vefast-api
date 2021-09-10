using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vefast_src.Domain.Entities.Categories
{
    using vefast_src.Domain.Entities.Products;
    public class Categories : BaseEntity
    {
        public string name { get; set; }
        public bool active { get; set; }
        [ForeignKey("Products")]
        public Guid products_id { get; set; }

        public virtual Products Products { get; set; }

    }
}
