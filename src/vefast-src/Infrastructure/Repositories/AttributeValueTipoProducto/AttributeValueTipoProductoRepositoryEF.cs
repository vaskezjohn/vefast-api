using System;
namespace vefast_src.Infrastructure.Repositories.AttributeValueTipoProducto
{
    using vefast_src.Domain.Repositories.AttributeValueTipoProducto;
    using vefast_src.Domain.Entities.AttributeValueTipoProducto;
    public class AttributeValueTipoProductoRepositoryEF : GenericRepository<AttributeValueTipoProducto>, IAttributeValueTipoProductoRepository
    {
        public AttributeValueTipoProductoRepositoryEF(VefastDataContext context)
        : base(context)
        {
        }
    }
}
