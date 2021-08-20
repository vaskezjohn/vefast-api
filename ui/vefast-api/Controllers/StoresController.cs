using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Entities.Stores;
using vefast_src.Domain.Repositories.Stores;
using vefast_src.Domain.Services.Stores;
using vefast_src.DTO.Stores;

namespace vefast_api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class StoresController : ControllerBase
    {
        private readonly IStoresService _storesService;
        private readonly IStoresRepository _storesRepository;

        public StoresController(IStoresService storesService, IStoresRepository storesRepository)
        {
            _storesService = storesService;
            _storesRepository = storesRepository;
        }

        [HttpGet]
        [EnableQuery()]
        [Route("odata/[controller]")]
        public IQueryable<Stores> Get()
        {
            return _storesRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStoresByIdAsync([FromRoute] string id)
        {
            try
            {
                Guid g = Guid.NewGuid();

                var stores = await _storesService.GetStoresByIdAsync(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { data = stores });

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
        public async Task<IActionResult> CreateStoresAsync([FromBody] StoresRequest obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var stores = await _storesService.CreateStoresAsync(obj);
                    return StatusCode(StatusCodes.Status201Created, new { data = stores });
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
        public IActionResult DeletestoresCentroById([FromRoute] string id)
        {
            try
            {
                _storesService.DeleteStoresById(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { Message = "La tienda fue borrada con éxito." });

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
        public async Task<IActionResult> EditStoresByIdAsync([FromRoute] string id, [FromBody] StoresRequest obj)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var prestador = await _storesService.EditStoresByIdAsync(new Guid(id), obj);

                    return StatusCode(StatusCodes.Status200OK,
                                    new
                                    {
                                        Message = "La tienda fue actualizada con éxito.",
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
