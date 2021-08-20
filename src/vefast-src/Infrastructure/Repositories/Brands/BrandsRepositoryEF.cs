using System;
namespace vefast_src.Infrastructure.Repositories.Brands
{
    using vefast_src.Domain.Repositories.Brands;
    using vefast_src.Domain.Entities.Brands;

    public class BrandsRepositoryEF : GenericRepository<Brands>, IBrandsRepository
    {
        public BrandsRepositoryEF(VefastDataContext context)
         : base(context)
        {
        }
    }
}
