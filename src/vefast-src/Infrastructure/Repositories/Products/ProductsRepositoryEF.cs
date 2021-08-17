namespace vefast_src.Infrastructure.Repositories.Products
{
    using vefast_src.Domain.Repositories.Products;
    using vefast_src.Domain.Entities.Products;

    public class ProductsRepositoryEF : GenericRepository<Products>, IProductsRepository
    {
        public ProductsRepositoryEF(VefastDataContext context)
      : base(context)
        {
        }
    }
}
