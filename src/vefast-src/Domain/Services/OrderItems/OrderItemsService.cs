using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Entities.OrderItems;
using vefast_src.Domain.Exceptions.OrderItems;
using vefast_src.Domain.Repositories.OrderItems;
using vefast_src.DTO.OrdersItem;


namespace vefast_src.Domain.Services.OrderItems
{
    public class OrderItemsService : IOrderItemsService
    {
        private readonly IMapper _mapper;
        private readonly IOrderItemsRepository _ordersItemRepository;

        public OrderItemsService(IMapper mapper, IOrderItemsRepository orders_itemRepository)
        {
            this._mapper = mapper;
            this._ordersItemRepository = orders_itemRepository;
        }

        //private string GenerateCodigoVEFAST()
        //{
        //    string lastCode = this._ordersItemRepository.GetAll().OrderByDescending(x => x.InsertDate).OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();
        //    if (!String.IsNullOrEmpty(lastCode))
        //    {
        //        int number = Convert.ToInt32(lastCode[4..]);

        //        return "CLI-" + (number + 1);
        //    }
        //    else
        //    {
        //        return "CLI-1";
        //    }
        //}
        public ICollection<OrdersItemResponse> GetAllOrdersItem()
        {
            return _mapper.Map<ICollection<OrdersItemResponse>>(_ordersItemRepository.GetAll());
        }

        public async Task<OrdersItemResponse> CreateOrdersItemAsync(OrdersItemRequest objRequest)
        {
            var orders_item = _mapper.Map<Entities.OrderItems.OrderItems>(objRequest);
            _ordersItemRepository.Add(orders_item);

            try
            {
                await _ordersItemRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<OrdersItemResponse>(orders_item);
        }

        public async Task<OrdersItemResponse> GetOrdersItemByIdAsync(Guid id)
        {
            var orders_item = await _ordersItemRepository.GetByIDAsync(id);
            if (orders_item == null)
            {
                throw new OrderItemsNotFoundException("Numero de orden no encontrada.");
            }

            return _mapper.Map<OrdersItemResponse>(orders_item);
        }

        public async Task DeleteOrdersItemById(Guid id)
        {
            var orders_item = _ordersItemRepository.GetByID(id);

            if (orders_item == null)
            {
                throw new OrderItemsNotFoundException("Numero de orden no encontrada.");
            }

            _ordersItemRepository.Delete(orders_item);
            await _ordersItemRepository.SaveAsync();
        }

        public async Task<OrdersItemResponse> EditOrdersItemByIdAsync(Guid id, OrdersItemRequest objRequest)
        {
            var orders_item = await _ordersItemRepository.GetByIDAsync(id);

            if (orders_item == null)
            {
                throw new OrderItemsNotFoundException("Numero de orden no encontrada.");
            }

            orders_item.ID_Order = objRequest.ID_Order;
            orders_item.ID_Product = objRequest.ID_Product;
            orders_item.Quantity = objRequest.Quantity;
            orders_item.Rate = objRequest.Rate;
            orders_item.Amount = objRequest.Amount;


            _ordersItemRepository.Update(orders_item);
            await _ordersItemRepository.SaveAsync();

            return _mapper.Map<OrdersItemResponse>(orders_item);
        }
    }
}
