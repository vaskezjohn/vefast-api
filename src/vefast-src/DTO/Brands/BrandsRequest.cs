using System;
namespace vefast_src.DTO.Brands
{
    public class BrandsRequest
    {
        public string name { get; set; }
        public bool active { get; set; }
        public Guid products_id { get; set; }
    }
}
