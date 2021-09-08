using System;
namespace vefast_src.Infrastructure.Repositories.Stock
{
    using vefast_src.Domain.Repositories.Stock;
    using vefast_src.Domain.Entities.Stock;
    public class StockRepositoryEF : GenericRepository<Stock>, IStockRepository
    {
        public StockRepositoryEF(VefastDataContext context)
        : base(context)
        {
        }
    }
}
