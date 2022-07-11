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

            orders.BillNo = objRequest.BillNo;
            orders.CustomerName = objRequest.CustomerName;
            orders.CustomerAddress = objRequest.CustomerAddress;
            orders.CustomerPhone = objRequest.CustomerPhone;
            orders.DateTimeIn = objRequest.DateTimeIn;
            orders.GrossAmount = objRequest.GrossAmount;
            orders.ServiceChargeRate = objRequest.ServiceChargeRate;
            orders.ServiceCharge = objRequest.ServiceCharge;
            orders.VatChargeRate = objRequest.VatChargeRate;
            orders.VatCharge = objRequest.VatCharge;
            orders.NetAmount = objRequest.NetAmount;
            orders.Discount = objRequest.Discount;
            orders.PaidStatus = objRequest.PaidStatus;
            orders.ID_User = objRequest.ID_User;
            orders.ID_OrderItem = objRequest.ID_OrderItem;

            _ordersRepository.Update(orders);
            await _ordersRepository.SaveAsync();

            return _mapper.Map<OrdersResponse>(orders);
        }
    }
}
