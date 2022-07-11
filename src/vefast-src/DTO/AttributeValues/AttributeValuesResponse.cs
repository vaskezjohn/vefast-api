using System;
using vefast_src.DTO.Attributes;

namespace vefast_src.DTO.AttributeValues
{
    public class AttributeValuesResponse
    {
        public string Value { get; set; }
        public Guid ID_Attribute { get; set; }
        public AttributesResponse Attribute { get; set; }
    }
}
