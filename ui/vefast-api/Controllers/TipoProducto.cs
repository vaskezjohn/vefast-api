using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Entities.TipoProducto;
using vefast_src.Domain.Repositories.TipoProducto;
using vefast_src.Domain.Services.TipoProducto;
using vefast_src.DTO.TipoProducto;
namespace vefast_api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TipoProductoController : ControllerBase
    {
        private readonly ITipoProductoService _TipoProductoService;
        private readonly ITipoProductoRepository _TipoProductoRepository;

        public TipoProductoController(ITipoProductoService TipoProductoService, ITipoProductoRepository TipoProductoRepository)
        {
            _TipoProductoService = TipoProductoService;
            _TipoProductoRepository = TipoProductoRepository;
        }

        [HttpGet]
        [EnableQuery()]
        [Route("odata/[controller]")]
        public IQueryable<TipoProducto> Get()
        {
            return _TipoProductoRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoProductoByIdAsync([FromRoute] string id)
        {
            try
            {
                Guid g = Guid.NewGuid();

                var TipoProducto = await _TipoProductoService.GetTipoProductoByIdAsync(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { data = TipoProducto });

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
        public async Task<IActionResult> CreateTipoProductoAsync([FromBody] TipoProductoRequest obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var TipoProducto = await _TipoProductoService.CreateTipoProductoAsync(obj);
                    return StatusCode(StatusCodes.Status201Created, new { data = TipoProducto });
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
        public IActionResult DeleteTipoProductoCentroById([FromRoute] string id)
        {
            try
            {
                _TipoProductoService.DeleteTipoProductoById(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { Message = "El tipo de producto fue borrado con éxito." });

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
        public async Task<IActionResult> EditTipoProductoByIdAsync([FromRoute] string id, [FromBody] TipoProductoRequest obj)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var prestador = await _TipoProductoService.EditTipoProductoByIdAsync(new Guid(id), obj);

                    return StatusCode(StatusCodes.Status200OK,
                                    new
                                    {
                                        Message = "El tipo de producto fue actualizado con éxito.",
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
