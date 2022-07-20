using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vefast_src.DTO.Users;

namespace vefast_src.Domain.Services.User
{
    public interface IUsersService
    {
        Task<AuthenticateResponse> Token(AuthenticateRequest request);
        Task<AuthenticateResponse> refreshToken(RefreshTokenRequest refresToken);
        Task<UserResponse> Create(UserRequest userRequest);
    }
}
