using System;
namespace vefast_src.DTO.Categories
{
    public class CategoriesResponse
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public Guid ID_Product { get; set; }
    }
}
