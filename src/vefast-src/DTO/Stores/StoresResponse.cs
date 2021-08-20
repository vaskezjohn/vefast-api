using System;
namespace vefast_src.DTO.Stores
{
    public class StoresResponse
    {
        public string name { get; set; }
        public bool active { get; set; }
        public Guid Company_id { get; set; }
    }
}
