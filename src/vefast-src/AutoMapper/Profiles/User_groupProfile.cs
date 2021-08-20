using AutoMapper;
using vefast_src.Domain.Entities.UserGroup;
using vefast_src.DTO.UserGroup;

namespace vefast_src.AutoMapper.Profiles
{
    public class User_groupProfile : Profile
    {
        public User_groupProfile()
        {
            CreateMap<UserGroup, UserGroupResponse>()
                .ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UserGroup, UserGroupRequest>()
                    .ReverseMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
