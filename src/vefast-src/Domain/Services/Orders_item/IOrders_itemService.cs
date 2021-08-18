using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vefast_src.DTO.Orders_item;

namespace vefast_src.Domain.Services.Orders_item
{
    public interface IOrders_itemService
    {
        IEnumerable<Orders_itemResponse> GetAllOrders_item();
        Task<Orders_itemResponse> CreateOrders_itemAsync(Orders_itemRequest objRequest);
        Task<Orders_itemResponse> GetOrders_itemByIdAsync(Guid id);
        Task DeleteOrders_itemById(Guid id);
        Task<Orders_itemResponse> EditOrders_itemByIdAsync(Guid id, Orders_itemRequest objRequest);
    }
}
