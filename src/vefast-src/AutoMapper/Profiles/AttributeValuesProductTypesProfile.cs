using System;
using AutoMapper;
using vefast_src.Domain.Entities.ProductsAttributeValues;
using vefast_src.DTO.AttributeValuesProductTypes;
namespace vefast_src.AutoMapper.Profiles
{
    public class AttributeValuesProductTypesProfile : Profile
    {
        public AttributeValuesProductTypesProfile()
        {
            CreateMap<ProductsAttributeValues, AttributeValuesProductTypesResponse>()
              .ReverseMap()
              .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<ProductsAttributeValues, AttributeValuesProductTypesRequest>()
                    .ReverseMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
