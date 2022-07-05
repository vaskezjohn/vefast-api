
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Entities.OrderItems;
using vefast_src.Domain.Repositories.OrderItems;
using vefast_src.Domain.Services.OrderItems;
using vefast_src.DTO.OrdersItem;

namespace vefast_api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemsService _ordersItemService;
        private readonly IOrderItemsRepository _ordersItemRepository;

        public OrderItemsController(IOrderItemsService ordersItemService, IOrderItemsRepository ordersItemRepository)
        {
            _ordersItemService = ordersItemService;
            _ordersItemRepository = ordersItemRepository;
        }

        [HttpGet]
        [EnableQuery()]
        [Route("/odata/[controller]")]
        public IQueryable<OrderItems> Get()
        {
            return _ordersItemRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrdersItemByIdAsync([FromRoute] string id)
        {
            try
            {
                Guid g = Guid.NewGuid();

                var ordersItem = await _ordersItemService.GetOrdersItemByIdAsync(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { data = ordersItem });

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
        public async Task<IActionResult> CreateOrdersItemAsync([FromBody] OrdersItemRequest obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var ordersItem = await _ordersItemService.CreateOrdersItemAsync(obj);
                    return StatusCode(StatusCodes.Status201Created, new { data = ordersItem });
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
        public IActionResult DeleteordersItemCentroById([FromRoute] string id)
        {
            try
            {
                _ordersItemService.DeleteOrdersItemById(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { Message = "El item fue borrado con éxito." });

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
        public async Task<IActionResult> EditOrdersItemByIdAsync([FromRoute] string id, [FromBody] OrdersItemRequest obj)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var prestador = await _ordersItemService.EditOrdersItemByIdAsync(new Guid(id), obj);

                    return StatusCode(StatusCodes.Status200OK,
                                    new
                                    {
                                        Message = "El item fue actualizado con éxito.",
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
