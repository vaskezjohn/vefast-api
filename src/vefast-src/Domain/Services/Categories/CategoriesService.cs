using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using vefast_src.Domain.Exceptions.Categories;
using vefast_src.Domain.Repositories.Categories;
using vefast_src.DTO.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using vefast_src.Domain.Entities.Users;
using System.Security.Claims;

namespace vefast_src.Domain.Services.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IMapper _mapper;
        private readonly ICategoriesRepository _categoriesRepository;
        //private readonly IProductsRepository _categoriesRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Users> _userManager;

        public CategoriesService(IMapper mapper, ICategoriesRepository categoriesRepository, IHttpContextAccessor httpContextAccessor, UserManager<Users> userManager)
        {
            this._mapper = mapper;
            this._categoriesRepository = categoriesRepository;
            this._httpContextAccessor = httpContextAccessor;
            this._userManager = userManager;
        }

        //private string GenerateCodigoVEFAST()
        //{
        //    string lastCode = this._categoriesRepository.GetAll().OrderByDescending(x => x.InsertDate).OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();
        //    if (!String.IsNullOrEmpty(lastCode))
        //    {
        //        int number = Convert.ToInt32(lastCode[4..]);

        //        return "CLI-" + (number + 1);
        //    }
        //    else
        //    {
        //        return "CLI-1";
        //    }
        //}
        public ICollection<CategoriesResponse> GetAllCategories()
        {
            return _mapper.Map<ICollection<CategoriesResponse>>(_categoriesRepository.GetAll());
        }

        public async Task<CategoriesResponse> CreateCategoriesAsync(CategoriesRequest objRequest)
        {
            var categories = _mapper.Map<Entities.Categories.Categories>(objRequest);

            if (objRequest.ID_ParentCategory != Guid.Empty)
            {
                var parentCategory = await _categoriesRepository.GetByIDAsync(objRequest.ID_ParentCategory);

                if (parentCategory == null)
                    throw new CategoriesNotFoundException("Categoria relacionada no encontrada.");
                else
                    categories.ID_ParentCategory = parentCategory.ID;
            }

            //_accesor.HttpContext.User.GetUsername();


            var userInsert = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value);

            categories.InsertDate = DateTime.Now;
            categories.InsertUser = userInsert;
            categories.Active = true;

            try
            {
                _categoriesRepository.Add(categories);
                await _categoriesRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<CategoriesResponse>(categories);
        }

        public async Task<CategoriesResponse> GetCategoriesByIdAsync(Guid id)
        {
            var categories = await _categoriesRepository.GetByIDAsync(id);
            if (categories == null)
            {
                throw new CategoriesNotFoundException("Categoria no encontrada.");
            }

            return _mapper.Map<CategoriesResponse>(categories);
        }

        public async Task DeleteCategoriesById(Guid id)
        {
            var categories = _categoriesRepository.GetByID(id);

            if (categories == null)
            {
                throw new CategoriesNotFoundException("Categoria no encontrada.");
            }

            _categoriesRepository.Delete(categories);
            await _categoriesRepository.SaveAsync();
        }

        public async Task<CategoriesResponse> EditCategoriesByIdAsync(Guid id, CategoriesUpdateRequest objRequest)
        {
            var categories = await _categoriesRepository.GetByIDAsync(id);

            if (categories == null)
            {
                throw new CategoriesNotFoundException("Categoria no encontrada.");
            }

            categories.Name = objRequest.Name;
            categories.Active = objRequest.Active;

            _categoriesRepository.Update(categories);
            await _categoriesRepository.SaveAsync();

            return _mapper.Map<CategoriesResponse>(categories);
        }
    }
}
