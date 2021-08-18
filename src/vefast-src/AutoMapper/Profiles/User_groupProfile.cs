using AutoMapper;
using vefast_src.Domain.Entities.User_group;
using vefast_src.DTO.User_group;

namespace vefast_src.AutoMapper.Profiles
{
    public class User_groupProfile : Profile
    {
        public User_groupProfile()
        {
            CreateMap<User_group, User_groupResponse>()
                .ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<User_group, User_groupRequest>()
                    .ReverseMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
