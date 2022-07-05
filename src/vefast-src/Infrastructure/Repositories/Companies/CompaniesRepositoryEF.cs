namespace vefast_src.Infrastructure.Repositories.Companies
{
    using vefast_src.Domain.Repositories.Companies;
    using vefast_src.Domain.Entities.Companies;

    public class CompaniesRepositoryEF : GenericRepository<Companies>, ICompaniesRepository
    {
        public CompaniesRepositoryEF(VefastDataContext context)
         : base(context)
        {
        }
    }
}
