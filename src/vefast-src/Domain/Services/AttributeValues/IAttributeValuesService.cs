using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vefast_src.DTO.AttributeValues;

namespace vefast_src.Domain.Services.AttributeValues
{
    public interface IAttributeValuesService
    {
        IEnumerable<AttributeValuesResponse> GetAllAttributeValue();
        Task<AttributeValuesResponse> CreateAttributeValueAsync(AttributeValuesRequest objRequest);
        Task<AttributeValuesResponse> GetAttributeValueByIdAsync(Guid id);
        Task DeleteAttributeValueById(Guid id);
        Task<AttributeValuesResponse> EditAttributeValueByIdAsync(Guid id, AttributeValuesRequest objRequest);
    }
}
