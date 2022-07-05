using AutoMapper;
using vefast_src.Domain.Entities.AttributeValues;
using vefast_src.DTO.AttributeValues;

namespace vefast_src.AutoMapper.Profiles
{
    public class AttributeValuesProfile : Profile
    {
        public AttributeValuesProfile()
        {
            CreateMap<AttributeValues, AttributeValuesResponse>()
                .ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<AttributeValues, AttributeValuesRequest>()
                    .ReverseMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
