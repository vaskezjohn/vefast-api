
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Entities.Brands;
using vefast_src.Domain.Repositories.Brands;
using vefast_src.Domain.Services.Brands;
using vefast_src.DTO.Brands;

namespace vefast_api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BrandsController : ControllerBase
    {     
        private readonly IBrandsService _brandsService;
        private readonly IBrandsRepository _brandsRepository;

        public BrandsController(IBrandsService brandsService, IBrandsRepository brandsRepository)
        {
            _brandsService = brandsService;
            _brandsRepository = brandsRepository;
        }

        [HttpGet]
        [EnableQuery()]
        [Route("/odata/[controller]")]
        public IQueryable<Brands> Get()
        {
            return _brandsRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandsByIdAsync([FromRoute] string id)
        {
            try
            {
                Guid g = Guid.NewGuid();

                var brands = await _brandsService.GetBrandsByIdAsync(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { data = brands });

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
        public async Task<IActionResult> CreateBrandsAsync([FromBody] BrandsRequest obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var brands = await _brandsService.CreateBrandsAsync(obj);
                    return StatusCode(StatusCodes.Status201Created, new { data = brands });
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
        public IActionResult DeletebrandsCentroById([FromRoute] string id)
        {
            try
            {
                _brandsService.DeleteBrandsById(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { Message = "La marca fue borrado con éxito." });

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
        public async Task<IActionResult> EditBrandsByIdAsync([FromRoute] string id, [FromBody] BrandsRequest obj)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var prestador = await _brandsService.EditBrandsByIdAsync(new Guid(id), obj);

                    return StatusCode(StatusCodes.Status200OK,
                                    new
                                    {
                                        Message = "La marca fue actualizada con éxito.",
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

