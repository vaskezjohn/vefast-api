using System;
namespace vefast_src.Infrastructure.Repositories.Categories
{
    using vefast_src.Domain.Repositories.Categories;
    using vefast_src.Domain.Entities.Categories;

    public class CategoriesRepositoryEF : GenericRepository<Categories>, ICategoriesRepository
    {
        public CategoriesRepositoryEF(VefastDataContext context)
         : base(context)
        {
        }
    }
}
