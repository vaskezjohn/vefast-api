using AutoMapper;
using vefast_src.Domain.Entities.OrdersItem;
using vefast_src.DTO.OrdersItem;

namespace vefast_src.AutoMapper.Profiles
{
    public class Orders_itemProfile : Profile
    {
        public Orders_itemProfile()
        {
            CreateMap<OrdersItem, OrdersItemResponse>()
                .ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<OrdersItem, OrdersItemRequest>()
                    .ReverseMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
