using System;
using vefast_src.DTO.AttributeValueTipoProducto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace vefast_src.Domain.Services.AttributeValueTipoProducto
{
    public interface IAttributeValueTipoProductoService
    {
        IEnumerable<AttributeValueTipoProductoResponse> GetAllAttributeValueTipoProducto();
        Task<AttributeValueTipoProductoResponse> CreateAttributeValueTipoProductoAsync(AttributeValueTipoProductoRequest objRequest);
        Task<AttributeValueTipoProductoResponse> GetAttributeValueTipoProductoByIdAsync(Guid id);
        Task DeleteAttributeValueTipoProductoById(Guid id);
        Task<AttributeValueTipoProductoResponse> EditAttributeValueTipoProductoByIdAsync(Guid id, AttributeValueTipoProductoRequest objRequest);

    }
}
