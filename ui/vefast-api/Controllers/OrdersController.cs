using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Entities.Orders;
using vefast_src.Domain.Repositories.Orders;
using vefast_src.Domain.Services.Orders;
using vefast_src.DTO.Orders;

namespace vefast_api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        private readonly IOrdersRepository _ordersRepository;

        public OrdersController(IOrdersService ordersService, IOrdersRepository ordersRepository)
        {
            _ordersService = ordersService;
            _ordersRepository = ordersRepository;
        }

        [HttpGet]
        [EnableQuery()]
        [Route("/odata/[controller]")]
        public IQueryable<Orders> Get()
        {
            return _ordersRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrdersByIdAsync([FromRoute] string id)
        {
            try
            {
                Guid g = Guid.NewGuid();

                var orders = await _ordersService.GetOrdersByIdAsync(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { data = orders });

            }
            catch (NullReferenceException)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { Message = "La solicitud tiene un formato incorrecto" });
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = e.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrdersAsync([FromBody] OrdersRequest obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var orders = await _ordersService.CreateOrdersAsync(obj);
                    return StatusCode(StatusCodes.Status201Created, new { data = orders });
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            catch (NullReferenceException)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, new { Message = "La solicitud tiene un formato incorrecto" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = e.Message });
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteordersCentroById([FromRoute] string id)
        {
            try
            {
                _ordersService.DeleteOrdersById(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { Message = "La orden fue borrada con éxito." });

            }
            catch (NullReferenceException)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, new { Message = "El modelo es inválido" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = e.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditOrdersByIdAsync([FromRoute] string id, [FromBody] OrdersRequest obj)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var prestador = await _ordersService.EditOrdersByIdAsync(new Guid(id), obj);

                    return StatusCode(StatusCodes.Status200OK,
                                    new
                                    {
                                        Message = "La orden fue actualizada con éxito.",
                                        Data = prestador
                                    });

                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            catch (NullReferenceException)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, new { Message = "El modelo es inválido" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = e.Message });
            }

        }
    }
}
