namespace vefast_src.Domain.Entities.Brands
{
    using System.Collections.Generic;
    using vefast_src.Domain.Entities.Products; 
    public class Brands : BaseEntity
    {
        public string name { get; set; }
        public bool active { get; set; }
        public virtual IEnumerable<Products> Products { get; set; }
    }
}
