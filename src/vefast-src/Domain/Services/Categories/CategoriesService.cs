using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using vefast_src.Domain.Exceptions.Categories;
using vefast_src.Domain.Repositories.Categories;
using vefast_src.DTO.Categories;

namespace vefast_src.Domain.Services.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IMapper _mapper;
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesService(IMapper mapper, ICategoriesRepository categoriesRepository)
        {
            this._mapper = mapper;
            this._categoriesRepository = categoriesRepository;
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
            _categoriesRepository.Add(categories);

            try
            {
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

        public async Task<CategoriesResponse> EditCategoriesByIdAsync(Guid id, CategoriesRequest objRequest)
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
