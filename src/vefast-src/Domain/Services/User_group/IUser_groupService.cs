using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vefast_src.DTO.User_group;

namespace vefast_src.Domain.Services.User_group
{
    public interface IUser_groupService
    {
        IEnumerable<User_groupResponse> GetAllUser_group();
        Task<User_groupResponse> CreateUser_groupAsync(User_groupRequest objRequest);
        Task<User_groupResponse> GetUser_groupByIdAsync(Guid id);
        Task DeleteUser_groupById(Guid id);
        Task<User_groupResponse> EditUser_groupByIdAsync(Guid id, User_groupRequest objRequest);
    }
}
