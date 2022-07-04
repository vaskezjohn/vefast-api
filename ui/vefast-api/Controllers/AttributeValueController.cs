﻿
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Entities.AttributeValue;
using vefast_src.Domain.Repositories.AttributeValue;
using vefast_src.Domain.Services.AttributeValue;
using vefast_src.DTO.AttributeValue;

namespace vefast_api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AttributeValueController : ControllerBase
    {
        private readonly IAttributeValueService _attributeValueService;
        private readonly IAttributeValueRepository _attributeValueRepository;

        public AttributeValueController(IAttributeValueService attributeValueService, IAttributeValueRepository attributeValueRepository)
        {
            _attributeValueService = attributeValueService;
            _attributeValueRepository = attributeValueRepository;
        }

        [HttpGet]
        [EnableQuery()]
        [Route("/odata/[controller]")]
        public IQueryable<AttributeValue> Get()
        {
            return _attributeValueRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttributeValueByIdAsync([FromRoute] string id)
        {
            try
            {
                Guid g = Guid.NewGuid();

                var attributeValue = await _attributeValueService.GetAttributeValueByIdAsync(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { data = attributeValue });

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
        public async Task<IActionResult> CreateAttributeValueAsync([FromBody] AttributeValueRequest obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var attributeValue = await _attributeValueService.CreateAttributeValueAsync(obj);
                    return StatusCode(StatusCodes.Status201Created, new { data = attributeValue });
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
        public IActionResult DeleteattributeValueCentroById([FromRoute] string id)
        {
            try
            {
                _attributeValueService.DeleteAttributeValueById(new Guid(id));

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
        public async Task<IActionResult> EditAttributeValueByIdAsync([FromRoute] string id, [FromBody] AttributeValueRequest obj)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var prestador = await _attributeValueService.EditAttributeValueByIdAsync(new Guid(id), obj);

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
