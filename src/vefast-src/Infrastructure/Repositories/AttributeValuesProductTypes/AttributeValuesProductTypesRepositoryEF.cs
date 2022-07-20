namespace vefast_src.Infrastructure.Repositories.AttributeValuesProductTypes
{
    using vefast_src.Domain.Repositories.AttributeValuesProductTypes;
    using vefast_src.Domain.Entities.ProductsAttributeValues;

    public class AttributeValuesProductTypesRepositoryEF : GenericRepository<ProductsAttributeValues>, IAttributeValuesProductTypesRepository
    {
        public AttributeValuesProductTypesRepositoryEF(VefastDataContext context)
        : base(context)
        {
        }
    }
}
