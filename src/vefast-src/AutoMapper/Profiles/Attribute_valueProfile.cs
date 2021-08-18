using AutoMapper;
using vefast_src.Domain.Entities.Attribute_value;
using vefast_src.DTO.Attribute_value;

namespace vefast_src.AutoMapper.Profiles
{
    public class Attribute_valueProfile : Profile
    {
        public Attribute_valueProfile()
        {
            CreateMap<Attribute_value, Attribute_valueResponse>()
                .ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Attribute_value, Attribute_valueRequest>()
                    .ReverseMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
