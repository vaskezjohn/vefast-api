using System;
namespace vefast_src.DTO.Categories
{
    public class CategoriesResponse
    {
        public string name { get; set; }
        public bool active { get; set; }
        public Guid products_id { get; set; }
    }
}
