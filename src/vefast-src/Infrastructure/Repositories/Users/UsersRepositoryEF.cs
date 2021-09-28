using System.Linq;

namespace vefast_src.Infrastructure.Repositories.Users
{
    using vefast_src.Domain.Repositories.Users;
    using vefast_src.Domain.Entities.Users;


    public class UsersRepositoryEF : GenericRepository<Users>, IUsersRepository
    {
        public UsersRepositoryEF(VefastDataContext context)
         : base(context)
        {

        }

        public Users CheckUserPassword(string user, string pass)
        {
            return DataContext.Users.Where(u => u.user == user && u.password == pass).FirstOrDefault();
        }
    }
}
