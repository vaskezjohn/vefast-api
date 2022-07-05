namespace vefast_src.Domain.Entities.UserGroups
{
    using System;
    using vefast_src.Domain.Entities.Users;
    using vefast_src.Domain.Entities.UserGroups;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserGroups : BaseEntity
    {
        [ForeignKey("Users")]
        public Guid ID_User { get; set; }

        [ForeignKey("UserGroup")]
        public Guid ID_UserGroup { get; set; }
        public virtual Users User { get; set; }
        public virtual UserGroups UserGroup { get; set; }
    }
}
