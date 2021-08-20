using System;
namespace vefast_src.Infrastructure.Repositories.UserGroup
{
    using vefast_src.Domain.Repositories.UserGroup;
    using vefast_src.Domain.Entities.UserGroup;

    public class UserGroupRepositoryEF : GenericRepository<UserGroup>, IUserGroupRepository
    {
        public UserGroupRepositoryEF(VefastDataContext context)
         : base(context)
        {
        }
    }
}
