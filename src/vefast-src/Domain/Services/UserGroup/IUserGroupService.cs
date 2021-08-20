using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vefast_src.DTO.UserGroup;

namespace vefast_src.Domain.Services.UserGroup
{
    public interface IUserGroupService
    {
        IEnumerable<UserGroupResponse> GetAllUserGroup();
        Task<UserGroupResponse> CreateUserGroupAsync(UserGroupRequest objRequest);
        Task<UserGroupResponse> GetUserGroupByIdAsync(Guid id);
        Task DeleteUserGroupById(Guid id);
        Task<UserGroupResponse> EditUserGroupByIdAsync(Guid id, UserGroupRequest objRequest);
    }
}
