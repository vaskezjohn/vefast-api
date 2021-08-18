using System;
namespace vefast_src.Infrastructure.Repositories.Attribute_value
{
    using vefast_src.Domain.Repositories.Attribute_value;
    using vefast_src.Domain.Entities.Attribute_value;

    public class Attribute_valueRepositoryEF : GenericRepository<Attribute_value>, IAttribute_valueRepository
    {
        public Attribute_valueRepositoryEF(VefastDataContext context)
         : base(context)
        {
        }
    }
}
