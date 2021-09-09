using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace vefast_src.Domain.Entities.Brands
{
    using vefast_src.Domain.Entities.Products; 
    public class Brands : BaseEntity
    {
        public string name { get; set; }
        public bool active { get; set; }
        [ForeignKey("Products")]
        public Guid products_id { get; set; }
        virtual public Products Products { get; set; }
    }
}
