using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Exceptions.OrdersItem;
using vefast_src.Domain.Repositories.OrdersItem;
using vefast_src.DTO.OrdersItem;


namespace vefast_src.Domain.Services.OrdersItem
{
    public class OrdersItemService : IOrdersItemService
    {
        private readonly IMapper _mapper;
        private readonly IOrdersItemRepository _ordersItemRepository;

        public OrdersItemService(IMapper mapper, IOrdersItemRepository orders_itemRepository)
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
        public IEnumerable<OrdersItemResponse> GetAllOrdersItem()
        {
            return _mapper.Map<IEnumerable<OrdersItemResponse>>(_ordersItemRepository.GetAll());
        }

        public async Task<OrdersItemResponse> CreateOrdersItemAsync(OrdersItemRequest objRequest)
        {
            var orders_item = _mapper.Map<Entities.OrdersItem.OrdersItem>(objRequest);
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
                throw new OrdersItemNotFoundException("Numero de orden no encontrada.");
            }

            return _mapper.Map<OrdersItemResponse>(orders_item);
        }

        public async Task DeleteOrdersItemById(Guid id)
        {
            var orders_item = _ordersItemRepository.GetByID(id);

            if (orders_item == null)
            {
                throw new OrdersItemNotFoundException("Numero de orden no encontrada.");
            }

            _ordersItemRepository.Delete(orders_item);
            await _ordersItemRepository.SaveAsync();
        }

        public async Task<OrdersItemResponse> EditOrdersItemByIdAsync(Guid id, OrdersItemRequest objRequest)
        {
            var orders_item = await _ordersItemRepository.GetByIDAsync(id);

            if (orders_item == null)
            {
                throw new OrdersItemNotFoundException("Numero de orden no encontrada.");
            }

            orders_item.order_id = objRequest.order_id;
            orders_item.product_id = objRequest.product_id;
            orders_item.quantity = objRequest.quantity;
            orders_item.rate = objRequest.rate;
            orders_item.amount = objRequest.amount;


            _ordersItemRepository.Update(orders_item);
            await _ordersItemRepository.SaveAsync();

            return _mapper.Map<OrdersItemResponse>(orders_item);
        }
    }
}
