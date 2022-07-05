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

            orders.BillNo = objRequest.bill_no;
            orders.CustomerName = objRequest.customer_name;
            orders.CustomerAddress = objRequest.customer_address;
            orders.CustomerPhone = objRequest.customer_phone;
            orders.DateTimeIn = objRequest.date_time;
            orders.GrossAmount = objRequest.gross_amount;
            orders.ServiceChargeRate = objRequest.service_charge_rate;
            orders.ServiceCharge = objRequest.service_charge;
            orders.VatChargeRate = objRequest.vat_charge_rate;
            orders.VatCharge = objRequest.vat_charge;
            orders.NetAmount = objRequest.net_amount;
            orders.Discount = objRequest.discount;
            orders.PaidStatus = objRequest.paid_status;
            orders.ID_User = objRequest.users_id;
            orders.ID_OrderItem = objRequest.orders_item_id;

            _ordersRepository.Update(orders);
            await _ordersRepository.SaveAsync();

            return _mapper.Map<OrdersResponse>(orders);
        }
    }
}
