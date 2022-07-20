using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vefast_src.DTO.Groups;

namespace vefast_src.Domain.Services.Groups
{
    public interface IGroupsService
    {
        ICollection<GroupsResponse> GetAllGroups();
        Task<GroupsResponse> CreateGroupsAsync(GroupsRequest objRequest);
        Task<GroupsResponse> GetGroupsByIdAsync(Guid id);
        Task DeleteGroupsById(Guid id);
        Task<GroupsResponse> EditGroupsByIdAsync(Guid id, GroupsRequest objRequest);
    }
}
