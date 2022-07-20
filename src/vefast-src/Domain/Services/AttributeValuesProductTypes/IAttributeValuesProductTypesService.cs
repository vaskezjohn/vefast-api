using System;
using vefast_src.DTO.AttributeValuesProductTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace vefast_src.Domain.Services.AttributeValuesProductTypes
{
    public interface IAttributeValuesProductTypesService
    {
        ICollection<AttributeValuesProductTypesResponse> GetAllAttributeValueTipoProducto();
        Task<AttributeValuesProductTypesResponse> CreateAttributeValueTipoProductoAsync(AttributeValuesProductTypesRequest objRequest);
        Task<AttributeValuesProductTypesResponse> GetAttributeValueTipoProductoByIdAsync(Guid id);
        Task DeleteAttributeValueTipoProductoById(Guid id);
        Task<AttributeValuesProductTypesResponse> EditAttributeValueTipoProductoByIdAsync(Guid id, AttributeValuesProductTypesRequest objRequest);

    }
}
