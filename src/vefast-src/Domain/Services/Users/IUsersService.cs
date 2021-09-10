using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vefast_src.DTO.Users;

namespace vefast_src.Domain.Services.User
{
    public interface IUsersService
    {
        IEnumerable<UsersResponse> GetAllUsers();
        Task<UsersResponse> CreateUsersAsync(UsersRequest objRequest);
        Task<UsersResponse> GetUsersByIdAsync(Guid id);
        Task DeleteUsersById(Guid id);
        Task<UsersResponse> EditUsersByIdAsync(Guid id, UsersRequest objRequest);
    }
}
