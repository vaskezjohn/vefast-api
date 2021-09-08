using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Entities.Stock;
using vefast_src.Domain.Repositories.Stock;
using vefast_src.Domain.Services.Stock;
using vefast_src.DTO.Stock;

namespace vefast_api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IStockService _StockService;
        private readonly IStockRepository _StockRepository;

        public StockController(IStockService StockService, IStockRepository StockRepository)
        {
            _StockService = StockService;
            _StockRepository = StockRepository;
        }

        [HttpGet]
        [EnableQuery()]
        [Route("odata/[controller]")]
        public IQueryable<Stock> Get()
        {
            return _StockRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStockByIdAsync([FromRoute] string id)
        {
            try
            {
                Guid g = Guid.NewGuid();

                var Stock = await _StockService.GetStockByIdAsync(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { data = Stock });

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
        public async Task<IActionResult> CreateStockAsync([FromBody] StockRequest obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Stock = await _StockService.CreateStockAsync(obj);
                    return StatusCode(StatusCodes.Status201Created, new { data = Stock });
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
        public IActionResult DeleteStockCentroById([FromRoute] string id)
        {
            try
            {
                _StockService.DeleteStockById(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { Message = "El stock fue borrado con éxito." });

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
        public async Task<IActionResult> EditStockByIdAsync([FromRoute] string id, [FromBody] StockRequest obj)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var prestador = await _StockService.EditStockByIdAsync(new Guid(id), obj);

                    return StatusCode(StatusCodes.Status200OK,
                                    new
                                    {
                                        Message = "El stock fue actualizado con éxito.",
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
