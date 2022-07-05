using AutoMapper;
using vefast_src.Domain.Entities.OrderItems;
using vefast_src.DTO.OrdersItem;

namespace vefast_src.AutoMapper.Profiles
{
    public class OrderItemsProfile : Profile
    {
        public OrderItemsProfile()
        {
            CreateMap<OrderItems, OrdersItemResponse>()
                .ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<OrderItems, OrdersItemRequest>()
                    .ReverseMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
