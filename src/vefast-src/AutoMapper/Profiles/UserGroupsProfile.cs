using AutoMapper;
using vefast_src.Domain.Entities.UserGroups;
using vefast_src.DTO.UserGroups;

namespace vefast_src.AutoMapper.Profiles
{
    public class UserGroupsProfile : Profile
    {
        public UserGroupsProfile()
        {
            CreateMap<UserGroups, UserGroupsResponse>()
                .ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UserGroups, UserGroupsRequest>()
                    .ReverseMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
