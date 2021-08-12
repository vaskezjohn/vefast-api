namespace vefast_src.Infrastructure.Repositories.Company
{
    using vefast_src.Domain.Repositories.Company;
    using vefast_src.Domain.Entities.Company;

    public class CompanyRepositoryEF : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepositoryEF(VefastDataContext context)
         : base(context)
        {
        }
    }
}
