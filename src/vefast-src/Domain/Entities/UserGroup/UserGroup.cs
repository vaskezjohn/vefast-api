using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace vefast_src.Domain.Entities.UserGroup
{
    using vefast_src.Domain.Entities.Users;
    using vefast_src.Domain.Entities.Groups;
    public class UserGroup : BaseEntity
    {
        [ForeignKey("Users")]
        public Guid user_id { get; set; }
        [ForeignKey("Groups")]
        public Guid group_id { get; set; }
        public virtual Users Users { get; set; }
        public virtual Groups Groups { get; set; }
    }
}
