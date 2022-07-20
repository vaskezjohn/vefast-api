using System;
namespace vefast_src.Infrastructure.Repositories.Stock
{
    using vefast_src.Domain.Repositories.Stock;
    using vefast_src.Domain.Entities.StockDeposits;
    public class StockRepositoryEF : GenericRepository<StockDeposits>, IStockRepository
    {
        public StockRepositoryEF(VefastDataContext context)
        : base(context)
        {
        }
    }
}
