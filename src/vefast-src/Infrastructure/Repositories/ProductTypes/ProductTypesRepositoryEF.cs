using System;
namespace vefast_src.Infrastructure.Repositories.ProductTypes
{
    using vefast_src.Domain.Repositories.ProductTypes;
    using vefast_src.Domain.Entities.ProductTypes;

    public class ProductTypesRepositoryEF : GenericRepository<ProductTypes>, IProductTypesRepository
    {
        public ProductTypesRepositoryEF(VefastDataContext context)
        : base(context)
        {
        }
    }
}
