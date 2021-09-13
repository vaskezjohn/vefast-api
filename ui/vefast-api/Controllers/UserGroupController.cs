using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Entities.UserGroup;
using vefast_src.Domain.Repositories.UserGroup;
using vefast_src.Domain.Services.UserGroup;
using vefast_src.DTO.UserGroup;

namespace vefast_api.Controllers
{
    public class UserGroupController : ControllerBase
    {
        private readonly IUserGroupService _userGroupService;
        private readonly IUserGroupRepository _userGroupRepository;

        public UserGroupController(IUserGroupService userGroupService, IUserGroupRepository userGroupRepository)
        {
            _userGroupService = userGroupService;
            _userGroupRepository = userGroupRepository;
        }

        [HttpGet]
        [EnableQuery()]
        [Route("/odata/[controller]")]
        public IQueryable<UserGroup> Get()
        {
            return _userGroupRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserGroupByIdAsync([FromRoute] string id)
        {
            try
            {
                Guid g = Guid.NewGuid();

                var userGroup = await _userGroupService.GetUserGroupByIdAsync(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { data = userGroup });

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
        public async Task<IActionResult> CreateUserGroupAsync([FromBody] UserGroupRequest obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userGroup = await _userGroupService.CreateUserGroupAsync(obj);
                    return StatusCode(StatusCodes.Status201Created, new { data = userGroup });
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
        public IActionResult DeleteuserGroupCentroById([FromRoute] string id)
        {
            try
            {
                _userGroupService.DeleteUserGroupById(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { Message = "El grupo de usuarios fue borrado con éxito." });

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
        public async Task<IActionResult> EditUserGroupByIdAsync([FromRoute] string id, [FromBody] UserGroupRequest obj)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var prestador = await _userGroupService.EditUserGroupByIdAsync(new Guid(id), obj);

                    return StatusCode(StatusCodes.Status200OK,
                                    new
                                    {
                                        Message = "El grupo de usuarios fue actualizado con éxito.",
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
