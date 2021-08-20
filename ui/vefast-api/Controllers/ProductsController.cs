using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Entities.Products;
using vefast_src.Domain.Repositories.Products;
using vefast_src.Domain.Services.Products;
using vefast_src.DTO.Products;

namespace vefast_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        private readonly IProductsRepository _productsRepository;

        public ProductsController(IProductsService productsService, IProductsRepository productsRepository)
        {
            _productsService = productsService;
            _productsRepository = productsRepository;                        
        }

        [HttpGet]
        [EnableQuery()]
        [Route("odata/[controller]")]
        public IQueryable<Products> Get()
        {
            return _productsRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyByIdAsync([FromRoute] string id)
        {
            try
            {
                Guid g = Guid.NewGuid();

                var products = await _productsService.GetProductsByIdAsync(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { data = products });

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
        public async Task<IActionResult> CreateProductsAsync([FromBody] ProductsRequest obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var company = await _productsService.CreateProductsAsync(obj);
                    return StatusCode(StatusCodes.Status201Created, new { data = company });
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
        public IActionResult DeleteproductsCentroById([FromRoute] string id)
        {
            try
            {
                _productsService.DeleteProductsById(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { Message = "El productp fue borrado con éxito." });

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
        public async Task<IActionResult> EditProductsByIdAsync([FromRoute] string id, [FromBody] ProductsRequest obj)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var prestador = await _productsService.EditProductsByIdAsync(new Guid(id), obj);

                    return StatusCode(StatusCodes.Status200OK,
                                    new
                                    {
                                        Message = "El producto fue actualizada con éxito.",
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
