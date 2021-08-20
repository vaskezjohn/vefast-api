using System;
namespace vefast_src.Infrastructure.Repositories.AttributeValue
{
    using vefast_src.Domain.Repositories.AttributeValue;
    using vefast_src.Domain.Entities.AttributeValue;

    public class AttributeValueRepositoryEF : GenericRepository<AttributeValue>, IAttributeValueRepository
    {
        public AttributeValueRepositoryEF(VefastDataContext context)
         : base(context)
        {
        }
    }
}
