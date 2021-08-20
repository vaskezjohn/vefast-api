using AutoMapper;
using vefast_src.Domain.Entities.Brands;
using vefast_src.DTO.Brands;

namespace vefast_src.AutoMapper.Profiles
{
    public class BrandsProfile : Profile
    {
        public BrandsProfile()
        {
            CreateMap<Brands, BrandsResponse>()
               .ReverseMap()
               .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Brands, BrandsRequest>()
                    .ReverseMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
