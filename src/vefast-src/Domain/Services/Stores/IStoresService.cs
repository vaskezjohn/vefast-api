using System;
using vefast_src.DTO.Stores;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace vefast_src.Domain.Services.Stores
{
    public interface IStoresService
    {
        IEnumerable<StoresResponse> GetAllStores();
        Task<StoresResponse> CreateStoresAsync(StoresRequest objRequest);
        Task<StoresResponse> GetStoresByIdAsync(Guid id);
        Task DeleteStoresById(Guid id);
        Task<StoresResponse> EditStoresByIdAsync(Guid id, StoresRequest objRequest);
    }
}
