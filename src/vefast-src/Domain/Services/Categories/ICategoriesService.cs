using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vefast_src.DTO.Categories;

namespace vefast_src.Domain.Services.Categories
{
    public interface ICategoriesService
    {
        ICollection<CategoriesResponse> GetAllCategories();
        Task<CategoriesResponse> CreateCategoriesAsync(CategoriesRequest objRequest);
        Task<CategoriesResponse> GetCategoriesByIdAsync(Guid id);
        Task DeleteCategoriesById(Guid id);
        Task<CategoriesResponse> EditCategoriesByIdAsync(Guid id, CategoriesUpdateRequest objRequest);

    }
}
