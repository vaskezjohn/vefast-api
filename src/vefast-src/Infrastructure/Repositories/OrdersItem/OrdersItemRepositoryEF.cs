using System;
namespace vefast_src.Infrastructure.Repositories.OrdersItem
{
    using vefast_src.Domain.Repositories.OrdersItem;
    using vefast_src.Domain.Entities.OrdersItem;

    public class OrdersItemRepositoryEF : GenericRepository<OrdersItem>, IOrdersItemRepository
    {
        public OrdersItemRepositoryEF(VefastDataContext context)
         : base(context)
        {
        }
    }
}
