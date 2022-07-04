using System;
namespace vefast_src.Infrastructure.Repositories.TipoProducto
{
    using vefast_src.Domain.Repositories.TipoProducto;
    using vefast_src.Domain.Entities.ProductsType;

    public class TipoProductoRepositoryEF : GenericRepository<ProductsType>, ITipoProductoRepository
    {
        public TipoProductoRepositoryEF(VefastDataContext context)
        : base(context)
        {
        }
    }
}
