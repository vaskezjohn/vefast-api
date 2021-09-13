using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Entities.Categories;
using vefast_src.Domain.Repositories.Categories;
using vefast_src.Domain.Services.Categories;
using vefast_src.DTO.Categories;

namespace vefast_api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesController(ICategoriesService categoriesService, ICategoriesRepository categoriesRepository)
        {
            _categoriesService = categoriesService;
            _categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        [EnableQuery()]
        [Route("/odata/[controller]")]
        public IQueryable<Categories> Get()
        {
            return _categoriesRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriesByIdAsync([FromRoute] string id)
        {
            try
            {
                Guid g = Guid.NewGuid();

                var categories = await _categoriesService.GetCategoriesByIdAsync(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { data = categories });

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
        public async Task<IActionResult> CreateCategoriesAsync([FromBody] CategoriesRequest obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var categories = await _categoriesService.CreateCategoriesAsync(obj);
                    return StatusCode(StatusCodes.Status201Created, new { data = categories });
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
        public IActionResult DeletecategoriesCentroById([FromRoute] string id)
        {
            try
            {
                _categoriesService.DeleteCategoriesById(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { Message = "La categoria fue borrado con éxito." });

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
        public async Task<IActionResult> EditCategoriesByIdAsync([FromRoute] string id, [FromBody] CategoriesRequest obj)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var prestador = await _categoriesService.EditCategoriesByIdAsync(new Guid(id), obj);

                    return StatusCode(StatusCodes.Status200OK,
                                    new
                                    {
                                        Message = "La categoria fue actualizada con éxito.",
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
