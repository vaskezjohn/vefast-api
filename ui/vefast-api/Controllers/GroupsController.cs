using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Entities.Groups;
using vefast_src.Domain.Repositories.Groups;
using vefast_src.Domain.Services.Groups;
using vefast_src.DTO.Groups;

namespace vefast_api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupsService _groupsService;
        private readonly IGroupsRepository _groupsRepository;

        public GroupsController(IGroupsService groupsService, IGroupsRepository groupsRepository)
        {
            _groupsService = groupsService;
            _groupsRepository = groupsRepository;
        }

        [HttpGet]
        [EnableQuery()]
        [Route("odata/[controller]")]
        public IQueryable<Groups> Get()
        {
            return _groupsRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupsByIdAsync([FromRoute] string id)
        {
            try
            {
                Guid g = Guid.NewGuid();

                var groups = await _groupsService.GetGroupsByIdAsync(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { data = groups });

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
        public async Task<IActionResult> CreateGroupsAsync([FromBody] GroupsRequest obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var groups = await _groupsService.CreateGroupsAsync(obj);
                    return StatusCode(StatusCodes.Status201Created, new { data = groups });
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
        public IActionResult DeletegroupsCentroById([FromRoute] string id)
        {
            try
            {
                _groupsService.DeleteGroupsById(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { Message = "El grupo fue borrado con éxito." });

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
        public async Task<IActionResult> EditGroupsByIdAsync([FromRoute] string id, [FromBody] GroupsRequest obj)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var prestador = await _groupsService.EditGroupsByIdAsync(new Guid(id), obj);

                    return StatusCode(StatusCodes.Status200OK,
                                    new
                                    {
                                        Message = "El grupo fue actualizado con éxito.",
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
