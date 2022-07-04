using System;
namespace vefast_src.Infrastructure.Repositories.UserGroup
{
    using vefast_src.Domain.Repositories.UserGroup;
    using vefast_src.Domain.Entities.UsersGroups;

    public class UserGroupRepositoryEF : GenericRepository<UsersGroups>, IUserGroupRepository
    {
        public UserGroupRepositoryEF(VefastDataContext context)
         : base(context)
        {
        }
    }
}
