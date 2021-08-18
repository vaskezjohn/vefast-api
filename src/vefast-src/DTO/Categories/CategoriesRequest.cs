using System;
namespace vefast_src.DTO.Categories
{
    public class CategoriesRequest
    {
        public string name { get; set; }
        public bool active { get; set; }
        public Guid products_id { get; set; }
    }
}
