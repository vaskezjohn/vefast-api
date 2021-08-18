using AutoMapper;
using vefast_src.Domain.Entities.Attributes;
using vefast_src.DTO.Attributes;

namespace vefast_src.AutoMapper.Profiles
{
    public class AttributesProfile : Profile
    {
        public AttributesProfile()
        {
            CreateMap<Attributes, AttributesResponse>()
               .ReverseMap()
               .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Attributes, AttributesRequest>()
                    .ReverseMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
