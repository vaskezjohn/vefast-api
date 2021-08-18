using System;
namespace vefast_src.Infrastructure.Repositories.Groups
{
    using vefast_src.Domain.Repositories.Groups;
    using vefast_src.Domain.Entities.Groups;

    public class GroupsRepositoryEF : GenericRepository<Groups>, IGroupsRepository
    {
        public GroupsRepositoryEF(VefastDataContext context)
         : base(context)
        {
        }
    }
}
