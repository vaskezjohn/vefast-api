﻿using System;
using AutoMapper;
using vefast_src.Domain.Entities.StockDeposits;
using vefast_src.DTO.Stock;
namespace vefast_src.AutoMapper.Profiles
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<StockDeposits, StockResponse>()
               .ReverseMap()
               .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<StockDeposits, StockRequest>()
                    .ReverseMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
