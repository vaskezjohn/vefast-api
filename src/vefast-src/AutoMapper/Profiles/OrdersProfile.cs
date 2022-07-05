using AutoMapper;
using vefast_src.Domain.Entities.Orders;
using vefast_src.DTO.Orders;

namespace vefast_src.AutoMapper.Profiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<Orders, OrdersResponse>()
               .ReverseMap()
               .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Orders, OrdersRequest>()
                    .ReverseMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
