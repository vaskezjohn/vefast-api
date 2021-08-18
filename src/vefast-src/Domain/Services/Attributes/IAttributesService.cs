using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vefast_src.DTO.Attributes;

namespace vefast_src.Domain.Services.Attributes
{
    public interface IAttributesService
    {
        IEnumerable<AttributesResponse> GetAllAttributes();
        Task<AttributesResponse> CreateAttributesAsync(AttributesRequest objRequest);
        Task<AttributesResponse> GetAttributesByIdAsync(Guid id);
        Task DeleteAttributesById(Guid id);
        Task<AttributesResponse> EditAttributesByIdAsync(Guid id, AttributesRequest objRequest);
    }
}
