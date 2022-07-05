
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Entities.Attributes;
using vefast_src.Domain.Repositories.Attributes;
using vefast_src.Domain.Services.Attributes;
using vefast_src.DTO.Attributes;

namespace vefast_api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AttributesController : ControllerBase
    {
        private readonly IAttributesService _attributesService;
        private readonly IAttributesRepository _attributesRepository;

        public AttributesController(IAttributesService attributesService, IAttributesRepository attributesRepository)
        {
            _attributesService = attributesService;
            _attributesRepository = attributesRepository;
        }

        [HttpGet]
        [EnableQuery()]
        [Route("/odata/[controller]")]
        public IQueryable<Attributes> Get()
        {
            return _attributesRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttributesByIdAsync([FromRoute] string id)
        {
            try
            {
                Guid g = Guid.NewGuid();

                var attributes = await _attributesService.GetAttributesByIdAsync(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { data = attributes });

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
        public async Task<IActionResult> CreateAttributesAsync([FromBody] AttributesRequest obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var attributes = await _attributesService.CreateAttributesAsync(obj);
                    return StatusCode(StatusCodes.Status201Created, new { data = attributes });
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
        public IActionResult DeleteattributesCentroById([FromRoute] string id)
        {
            try
            {
                _attributesService.DeleteAttributesById(new Guid(id));

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
        public async Task<IActionResult> EditAttributesByIdAsync([FromRoute] string id, [FromBody] AttributesRequest obj)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var prestador = await _attributesService.EditAttributesByIdAsync(new Guid(id), obj);

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
