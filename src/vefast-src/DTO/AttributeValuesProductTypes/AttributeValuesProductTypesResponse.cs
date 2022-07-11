using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace vefast_src.DTO.AttributeValuesProductTypes
{
    using vefast_src.DTO.AttributeValues;
    using vefast_src.DTO.ProductTypes;

    public class AttributeValuesProductTypesResponse
    {
        public Guid ID_AttributeValue { get; set; }
        public Guid ID_ProductType { get; set; }
    }
}
