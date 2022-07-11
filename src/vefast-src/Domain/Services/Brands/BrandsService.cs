using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Exceptions.Brands;
using vefast_src.Domain.Repositories.Brands;
using vefast_src.DTO.Brands;
namespace vefast_src.Domain.Services.Brands
{
    public class BrandsService : IBrandsService
    {
        private readonly IMapper _mapper;
        private readonly IBrandsRepository _brandsRepository;

        public BrandsService(IMapper mapper, IBrandsRepository brandsRepository)
        {
            this._mapper = mapper;
            this._brandsRepository = brandsRepository;
        }

        //private string GenerateCodigoVEFAST()
        //{
        //    string lastCode = this._brandsRepository.GetAll().OrderByDescending(x => x.InsertDate).OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();
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
        public IEnumerable<BrandsResponse> GetAllBrands()
        {
            return _mapper.Map<IEnumerable<BrandsResponse>>(_brandsRepository.GetAll());
        }

        public async Task<BrandsResponse> CreateBrandsAsync(BrandsRequest objRequest)
        {
            var brands = _mapper.Map<Entities.Brands.Brands>(objRequest);
            _brandsRepository.Add(brands);

            try
            {
                await _brandsRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<BrandsResponse>(brands);
        }

        public async Task<BrandsResponse> GetBrandsByIdAsync(Guid id)
        {
            var brands = await _brandsRepository.GetByIDAsync(id);
            if (brands == null)
            {
                throw new BrandsNotFoundException("Marca no encontrada.");
            }

            return _mapper.Map<BrandsResponse>(brands);
        }

        public async Task DeleteBrandsById(Guid id)
        {
            var brands = _brandsRepository.GetByID(id);

            if (brands == null)
            {
                throw new BrandsNotFoundException("Marca no encontrada.");
            }

            _brandsRepository.Delete(brands);
            await _brandsRepository.SaveAsync();
        }

        public async Task<BrandsResponse> EditBrandsByIdAsync(Guid id, BrandsRequest objRequest)
        {
            var brands = await _brandsRepository.GetByIDAsync(id);

            if (brands == null)
            {
                throw new BrandsNotFoundException("Marca no encontrada.");
            }

            brands.Name = objRequest.Name;
            brands.Active = objRequest.Active;

            _brandsRepository.Update(brands);
            await _brandsRepository.SaveAsync();

            return _mapper.Map<BrandsResponse>(brands);
        }
    }
}
