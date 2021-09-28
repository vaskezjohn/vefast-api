using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Services.User;
using vefast_src.Domain.Repositories.Users;
using Microsoft.AspNet.OData;
using vefast_src.Domain.Entities.Users;
using vefast_src.DTO.Users;

namespace vefast_api.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersService usersService, IUsersRepository usersRepository)
        {
            _usersService = usersService;
            _usersRepository = usersRepository;
        }

        [HttpGet]
        [EnableQuery()]
        [Route("odata/[controller]")]
        public IQueryable<Users> Get()
        {
            return _usersRepository.GetAll();
        }

        public async Task<IActionResult> GetStoresByIdAsync([FromRoute] string id)
        {
            try
            {
                Guid g = Guid.NewGuid();

                var users = await _usersService.GetUsersByIdAsync(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { data = users });

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
        public async Task<IActionResult> CreateUsersAsync([FromBody] UsersRequest obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var stores = await _usersService.CreateUsersAsync(obj);
                    return StatusCode(StatusCodes.Status201Created, new { data = stores });
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
        public IActionResult DeleteusersCentroById([FromRoute] string id)
        {
            try
            {
                _usersService.DeleteUsersById(new Guid(id));

                return StatusCode(StatusCodes.Status200OK, new { Message = "El usuario fue borrado con éxito." });

            }
            catch (NullReferenceException)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, new { Message = "El usuario no puede ser eliminado" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = e.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditUsersByIdAsync([FromRoute] string id, [FromBody] UsersRequest obj)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var prestador = await _usersService.EditUsersByIdAsync(new Guid(id), obj);

                    return StatusCode(StatusCodes.Status200OK,
                                    new
                                    {
                                        Message = "El usuario fue actualizado con éxito.",
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
