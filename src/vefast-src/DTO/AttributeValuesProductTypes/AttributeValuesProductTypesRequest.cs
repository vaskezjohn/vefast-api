using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace vefast_src.DTO.AttributeValuesProductTypes
{
    using vefast_src.Domain.Entities.AttributeValues;
    using vefast_src.Domain.Entities.ProductTypes;

    public class AttributeValuesProductTypesRequest
    {
        public Guid ID { get; set; }
        public Guid ID_AttributeValue { get; set; }
        public Guid ID_ProductType { get; set; }
    }
}
