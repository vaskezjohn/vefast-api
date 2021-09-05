using System;
using AutoMapper;
using vefast_src.Domain.Entities.Stock;
using vefast_src.DTO.Stock;
namespace vefast_src.AutoMapper.Profiles
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<Stock, StockResponse>()
               .ReverseMap()
               .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Stock, StockRequest>()
                    .ReverseMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
