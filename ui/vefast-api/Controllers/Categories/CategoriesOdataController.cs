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
    public class CategoriesOdataController : ODataController
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesOdataController(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        [Authorize]
        [EnableQuery()]
        [HttpGet]
        public ActionResult<IQueryable<Categories>> Get()
        {
            try
            {
                IQueryable<Categories> categories = _categoriesRepository.GetAll();

                //if (categories.Count() == 0)
                //    return Ok(categories);

                return Ok(categories);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

    }
}
