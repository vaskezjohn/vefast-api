using System;
namespace vefast_src.Domain.Entities.Brands
{
    public class Brands : BaseEntity
    {
        public string name { get; set; }
        public bool active { get; set; }
        public Guid products_id { get; set; }        
    }
}
