
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Entities.UserGroups;
using vefast_src.Domain.Repositories.UserGroups;
using vefast_src.Domain.Services.UserGroups;
using vefast_src.DTO.UserGroups;

namespace vefast_api.Controllers
{
    public class UserGroupsController : ControllerBase
    {
        private readonly IUserGroupsService _userGroupService;
        private readonly IUserGroupsRepository _userGroupRepository;

        public UserGroupsController(IUserGroupsService userGroupService, IUserGroupsRepository userGroupRepository)
        {
            _userGroupService = userGroupService;
            _userGroupRepository = userGroupRepository;
        }

        [HttpGet]
        [EnableQuery()]
        [Route("/odata/[controller]")]
        public IQueryable<UserGroups> Get()
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
        public async Task<IActionResult> CreateUserGroupAsync([FromBody] UserGroupsRequest obj)
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
        public async Task<IActionResult> EditUserGroupByIdAsync([FromRoute] string id, [FromBody] UserGroupsRequest obj)
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
