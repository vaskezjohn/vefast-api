using System;
namespace vefast_src.Domain.Entities.Attributes
{
    public class Attributes : BaseEntity
    {
        public string name { get; set; }
        public bool active { get; set; }
    }
}
