namespace vefast_src.Infrastructure.Repositories.Company
{
    using vefast_src.Domain.Repositories.Company;
    using vefast_src.Domain.Entities.Companes;

    public class CompanyRepositoryEF : GenericRepository<Companes>, ICompanyRepository
    {
        public CompanyRepositoryEF(VefastDataContext context)
         : base(context)
        {
        }
    }
}
