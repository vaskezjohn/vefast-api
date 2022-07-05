using AutoMapper;
using vefast_src.Domain.Entities.Companies;
using vefast_src.DTO.Company;

namespace vefast_src.AutoMapper.Profiles
{
    public class CompaniesProfile : Profile
    {
        public CompaniesProfile()
        {
            CreateMap<Companies, CompaniesResponse>()
                .ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Companies, CompaniesRequest>()
                    .ReverseMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
