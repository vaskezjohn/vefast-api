using System;
namespace vefast_src.DTO.AttributeValues
{
    public class AttributeValuesRequest
    {
        public string value { get; set; }
        public Guid attribute_parent_id { get; set; }
        public Guid products_id { get; set; }
        public Guid attributes_id { get; set; }
    }
}
