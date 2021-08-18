using System;
namespace vefast_src.Infrastructure.Repositories.User_group
{
    using vefast_src.Domain.Repositories.User_group;
    using vefast_src.Domain.Entities.User_group;

    public class User_groupRepositoryEF : GenericRepository<User_group>, IUser_groupRepository
    {
        public User_groupRepositoryEF(VefastDataContext context)
         : base(context)
        {
        }
    }
}
