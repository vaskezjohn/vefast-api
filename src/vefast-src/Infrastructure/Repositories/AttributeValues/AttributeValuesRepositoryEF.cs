namespace vefast_src.Infrastructure.Repositories.AttributeValues
{
    using vefast_src.Domain.Repositories.AttributeValues;
    using vefast_src.Domain.Entities.AttributeValues;

    public class AttributeValuesRepositoryEF : GenericRepository<AttributeValues>, IAttributeValuesRepository
    {
        public AttributeValuesRepositoryEF(VefastDataContext context)
         : base(context)
        {
        }
    }
}
