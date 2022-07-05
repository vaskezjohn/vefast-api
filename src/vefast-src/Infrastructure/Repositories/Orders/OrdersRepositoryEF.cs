using System;
namespace vefast_src.Infrastructure.Repositories.Orders
{
    using vefast_src.Domain.Repositories.Orders;
    using vefast_src.Domain.Entities.Orders;

    public class OrdersRepositoryEF : GenericRepository<Orders>, IOrdersRepository
    {
        public OrdersRepositoryEF(VefastDataContext context)
         : base(context)
        {
        }
    }
}
