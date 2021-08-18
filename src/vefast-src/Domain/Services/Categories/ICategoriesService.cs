using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vefast_src.DTO.Categories;

namespace vefast_src.Domain.Services.Categories
{
    public interface ICategoriesService
    {
        IEnumerable<CategoriesResponse> GetAllCategories();
        Task<CategoriesResponse> CreateCategoriesAsync(CategoriesRequest objRequest);
        Task<CategoriesResponse> GetCategoriesByIdAsync(Guid id);
        Task DeleteCategoriesById(Guid id);
        Task<CategoriesResponse> EditCategoriesByIdAsync(Guid id, CategoriesRequest objRequest);

    }
}
