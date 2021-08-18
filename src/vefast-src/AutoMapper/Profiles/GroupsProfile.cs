using AutoMapper;
using vefast_src.Domain.Entities.Groups;
using vefast_src.DTO.Groups;

namespace vefast_src.AutoMapper.Profiles
{
    public class GroupsProfile : Profile
    {
        public GroupsProfile()
        {
            CreateMap<Groups, GroupsResponse>()
                .ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Groups, GroupsRequest>()
                    .ReverseMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
