
namespace vefast_src.Domain.Services.User
{
    using global::AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using TimeZoneConverter;
    using vefast_src.Domain.Constants;
    using vefast_src.Domain.Entities.Users;
    using vefast_src.Domain.Exceptions.Users;
    using vefast_src.DTO.Users;

    public class UsersService : IUsersService
    {

        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersService(IConfiguration configuration, UserManager<Users> userManager, IMapper mapper, IHttpContextAccessor httpContextAccessor, RoleManager<IdentityRole> roleManager)
        {
            this._configuration = configuration;
            this._userManager = userManager;
            this._mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
            this._roleManager = roleManager;    
        }

        public async Task<AuthenticateResponse> Token(AuthenticateRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user is null)
            {
                IdentityErrorException.ThrowIdentityErrorException(new IdentityError { Code = "UserNameNotFound" });
            }
            if (!await _userManager.CheckPasswordAsync(user, request.Password))
            {
                IdentityErrorException.ThrowIdentityErrorException(new IdentityError { Code = "PasswordMismatch" });
            }
            //if (!user.EmailConfirmed)
            //{
            //    IdentityErrorException.ThrowIdentityErrorException(new IdentityError { Code = "EmailNotConfirmed" });
            //}

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Sid, user.Id),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(CustomClaimTypes.FirstName, user.FirstName),
                    new Claim(CustomClaimTypes.LastName, user.LastName),
                    new Claim(CustomClaimTypes.Company, user.LastName)
                };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = GenerateAccessToken(claims);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
      
            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtSecurityToken:RefreshTokenValidityInDays"]));

            var result = await _userManager.UpdateAsync(user);             

            if (!result.Succeeded)
                IdentityErrorException.ThrowIdentityErrorException(result.Errors.First());

            TimeZoneInfo cstZone = TZConvert.GetTimeZoneInfo("Argentina Standard Time");

            return new AuthenticateResponse()
            {
                expires_in = TimeZoneInfo.ConvertTimeFromUtc(tokenDescriptor.ValidTo, cstZone),
                access_token = token,
                token_type  = "Bearer",
                refresh_token = refreshToken
            };
        }

        public async Task<AuthenticateResponse> refreshToken(RefreshTokenRequest refresToken)
        {
            string accessToken = refresToken.access_token;
            string refreshToken = refresToken.refresh_token;

            var principal = GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name;

            var user = await _userManager.FindByNameAsync(username);
            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                IdentityErrorException.ThrowIdentityErrorException(new IdentityError { Code = "InvalidToken" });

            var tokenDescriptor = GenerateAccessToken(principal.Claims);          

            var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            TimeZoneInfo cstZone = TZConvert.GetTimeZoneInfo("Argentina Standard Time");

            return new AuthenticateResponse()
            {
                expires_in = TimeZoneInfo.ConvertTimeFromUtc(tokenDescriptor.ValidTo, cstZone),
                access_token = token,
                token_type = "Bearer",
                refresh_token = refreshToken
            };
        }

        public async Task<UserResponse> Create(UserRequest userRequest)
        {
            var user = _mapper.Map<Users>(userRequest);

            var result = await _userManager.CreateAsync(user, userRequest.Password);

            if (!result.Succeeded)
                IdentityErrorException.ThrowIdentityErrorException(result.Errors.First());
            
            var userInsert = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value);

            user = await _userManager.FindByEmailAsync(userRequest.Email);
            user.ID_InsertUser = userInsert.Id;
            user.InsertDate = DateTime.Now;

            return _mapper.Map<UserResponse>(user);
        }

        #region Private Method
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityToken:Secret"])),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return claimsPrincipal;
        }
        private JwtSecurityToken GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityToken:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: _configuration["JwtSecurityToken:Issuer"],
                audience: _configuration["JwtSecurityToken:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSecurityToken:ExpiryInMinutes"])),
                signingCredentials: credentials);

            return tokeOptions;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        #endregion
    }
}
