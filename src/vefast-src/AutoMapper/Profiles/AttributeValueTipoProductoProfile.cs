using System;
using AutoMapper;
using vefast_src.Domain.Entities.AttributeValueTipoProducto;
using vefast_src.DTO.AttributeValueTipoProducto;
namespace vefast_src.AutoMapper.Profiles
{
    public class AttributeValueTipoProductoProfile : Profile
    {
        public AttributeValueTipoProductoProfile()
        {
            CreateMap<AttributeValueTipoProducto, AttributeValueTipoProductoResponse>()
              .ReverseMap()
              .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<AttributeValueTipoProducto, AttributeValueTipoProductoRequest>()
                    .ReverseMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
