using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Exceptions.Orders;
using vefast_src.Domain.Repositories.Orders;
using vefast_src.DTO.Orders;

namespace vefast_src.Domain.Services.Orders
{
    public class OrdersService : IOrdersService
    {
        private readonly IMapper _mapper;
        private readonly IOrdersRepository _ordersRepository;

        public OrdersService(IMapper mapper, IOrdersRepository ordersRepository)
        {
            this._mapper = mapper;
            this._ordersRepository = ordersRepository;
        }

        //private string GenerateCodigoVEFAST()
        //{
        //    string lastCode = this._ordersRepository.GetAll().OrderByDescending(x => x.InsertDate).OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();
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
        public IEnumerable<OrdersResponse> GetAllOrders()
        {
            return _mapper.Map<IEnumerable<OrdersResponse>>(_ordersRepository.GetAll());
        }

        public async Task<OrdersResponse> CreateOrdersAsync(OrdersRequest objRequest)
        {
            var orders = _mapper.Map<Entities.Orders.Orders>(objRequest);
            _ordersRepository.Add(orders);

            try
            {
                await _ordersRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<OrdersResponse>(orders);
        }

        public async Task<OrdersResponse> GetOrdersByIdAsync(Guid id)
        {
            var orders = await _ordersRepository.GetByIDAsync(id);
            if (orders == null)
            {
                throw new OrdersNotFoundException("Orden no encontrada.");
            }

            return _mapper.Map<OrdersResponse>(orders);
        }

        public async Task DeleteOrdersById(Guid id)
        {
            var orders = _ordersRepository.GetByID(id);

            if (orders == null)
            {
                throw new OrdersNotFoundException("Orden no encontrada.");
                
            }

            _ordersRepository.Delete(orders);
            await _ordersRepository.SaveAsync();
        }

        public async Task<OrdersResponse> EditOrdersByIdAsync(Guid id, OrdersRequest objRequest)
        {
            var orders = await _ordersRepository.GetByIDAsync(id);

            if (orders == null)
            {
                throw new OrdersNotFoundException("Orden no encontrada.");
            }

            orders.bill_no = objRequest.bill_no;
            orders.customer_name = objRequest.customer_name;
            orders.customer_address = objRequest.customer_address;
            orders.customer_phone = objRequest.customer_phone;
            orders.date_time = objRequest.date_time;
            orders.gross_amount = objRequest.gross_amount;
            orders.service_charge_rate = objRequest.service_charge_rate;
            orders.service_charge = objRequest.service_charge;
            orders.vat_charge_rate = objRequest.vat_charge_rate;
            orders.vat_charge = objRequest.vat_charge;
            orders.net_amount = objRequest.net_amount;
            orders.discount = objRequest.discount;
            orders.paid_status = objRequest.paid_status;
            orders.users_id = objRequest.users_id;
            orders.orders_item_id = objRequest.orders_item_id;

            _ordersRepository.Update(orders);
            await _ordersRepository.SaveAsync();

            return _mapper.Map<OrdersResponse>(orders);
        }
    }
}
