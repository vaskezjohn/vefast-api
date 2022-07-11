using System;
using AutoMapper;
using vefast_src.Domain.Entities.AttributeValuesProductTypes;
using vefast_src.DTO.AttributeValuesProductTypes;
namespace vefast_src.AutoMapper.Profiles
{
    public class AttributeValuesProductTypesProfile : Profile
    {
        public AttributeValuesProductTypesProfile()
        {
            CreateMap<AttributeValuesProducts, AttributeValuesProductTypesResponse>()
              .ReverseMap()
              .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<AttributeValuesProducts, AttributeValuesProductTypesRequest>()
                    .ReverseMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
