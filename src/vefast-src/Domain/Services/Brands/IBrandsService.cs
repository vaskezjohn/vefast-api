using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vefast_src.DTO.Brands;

namespace vefast_src.Domain.Services.Brands
{
    public interface IBrandsService
    {
        IEnumerable<BrandsResponse> GetAllBrands();
        Task<BrandsResponse> CreateBrandsAsync(BrandsRequest objRequest);
        Task<BrandsResponse> GetBrandsByIdAsync(Guid id);
        Task DeleteBrandsById(Guid id);
        Task<BrandsResponse> EditBrandsByIdAsync(Guid id, BrandsRequest objRequest);
    }
}
