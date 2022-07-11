namespace vefast_src.Infrastructure.Repositories.AttributeValuesProductTypes
{
    using vefast_src.Domain.Repositories.AttributeValuesProductTypes;
    using vefast_src.Domain.Entities.AttributeValuesProductTypes;
    public class AttributeValuesProductTypesRepositoryEF : GenericRepository<AttributeValuesProducts>, IAttributeValuesProductTypesRepository
    {
        public AttributeValuesProductTypesRepositoryEF(VefastDataContext context)
        : base(context)
        {
        }
    }
}
