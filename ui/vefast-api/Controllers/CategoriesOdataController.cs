using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System;
using System.Linq;
using vefast_src.Domain.Entities.Categories;
using vefast_src.Domain.Repositories.Categories;

namespace vefast_api.Controllers
{
      public class CategoriesOdataController : ODataController
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesOdataController(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        [EnableQuery()]
        public ActionResult<IQueryable<Categories>> Get()
        {
            try
            {
                IQueryable<Categories> categories = _categoriesRepository.GetAll();

                if (categories.Count() == 0)
                    return NotFound();

                return Ok(categories);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = e.Message });
            }
        }

    }
}
