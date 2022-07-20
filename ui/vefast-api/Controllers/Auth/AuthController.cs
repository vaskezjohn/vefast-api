using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using vefast_src.Domain.Constants;
using vefast_src.Domain.Entities.Users;
using vefast_src.Domain.Services.User;
using vefast_src.DTO.Users;
using vefast_src.Domain.Exceptions.Users;
using Microsoft.AspNetCore.Authorization;

namespace vefast_api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public AuthController(IUsersService usersService)
        {
            this._usersService = usersService;
        }

        [AllowAnonymous]
        [Route("token")]
        [HttpPost]
        public async Task<ActionResult> Token([FromBody] AuthenticateRequest model)
        {
            try
            {
                var token = await _usersService.Token(model);

                return StatusCode(StatusCodes.Status200OK, new
                {
                    Data = token
                });

            }
            catch (IdentityErrorException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new
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

        [AllowAnonymous]
        [Route("refreshToken")]
        [HttpPost]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest model)
        {
            try
            {
                var refreshToken = await _usersService.refreshToken(model);

                return StatusCode(StatusCodes.Status200OK, new
                {
                    Data = refreshToken
                });

            }
            catch (IdentityErrorException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new
                {
                    Message = e.Message
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "Error interno del sistema"
                });
            }

        }

        [Authorize]
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

        //[HttpPost("/token")]
        //public async Task<IActionResult> Token([FromBody] AuthenticateRequest request)
        //{
        //        // Verificamos credenciales con Identity
        //        var user = await _userManager.FindByNameAsync(request.UserName);

        //        if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
        //        {
        //            return Results.Forbid();
        //        }

        //        var roles = await _userManager.GetRolesAsync(user);

        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Sid, user.Id),
        //            new Claim(ClaimTypes.Email, user.Email),
        //            new Claim(ClaimTypes.Name, user.UserName),
        //            new Claim(CustomClaimTypes.FirstName, user.FirstName)
        //        };

        //        foreach (var role in roles)
        //        {
        //            claims.Add(new Claim(ClaimTypes.Role, role));
        //        }

        //        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        //        var tokenDescriptor = new JwtSecurityToken(
        //            issuer: _configuration["Jwt:Issuer"],
        //            audience: _configuration["Jwt:Audience"],
        //            claims: claims,
        //            expires: DateTime.Now.AddMinutes(720),
        //            signingCredentials: credentials);

        //        var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);



        //        return Results.Ok(new
        //        {
        //            AccessToken = jwt
        //        })

        //}
    }
}
