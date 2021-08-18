using System;
namespace vefast_src.Domain.Entities.User_group
{
    public class User_group : BaseEntity
    {
        public Guid user_id { get; set; }
        public Guid group_id { get; set; }
    }
}
