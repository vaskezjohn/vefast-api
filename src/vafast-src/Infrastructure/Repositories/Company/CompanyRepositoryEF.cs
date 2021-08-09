namespace vafast_src.Infrastructure.Repositories.Company
{
    using vafast_src.Domain.Repositories.Company;
    using vafast_src.Domain.Entities.Company;

    public class CompanyRepositoryEF : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepositoryEF(VafastDataContext context)
         : base(context)
        {
        }
    }
}
