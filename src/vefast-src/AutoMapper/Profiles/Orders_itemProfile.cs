using AutoMapper;
using vefast_src.Domain.Entities.Orders_item;
using vefast_src.DTO.Orders_item;

namespace vefast_src.AutoMapper.Profiles
{
    public class Orders_itemProfile : Profile
    {
        public Orders_itemProfile()
        {
            CreateMap<Orders_item, Orders_itemResponse>()
                .ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Orders_item, Orders_itemRequest>()
                    .ReverseMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
