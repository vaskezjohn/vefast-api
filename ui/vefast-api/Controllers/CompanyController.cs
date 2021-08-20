using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Entities.Company;
using vefast_src.Domain.Repositories.Company;
using vefast_src.Domain.Services.Company;
using vefast_src.DTO.Company;

namespace vefast_api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyService companyService, ICompanyRepository companyRepository)
        {
            _companyService = companyService;
            _companyRepository = companyRepository;
        }

        [HttpGet]
        [EnableQuery()]
        [Route("odata/[controller]")]
        public IQueryable<Company> Get()
        {
            return _companyRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyByIdAsync([FromRoute] string id)
        {
            try
            {
                Guid g = Guid.NewGuid();

                var company = await _companyService.GetCompanyByIdAsync(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { data = company });

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
        public async Task<IActionResult> CreateCompanyAsync([FromBody] CompanyRequest obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var company = await _companyService.CreateCompanyAsync(obj);
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
        public IActionResult DeletecompanyCentroById([FromRoute] string id)
        {
            try
            {
                _companyService.DeleteCompanyById(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { Message = "La empresa fue borrada con éxito." });

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
        public async Task<IActionResult> EditCompanyByIdAsync([FromRoute] string id, [FromBody] CompanyRequest obj)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var prestador = await _companyService.EditCompanyByIdAsync(new Guid(id), obj);

                    return StatusCode(StatusCodes.Status200OK,
                                    new
                                    {
                                        Message = "La empresa fue actualizada con éxito.",
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
