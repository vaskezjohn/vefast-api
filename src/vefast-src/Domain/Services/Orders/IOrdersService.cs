using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vefast_src.DTO.Orders;

namespace vefast_src.Domain.Services.Orders
{
    public interface IOrdersService
    {
        IEnumerable<OrdersResponse> GetAllOrders();
        Task<OrdersResponse> CreateOrdersAsync(OrdersRequest objRequest);
        Task<OrdersResponse> GetOrdersByIdAsync(Guid id);
        Task DeleteOrdersById(Guid id);
        Task<OrdersResponse> EditOrdersByIdAsync(Guid id, OrdersRequest objRequest);
    }
 
}
