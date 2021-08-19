using System;
namespace vefast_src.Domain.Entities.UserGroup
{
    public class UserGroup : BaseEntity
    {
        public Guid user_id { get; set; }
        public Guid group_id { get; set; }
    }
}
