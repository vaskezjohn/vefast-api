using System;
namespace vefast_src.DTO.UserGroups
{
    public class UserGroupsRequest
    {
        public Guid user_id { get; set; }
        public Guid group_id { get; set; }
    }
}
