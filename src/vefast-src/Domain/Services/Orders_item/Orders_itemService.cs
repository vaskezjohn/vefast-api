using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Exceptions.Orders_item;
using vefast_src.Domain.Repositories.Orders_item;
using vefast_src.DTO.Orders_item;

namespace vefast_src.Domain.Services.Orders_item
{
    public class Orders_itemService : IOrders_itemService
    {
        private readonly IMapper _mapper;
        private readonly IOrders_itemRepository _orders_itemRepository;

        public Orders_itemService(IMapper mapper, IOrders_itemRepository orders_itemRepository)
        {
            this._mapper = mapper;
            this._orders_itemRepository = orders_itemRepository;
        }

        //private string GenerateCodigoVEFAST()
        //{
        //    string lastCode = this._orders_itemRepository.GetAll().OrderByDescending(x => x.InsertDate).OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();
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
        public IEnumerable<Orders_itemResponse> GetAllOrders_item()
        {
            return _mapper.Map<IEnumerable<Orders_itemResponse>>(_orders_itemRepository.GetAll());
        }

        public async Task<Orders_itemResponse> CreateOrders_itemAsync(Orders_itemRequest objRequest)
        {
            var orders_item = _mapper.Map<Entities.Orders_item.Orders_item>(objRequest);
            _orders_itemRepository.Add(orders_item);

            try
            {
                await _orders_itemRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<Orders_itemResponse>(orders_item);
        }

        public async Task<Orders_itemResponse> GetOrders_itemByIdAsync(Guid id)
        {
            var orders_item = await _orders_itemRepository.GetByIDAsync(id);
            if (orders_item == null)
            {
                throw new Orders_itemNotFoundException("Numero de orden no encontrada.");
            }

            return _mapper.Map<Orders_itemResponse>(orders_item);
        }

        public async Task DeleteOrders_itemById(Guid id)
        {
            var orders_item = _orders_itemRepository.GetByID(id);

            if (orders_item == null)
            {
                throw new Orders_itemNotFoundException("Numero de orden no encontrada.");
            }

            _orders_itemRepository.Delete(orders_item);
            await _orders_itemRepository.SaveAsync();
        }

        public async Task<Orders_itemResponse> EditOrders_itemByIdAsync(Guid id, Orders_itemRequest objRequest)
        {
            var orders_item = await _orders_itemRepository.GetByIDAsync(id);

            if (orders_item == null)
            {
                throw new Orders_itemNotFoundException("Numero de orden no encontrada.");
            }

            orders_item.order_id = objRequest.order_id;
            orders_item.product_id = objRequest.product_id;
            orders_item.quantity = objRequest.quantity;
            orders_item.rate = objRequest.rate;
            orders_item.amount = objRequest.amount;


            _orders_itemRepository.Update(orders_item);
            await _orders_itemRepository.SaveAsync();

            return _mapper.Map<Orders_itemResponse>(orders_item);
        }
    }
}
