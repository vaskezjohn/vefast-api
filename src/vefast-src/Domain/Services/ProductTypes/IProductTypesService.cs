using System;
using vefast_src.DTO.ProductTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace vefast_src.Domain.Services.ProductTypes
{
    public interface IProductTypesService
    {
        IEnumerable<ProductTypesResponse> GetAllTipoProducto();
        Task<ProductTypesResponse> CreateTipoProductoAsync(ProductTypesRequest objRequest);
        Task<ProductTypesResponse> GetTipoProductoByIdAsync(Guid id);
        Task DeleteTipoProductoById(Guid id);
        Task<ProductTypesResponse> EditTipoProductoByIdAsync(Guid id, ProductTypesRequest objRequest);
    }
    
}
