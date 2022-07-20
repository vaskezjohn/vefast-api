using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vefast_src.DTO.UserGroups;

namespace vefast_src.Domain.Services.UserGroups
{
    public interface IUserGroupsService
    {
        ICollection<UserGroupsResponse> GetAllUserGroup();
        Task<UserGroupsResponse> CreateUserGroupAsync(UserGroupsRequest objRequest);
        Task<UserGroupsResponse> GetUserGroupByIdAsync(Guid id);
        Task DeleteUserGroupById(Guid id);
        Task<UserGroupsResponse> EditUserGroupByIdAsync(Guid id, UserGroupsRequest objRequest);
    }
}
