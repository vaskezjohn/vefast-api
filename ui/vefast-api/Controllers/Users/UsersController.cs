using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using vefast_src.Domain.Exceptions.Users;
using vefast_src.Domain.Services.User;
using vefast_src.DTO.Users;

namespace vefast_api.Controllers.Users
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            this._usersService = usersService;
        }

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult> Register([FromBody] UserRequest model)
        {
            try
            {
                var user = await _usersService.Create(model);

                //var codeConfirmation = await _usersService.GenerateEmailConfirmationToken(user.UserName);
                //var callBackUrl = Url.Action("ConfirmEmail", "Auth", new { userId = user.Id, codeConfirmation }, protocol: HttpContext.Request.Scheme);

                //var builder = new StringBuilder();

                //using (var reader = System.IO.File.OpenText($"{_env.WebRootPath}/Templates/EmailTemplate/Confirm_Account_Registration.html"))
                //{
                //    builder.Append(reader.ReadToEnd());
                //}

                //builder.Replace("{{confirm-link}}", callBackUrl);

                //await _emailService.SendEmailAsync(user.Email, "Por favor confirme su correo", builder.ToString());


                return StatusCode(StatusCodes.Status201Created, new
                {
                    Message = "El usuario fue creado con éxito. Por favor verifique su casilla de correo"
                });

            }
            catch (IdentityErrorException e)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, new
                {
                    Message = e.Message
                });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "Error interno del sistema"
                });
            }
        }
    }
}
