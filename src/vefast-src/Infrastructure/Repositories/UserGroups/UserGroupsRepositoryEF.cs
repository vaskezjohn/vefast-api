using System;
namespace vefast_src.Infrastructure.Repositories.UserGroups
{
    using vefast_src.Domain.Repositories.UserGroups;
    using vefast_src.Domain.Entities.UserGroups;

    public class UserGroupsRepositoryEF : GenericRepository<UserGroups>, IUserGroupsRepository
    {
        public UserGroupsRepositoryEF(VefastDataContext context)
         : base(context)
        {
        }
    }
}
