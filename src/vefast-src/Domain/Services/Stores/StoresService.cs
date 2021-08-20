using System;
using vefast_src.Domain.Exceptions.Stores;
using vefast_src.Domain.Repositories.Stores;
using vefast_src.DTO.Stores;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace vefast_src.Domain.Services.Stores
{
    public class StoresService : IStoresService
    {
        private readonly IMapper _mapper;
        private readonly IStoresRepository _storesRepository;

        public StoresService(IMapper mapper, IStoresRepository storesRepository)
        {
            this._mapper = mapper;
            this._storesRepository = storesRepository;
        }

        public IEnumerable<StoresResponse> GetAllStores()
        {
            return _mapper.Map<IEnumerable<StoresResponse>>(_storesRepository.GetAll());
        }

        public async Task<StoresResponse> CreateStoresAsync(StoresRequest objRequest)
        {
            var stores = _mapper.Map<Entities.Stores.Stores>(objRequest);
            _storesRepository.Add(stores);

            try
            {
                await _storesRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<StoresResponse>(stores);
        }

        public async Task<StoresResponse> GetStoresByIdAsync(Guid id)
        {
            var stores = await _storesRepository.GetByIDAsync(id);
            if (stores == null)
            {
                throw new StoresNotFoundException("Tienda no encontrada.");
            }

            return _mapper.Map<StoresResponse>(stores);
        }

        public async Task DeleteStoresById(Guid id)
        {
            var stores = _storesRepository.GetByID(id);

            if (stores == null)
            {
                throw new StoresNotFoundException("Tienda no encontrada.");
            }

            _storesRepository.Delete(stores);
            await _storesRepository.SaveAsync();
        }

        public async Task<StoresResponse> EditStoresByIdAsync(Guid id, StoresRequest objRequest)
        {
            var stores = await _storesRepository.GetByIDAsync(id);

            if (stores == null)
            {
                throw new StoresNotFoundException("Tienda no encontrada.");
            }

            stores.ID = objRequest.Company_id;
            stores.name = objRequest.name;
            stores.active = objRequest.active;
            
            _storesRepository.Update(stores);
            await _storesRepository.SaveAsync();

            return _mapper.Map<StoresResponse>(stores);
        }

    }
}
