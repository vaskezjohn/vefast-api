using System;
namespace vefast_src.Domain.Entities.Attribute_value
{
    public class Attribute_value : BaseEntity
    {
        public string value { get; set; }
        public Guid attribute_parent_id { get; set; }
        public Guid products_id { get; set; }
        public Guid attributes_id { get; set; }
    }
}
