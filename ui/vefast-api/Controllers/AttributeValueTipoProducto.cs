
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Entities.AttributeValueTipoProducto;
using vefast_src.Domain.Repositories.AttributeValueTipoProducto;
using vefast_src.Domain.Services.AttributeValueTipoProducto;
using vefast_src.DTO.AttributeValueTipoProducto;

namespace vefast_api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AttributeValueTipoProductoController : ControllerBase
    {
        private readonly IAttributeValueTipoProductoService _AttributeValueTipoProductoService;
        private readonly IAttributeValueTipoProductoRepository _AttributeValueTipoProductoRepository;

        public AttributeValueTipoProductoController(IAttributeValueTipoProductoService AttributeValueTipoProductoService, IAttributeValueTipoProductoRepository AttributeValueTipoProductoRepository)
        {
            _AttributeValueTipoProductoService = AttributeValueTipoProductoService;
            _AttributeValueTipoProductoRepository = AttributeValueTipoProductoRepository;
        }

        [HttpGet]
        [EnableQuery()]
        [Route("/odata/[controller]")]
        public IQueryable<AttributeValueTipoProducto> Get()
        {
            return _AttributeValueTipoProductoRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttributeValueTipoProductoByIdAsync([FromRoute] string id)
        {
            try
            {
                Guid g = Guid.NewGuid();

                var AttributeValueTipoProducto = await _AttributeValueTipoProductoService.GetAttributeValueTipoProductoByIdAsync(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { data = AttributeValueTipoProducto });

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
        public async Task<IActionResult> CreateAttributeValueTipoProductoAsync([FromBody] AttributeValueTipoProductoRequest obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var AttributeValueTipoProducto = await _AttributeValueTipoProductoService.CreateAttributeValueTipoProductoAsync(obj);
                    return StatusCode(StatusCodes.Status201Created, new { data = AttributeValueTipoProducto });
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
        public IActionResult DeleteAttributeValueTipoProductoCentroById([FromRoute] string id)
        {
            try
            {
                _AttributeValueTipoProductoService.DeleteAttributeValueTipoProductoById(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { Message = "El atributo fue borrado con éxito." });

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
        public async Task<IActionResult> EditAttributeValueTipoProductoByIdAsync([FromRoute] string id, [FromBody] AttributeValueTipoProductoRequest obj)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var prestador = await _AttributeValueTipoProductoService.EditAttributeValueTipoProductoByIdAsync(new Guid(id), obj);

                    return StatusCode(StatusCodes.Status200OK,
                                    new
                                    {
                                        Message = "El atributo fue actualizado con éxito.",
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
