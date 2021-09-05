using System;
namespace vefast_src.Infrastructure.Repositories.TipoProducto
{
    using vefast_src.Domain.Repositories.TipoProducto;
    using vefast_src.Domain.Entities.TipoProducto;
    public class TipoProductoRepositoryEF : GenericRepository<TipoProducto>, ITipoProductoRepository
    {
        public TipoProductoRepositoryEF(VefastDataContext context)
        : base(context)
        {
        }
    }
}
