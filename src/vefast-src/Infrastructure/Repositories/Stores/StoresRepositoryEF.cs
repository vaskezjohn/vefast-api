using System;
namespace vefast_src.Infrastructure.Repositories.Stores
{
    using vefast_src.Domain.Repositories.Stores;
    using vefast_src.Domain.Entities.Stores;
    public class StoresRepositoryEF : GenericRepository<Stores>, IStoresRepository
    {
        public StoresRepositoryEF(VefastDataContext context)
        : base(context)
        {
        }
    }
}
