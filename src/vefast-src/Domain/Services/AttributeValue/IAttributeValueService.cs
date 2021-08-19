using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vefast_src.DTO.AttributeValue;

namespace vefast_src.Domain.Services.AttributeValue
{
    public interface IAttributeValueService
    {
        IEnumerable<AttributeValueResponse> GetAllAttributeValue();
        Task<AttributeValueResponse> CreateAttributeValueAsync(AttributeValueRequest objRequest);
        Task<AttributeValueResponse> GetAttributeValueByIdAsync(Guid id);
        Task DeleteAttribute_valueById(Guid id);
        Task<AttributeValueResponse> EditAttributeValueByIdAsync(Guid id, AttributeValueRequest objRequest);
    }
}
