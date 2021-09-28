namespace vefast_src.Domain.Repositories.Users
{
    using vefast_src.Domain.Entities.Users;

    public interface IUsersRepository : IGenericRepository<Users>
    {
        Users CheckUserPassword(string user, string pass);

    }
}
