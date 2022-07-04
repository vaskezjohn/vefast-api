using System;

namespace vefast_src.Domain.Entities.UsersGroups
{
    public class UsersGroups : BaseEntity
    {
        public Guid user_id { get; set; }
        public Guid group_id { get; set; }
    }
}
