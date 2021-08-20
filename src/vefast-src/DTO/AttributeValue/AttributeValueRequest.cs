using System;
namespace vefast_src.DTO.AttributeValue
{
    public class AttributeValueRequest
    {
        public string value { get; set; }
        public Guid attribute_parent_id { get; set; }
        public Guid products_id { get; set; }
        public Guid attributes_id { get; set; }
    }
}
