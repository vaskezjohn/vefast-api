using AutoMapper;
using vefast_src.Domain.Entities.Companes;
using vefast_src.DTO.Company;

namespace vefast_src.AutoMapper.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Companes, CompanyResponse>()
                .ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Companes, CompanyRequest>()
                    .ReverseMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
