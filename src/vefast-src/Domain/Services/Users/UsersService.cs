using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using vefast_src.Domain.Exceptions.Users;
using vefast_src.Domain.Repositories.Users;
using vefast_src.DTO.Users;

namespace vefast_src.Domain.Services.User
{
    public class UsersService : IUsersService
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;
        private readonly IConfiguration _configuration;

        public  UsersService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public static string CreateHash(string pass)
        {
            /*cifrado de clave*/
            HashAlgorithm HashValue = new SHA1CryptoServiceProvider();
            byte[] arrayByte = Encoding.UTF8.GetBytes(pass);
            byte[] arrayByteHash = HashValue.ComputeHash(arrayByte);
            HashValue.Clear();
            return Convert.ToBase64String(arrayByteHash);
        }

        private JwtSecurityToken GenerateToken(string user, bool reset=false)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenConfiguration:SigningKeyIntranet"]));
            var secretKeyReset = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenConfiguration:SigningKeyReset"]));
            var audienceToken = _configuration["TokenConfiguration:Audience"];
            var issuerToken = _configuration["TokenConfiguration:Issuer"];
            var expiryInMinutes = Convert.ToInt32(_configuration["TokenConfiguration:ExpiryInMinutes"]);
            var expiryInMinutesReset = Convert.ToInt32(_configuration["TokenConfiguration:ExpiryInMinutesReset"]);
         
            return new JwtSecurityToken(
            issuer: issuerToken,
            audience: audienceToken,
            claims: new[]
              {                        
                        new Claim(JwtRegisteredClaimNames.NameId, user)
              },
            notBefore: DateTime.UtcNow,
            expires: reset ? DateTime.UtcNow.AddMinutes(expiryInMinutesReset) : DateTime.UtcNow.AddMinutes(expiryInMinutes),
            signingCredentials: reset ? new SigningCredentials(secretKeyReset, SecurityAlgorithms.HmacSha256) : new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
            );
        }

        private bool ValidateToken(string token)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenConfiguration:SigningKeyReset"]));
            var audienceToken = _configuration["TokenConfiguration:Audience"];
            var issuerToken = _configuration["TokenConfiguration:Issuer"];

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = issuerToken,
                    ValidAudience = audienceToken,
                    IssuerSigningKey = secretKey
                }, out SecurityToken validatedToken);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public UsersResponse Login(UsersLoginRequest user)
        {
            var hash = CreateHash(user.password);
            var usuario = _usersRepository.CheckUserPassword(user.user, hash);
            if ( usuario==null )
            {
                new Exception("Usuario inexistente");  
            }
            
            var token = GenerateToken(usuario.user);
            usuario.token = new JwtSecurityTokenHandler().WriteToken(token);
            usuario.tokenExpires = token.ValidTo;
            return _mapper.Map<UsersResponse>(usuario);
        } 
        
        

        public UsersService(IMapper mapper, IUsersRepository usersRepository)
        {
            this._mapper = mapper;
            this._usersRepository = usersRepository;
        }

        //private string GenerateCodigoVEFAST()
        //{
        //    string lastCode = this._usersRepository.GetAll().OrderByDescending(x => x.InsertDate).OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();
        //    if (!String.IsNullOrEmpty(lastCode))
        //    {
        //        int number = Convert.ToInt32(lastCode[4..]);

        //        return "CLI-" + (number + 1);
        //    }
        //    else
        //    {
        //        return "CLI-1";
        //    }
        //}
        public IEnumerable<UsersResponse> GetAllUsers()
        {
            return _mapper.Map<IEnumerable<UsersResponse>>(_usersRepository.GetAll());
        }

        public async Task<UsersResponse> CreateUsersAsync(UsersRequest objRequest)
        {
            var users = _mapper.Map<Entities.Users.Users>(objRequest);
            users.password = CreateHash(users.password);
            _usersRepository.Add(users);

            try
            {
                await _usersRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<UsersResponse>(users);
        }

        public async Task<UsersResponse> GetUsersByIdAsync(Guid id)
        {
            var users = await _usersRepository.GetByIDAsync(id);
            if (users == null)
            {
                throw new UsersNotFoundException("Grupo de usuario no encontrado.");
            }

            return _mapper.Map<UsersResponse>(users);
        }

        public async Task DeleteUsersById(Guid id)
        {
            var users = _usersRepository.GetByID(id);

            if (users == null)
            {
                throw new UsersNotFoundException("Grupo de usuario no encontrado.");
            }

            _usersRepository.Delete(users);
            await _usersRepository.SaveAsync();
        }

        public async Task<UsersResponse> EditUsersByIdAsync(Guid id, UsersRequest objRequest)
        {
            var users = await _usersRepository.GetByIDAsync(id);

            if (users == null)
            {
                throw new UsersNotFoundException("Grupo de usuario no encontrado.");
            }

            users.ID = objRequest.ID;
            users.user= objRequest.user;
            users.password = objRequest.password;
            users.email = objRequest.email;
            users.firstname = objRequest.firstname;
            users.lastname = objRequest.lastname;
            users.phone = objRequest.phone;
            users.gender = objRequest.gender;
            users.token= objRequest.token;
            users.tokenExpires = objRequest.tokenExpires;
            users.refreshToken = objRequest.refreshToken;
            users.changePassword = objRequest.changePassword;
            objRequest.downLogic = objRequest.downLogic;


            _usersRepository.Update(users);
            await _usersRepository.SaveAsync();

            return _mapper.Map<UsersResponse>(users);
        }
    }
}
