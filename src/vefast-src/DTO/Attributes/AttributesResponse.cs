using System;
using System.Collections.Generic;
using vefast_src.DTO.AttributeValues;

namespace vefast_src.DTO.Attributes
{
    public class AttributesResponse
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public IEnumerable<AttributeValuesResponse> AttributeValues { get; set; }
    }
}
