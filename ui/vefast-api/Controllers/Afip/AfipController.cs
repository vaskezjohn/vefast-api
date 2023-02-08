using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using vefast_src.Domain.Services.Categories;
using vefast_src.Domain.Services.Afip;

namespace vefast_api.Controllers.Afip
{
    [Route("api/[controller]")]
    [ApiController]
    public class AfipController : ControllerBase
    {
        private readonly IAfipService _afipService;

        public AfipController(IAfipService afipService)
        {
            _afipService = afipService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetCategoriesByIdAsync()
        {
            try
            {
                await _afipService.GeneratEInvoice();

                return StatusCode(StatusCodes.Status200OK);

            }
            catch (NullReferenceException)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { Message = "La solicitud tiene un formato incorrecto" });
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }
    }
}
