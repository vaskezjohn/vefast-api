using System;
namespace vefast_src.Infrastructure.Repositories.Orders_item
{
    using vefast_src.Domain.Repositories.Orders_item;
    using vefast_src.Domain.Entities.Orders_item;

    public class Orders_itemRepositoryEF : GenericRepository<Orders_item>, IOrders_itemRepository
    {
        public Orders_itemRepositoryEF(VefastDataContext context)
         : base(context)
        {
        }
    }
}
