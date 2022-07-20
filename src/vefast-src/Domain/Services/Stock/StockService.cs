using System;
using vefast_src.Domain.Exceptions.Stock;
using vefast_src.Domain.Repositories.Stock;
using vefast_src.DTO.Stock;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace vefast_src.Domain.Services.Stock
{
    public class StockService : IStockService
    {
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;

        public StockService(IMapper mapper, IStockRepository stockRepository)
        {
            this._mapper = mapper;
            this._stockRepository = stockRepository;
        }

        public ICollection<StockResponse> GetAllStock()
        {
            return _mapper.Map<ICollection<StockResponse>>(_stockRepository.GetAll());
        }

        public async Task<StockResponse> CreateStockAsync(StockRequest objRequest)
        {
            var stock = _mapper.Map<Entities.StockDeposits.StockDeposits>(objRequest);
            _stockRepository.Add(stock);

            try
            {
                await _stockRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<StockResponse>(stock);
        }

        public async Task<StockResponse> GetStockByIdAsync(Guid id)
        {
            var stock = await _stockRepository.GetByIDAsync(id);
            if (stock == null)
            {
                throw new StockNotFoundException("Stock no encontrado.");
            }

            return _mapper.Map<StockResponse>(stock);
        }

        public async Task DeleteStockById(Guid id)
        {
            var stock = _stockRepository.GetByID(id);

            if (stock == null)
            {
                throw new StockNotFoundException("Stock no encontrado.");
            }

            _stockRepository.Delete(stock);
            await _stockRepository.SaveAsync();
        }

        public async Task<StockResponse> EditStockByIdAsync(Guid id, StockRequest objRequest)
        {
            var stock = await _stockRepository.GetByIDAsync(id);

            if (stock == null)
            {
                throw new StockNotFoundException("Stock no encontrado.");
            }

            stock.ID_Product = objRequest.ID_Product;
            stock.Quantity = objRequest.Quantity;
            

            _stockRepository.Update(stock);
            await _stockRepository.SaveAsync();

            return _mapper.Map<StockResponse>(stock);
        }
    }
}
