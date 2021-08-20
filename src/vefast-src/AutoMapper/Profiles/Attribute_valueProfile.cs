using AutoMapper;
using vefast_src.Domain.Entities.AttributeValue;
using vefast_src.DTO.AttributeValue;

namespace vefast_src.AutoMapper.Profiles
{
    public class Attribute_valueProfile : Profile
    {
        public Attribute_valueProfile()
        {
            CreateMap<AttributeValue, AttributeValueResponse>()
                .ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<AttributeValue, AttributeValueRequest>()
                    .ReverseMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
