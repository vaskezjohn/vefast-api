using System;
using vefast_src.DTO.Stock;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace vefast_src.Domain.Services.Stock
{
    public interface IStockService
    {
        ICollection<StockResponse> GetAllStock();
        Task<StockResponse> CreateStockAsync(StockRequest objRequest);
        Task<StockResponse> GetStockByIdAsync(Guid id);
        Task DeleteStockById(Guid id);
        Task<StockResponse> EditStockByIdAsync(Guid id, StockRequest objRequest);
    }
}
