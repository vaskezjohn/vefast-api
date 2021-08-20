using System;
namespace vefast_src.Infrastructure.Repositories.Attributes
{
    using vefast_src.Domain.Repositories.Attributes;
    using vefast_src.Domain.Entities.Attributes;

    public class AttributesRepositoryEF : GenericRepository<Attributes>, IAttributesRepository
    {
        public AttributesRepositoryEF(VefastDataContext context)
         : base(context)
        {
        }
    }
}
