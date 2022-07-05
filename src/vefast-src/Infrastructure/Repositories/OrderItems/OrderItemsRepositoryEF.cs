using System;
namespace vefast_src.Infrastructure.Repositories.OrderItems
{
    using vefast_src.Domain.Repositories.OrderItems;
    using vefast_src.Domain.Entities.OrderItems;

    public class OrderItemsRepositoryEF : GenericRepository<OrderItems>, IOrderItemsRepository
    {
        public OrderItemsRepositoryEF(VefastDataContext context)
         : base(context)
        {
        }
    }
}
