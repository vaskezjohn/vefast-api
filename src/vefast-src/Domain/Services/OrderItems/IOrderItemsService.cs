using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vefast_src.DTO.OrdersItem;

namespace vefast_src.Domain.Services.OrderItems
{
    public interface IOrderItemsService
    {
        IEnumerable<OrdersItemResponse> GetAllOrdersItem();
        Task<OrdersItemResponse> CreateOrdersItemAsync(OrdersItemRequest objRequest);
        Task<OrdersItemResponse> GetOrdersItemByIdAsync(Guid id);
        Task DeleteOrdersItemById(Guid id);
        Task<OrdersItemResponse> EditOrdersItemByIdAsync(Guid id, OrdersItemRequest objRequest);
    }
}
