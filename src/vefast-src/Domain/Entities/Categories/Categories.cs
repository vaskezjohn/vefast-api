using System;
namespace vefast_src.Domain.Entities.Categories
{
    public class Categories : BaseEntity
    {
        public string name { get; set; }
        public bool active { get; set; }
        public Guid products_id { get; set; }
    }
}
