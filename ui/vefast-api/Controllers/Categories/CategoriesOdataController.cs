namespace vefast_api.Controllers.Categories
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.OData.Query;
    using Microsoft.AspNetCore.OData.Routing.Controllers;
    using System;
    using System.Linq;
    using vefast_src.Domain.Repositories.Categories;
    using vefast_src.Domain.Entities.Categories;
    using Microsoft.Extensions.Logging;
    using System.Security.Claims;
    using vefast_src.Domain.Constants;

    [Authorize]
    public class CategoriesOdataController : ODataController
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly ILogger<CategoriesOdataController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoriesOdataController(ICategoriesRepository categoriesRepository, ILogger<CategoriesOdataController> logger, IHttpContextAccessor httpContextAccessor)
        {
            this._categoriesRepository = categoriesRepository;
            this._logger = logger;
            this._httpContextAccessor = httpContextAccessor;
        }

       
        [EnableQuery()]
        [HttpGet]
        public ActionResult<IQueryable<Categories>> Get()
        {
            try
            {
                var aux = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Company).Value;
                IQueryable<Categories> categories = _categoriesRepository.GetAll().Where(w => w.Active==false);

                //if (categories.Count() == 0)
                //    return Ok(categories);

                _logger.LogInformation("Se genero ok");

                return Ok(categories);

            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error odata categorias");
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "Error interno del sistema"
                });
            }
        }

    }
}
