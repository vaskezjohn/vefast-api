using System;
using vefast_src.DTO.TipoProducto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace vefast_src.Domain.Services.TipoProducto
{
    public interface ITipoProductoService
    {
        IEnumerable<TipoProductoResponse> GetAllTipoProducto();
        Task<TipoProductoResponse> CreateTipoProductoAsync(TipoProductoRequest objRequest);
        Task<TipoProductoResponse> GetTipoProductoByIdAsync(Guid id);
        Task DeleteTipoProductoById(Guid id);
        Task<TipoProductoResponse> EditTipoProductoByIdAsync(Guid id, TipoProductoRequest objRequest);
    }
    
}
