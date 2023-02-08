namespace vefast_api.Controllers.Users
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.OData.Query;
    using System.Linq;
    using vefast_src.Domain.Entities.Users;
    using System;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;

    [Authorize]
    public class UsersOdataController : ControllerBase
    {
        private readonly UserManager<Users> _userManager;

        public UsersOdataController(UserManager<Users> userManager)
        {
            _userManager = userManager;
        }

        [EnableQuery()]
        [HttpGet]
        public ActionResult<IQueryable<Users>> Get()
        {
            try
            {
                IQueryable<Users> Users = _userManager.Users;

                return Ok(Users);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "Error interno del sistema"
                });
            }
        }

    }
}
