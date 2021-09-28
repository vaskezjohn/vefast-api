﻿using AutoMapper;
using vefast_src.Domain.Entities.Users;
using vefast_src.DTO.Users;

namespace vefast_src.AutoMapper.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<Users, UsersResponse>()
                .ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Users, UsersRequest>()
                    .ReverseMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}