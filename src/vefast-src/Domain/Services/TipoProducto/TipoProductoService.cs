using System;
using vefast_src.Domain.Exceptions.TipoProducto;
using vefast_src.Domain.Repositories.TipoProducto;
using vefast_src.DTO.TipoProducto;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using vefast_src.Domain.Entities.ProductsType;

namespace vefast_src.Domain.Services.TipoProducto
{
    public class TipoProductoService : ITipoProductoService
    {
        private readonly IMapper _mapper;
        private readonly ITipoProductoRepository _tipoProductoRepository;

        public TipoProductoService(IMapper mapper, ITipoProductoRepository tipoProductoRepository)
        {
            this._mapper = mapper;
            this._tipoProductoRepository = tipoProductoRepository;
        }

        public IEnumerable<TipoProductoResponse> GetAllTipoProducto()
        {
            return _mapper.Map<IEnumerable<TipoProductoResponse>>(_tipoProductoRepository.GetAll());
        }

        public async Task<TipoProductoResponse> CreateTipoProductoAsync(TipoProductoRequest objRequest)
        {
            var tipoProducto = _mapper.Map<ProductsType>(objRequest);
            _tipoProductoRepository.Add(tipoProducto);

            try
            {
                await _tipoProductoRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<TipoProductoResponse>(tipoProducto);
        }

        public async Task<TipoProductoResponse> GetTipoProductoByIdAsync(Guid id)
        {
            var tipoProducto = await _tipoProductoRepository.GetByIDAsync(id);
            if (tipoProducto == null)
            {
                throw new TipoProductoNotFoundException("Tipo de producto no encontrado.");
            }

            return _mapper.Map<TipoProductoResponse>(tipoProducto);
        }

        public async Task DeleteTipoProductoById(Guid id)
        {
            var tipoProducto = _tipoProductoRepository.GetByID(id);

            if (tipoProducto == null)
            {
                throw new TipoProductoNotFoundException("Tipo de producto no encontrado.");
            }

            _tipoProductoRepository.Delete(tipoProducto);
            await _tipoProductoRepository.SaveAsync();
        }

        public async Task<TipoProductoResponse> EditTipoProductoByIdAsync(Guid id, TipoProductoRequest objRequest)
        {
            var tipoProducto = await _tipoProductoRepository.GetByIDAsync(id);

            if (tipoProducto == null)
            {
                throw new TipoProductoNotFoundException("Tipo de producto no encontrado.");
            }
            /*Revisar*/
            tipoProducto.active = objRequest.active;
            //tipoProducto.Products = objRequest.Products;
            tipoProducto.tipoProduct = objRequest.tipoProduct;
            /**/ 
            


            _tipoProductoRepository.Update(tipoProducto);
            await _tipoProductoRepository.SaveAsync();

            return _mapper.Map<TipoProductoResponse>(tipoProducto);
        }
    }
}
