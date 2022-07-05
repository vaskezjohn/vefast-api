using System;
using AutoMapper;
using vefast_src.Domain.Entities.Stores;
using vefast_src.DTO.Stores;
namespace vefast_src.AutoMapper.Profiles
{
    public class StoresProfile : Profile
    { 
        public StoresProfile()
        {
            CreateMap<Stores, StoresResponse>()
               .ReverseMap()
               .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Stores, StoresRequest>()
                    .ReverseMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
