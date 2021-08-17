using AutoMapper;
using vefast_src.Domain.Entities.Products;
using vefast_src.DTO.Products;


namespace vefast_src.AutoMapper.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Products, ProductsResponse>()
                .ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Products, ProductsRequest>()
                    .ReverseMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
