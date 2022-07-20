using System;
using vefast_src.Domain.Exceptions.ProductTypes;
using vefast_src.Domain.Repositories.ProductTypes;
using vefast_src.DTO.ProductTypes;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using vefast_src.Domain.Entities.ProductTypes;

namespace vefast_src.Domain.Services.ProductTypes
{
    public class ProductTypesService : IProductTypesService
    {
        private readonly IMapper _mapper;
        private readonly IProductTypesRepository _tipoProductoRepository;

        public ProductTypesService(IMapper mapper, IProductTypesRepository tipoProductoRepository)
        {
            this._mapper = mapper;
            this._tipoProductoRepository = tipoProductoRepository;
        }

        public ICollection<ProductTypesResponse> GetAllTipoProducto()
        {
            return _mapper.Map<ICollection<ProductTypesResponse>>(_tipoProductoRepository.GetAll());
        }

        public async Task<ProductTypesResponse> CreateTipoProductoAsync(ProductTypesRequest objRequest)
        {
            var tipoProducto = _mapper.Map<Entities.ProductTypes.ProductTypes>(objRequest);
            _tipoProductoRepository.Add(tipoProducto);

            try
            {
                await _tipoProductoRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<ProductTypesResponse>(tipoProducto);
        }

        public async Task<ProductTypesResponse> GetTipoProductoByIdAsync(Guid id)
        {
            var tipoProducto = await _tipoProductoRepository.GetByIDAsync(id);
            if (tipoProducto == null)
            {
                throw new ProductTypesNotFoundException("Tipo de producto no encontrado.");
            }

            return _mapper.Map<ProductTypesResponse>(tipoProducto);
        }

        public async Task DeleteTipoProductoById(Guid id)
        {
            var tipoProducto = _tipoProductoRepository.GetByID(id);

            if (tipoProducto == null)
            {
                throw new ProductTypesNotFoundException("Tipo de producto no encontrado.");
            }

            _tipoProductoRepository.Delete(tipoProducto);
            await _tipoProductoRepository.SaveAsync();
        }

        public async Task<ProductTypesResponse> EditTipoProductoByIdAsync(Guid id, ProductTypesRequest objRequest)
        {
            var tipoProducto = await _tipoProductoRepository.GetByIDAsync(id);

            if (tipoProducto == null)
            {
                throw new ProductTypesNotFoundException("Tipo de producto no encontrado.");
            }
            /*Revisar*/
            tipoProducto.Active = objRequest.Active;
            //tipoProducto.Products = objRequest.Products;
            tipoProducto.Name = objRequest.Name;
            /**/ 
            


            _tipoProductoRepository.Update(tipoProducto);
            await _tipoProductoRepository.SaveAsync();

            return _mapper.Map<ProductTypesResponse>(tipoProducto);
        }
    }
}
