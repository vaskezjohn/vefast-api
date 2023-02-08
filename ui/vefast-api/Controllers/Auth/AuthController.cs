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

    }
}
