using System;
using vefast_src.Domain.Exceptions.AttributeValueTipoProducto;
using vefast_src.Domain.Repositories.AttributeValueTipoProducto;
using vefast_src.DTO.AttributeValueTipoProducto;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace vefast_src.Domain.Services.AttributeValueTipoProducto
{
    public class AttributeValueTipoProductoService : IAttributeValueTipoProductoService
    {
        private readonly IMapper _mapper;
        private readonly IAttributeValueTipoProductoRepository _attributeValueTipoProductoRepository;

        public AttributeValueTipoProductoService(IMapper mapper, IAttributeValueTipoProductoRepository attributeValueTipoProductoRepository)
        {
            this._mapper = mapper;
            this._attributeValueTipoProductoRepository = attributeValueTipoProductoRepository;
        }

        public IEnumerable<AttributeValueTipoProductoResponse> GetAllAttributeValueTipoProducto()
        {
            return _mapper.Map<IEnumerable<AttributeValueTipoProductoResponse>>(_attributeValueTipoProductoRepository.GetAll());
        }

        public async Task<AttributeValueTipoProductoResponse> CreateAttributeValueTipoProductoAsync(AttributeValueTipoProductoRequest objRequest)
        {
            var attributeValueTipoProducto = _mapper.Map<Entities.AttributeValueTipoProducto.AttributeValueTipoProducto>(objRequest);
            _attributeValueTipoProductoRepository.Add(attributeValueTipoProducto);

            try
            {
                await _attributeValueTipoProductoRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<AttributeValueTipoProductoResponse>(attributeValueTipoProducto);
        }

        public async Task<AttributeValueTipoProductoResponse> GetAttributeValueTipoProductoByIdAsync(Guid id)
        {
            var attributeValueTipoProducto = await _attributeValueTipoProductoRepository.GetByIDAsync(id);
            if (attributeValueTipoProducto == null)
            {
                throw new AttributeValueTipoProductoNotFoundException("Objeto no encontrado.");
            }

            return _mapper.Map<AttributeValueTipoProductoResponse>(attributeValueTipoProducto);
        }

        public async Task DeleteAttributeValueTipoProductoById(Guid id)
        {
            var attributeValueTipoProducto = _attributeValueTipoProductoRepository.GetByID(id);

            if (attributeValueTipoProducto == null)
            {
                throw new AttributeValueTipoProductoNotFoundException("Objeto no encontrado.");
            }

            _attributeValueTipoProductoRepository.Delete(attributeValueTipoProducto);
            await _attributeValueTipoProductoRepository.SaveAsync();
        }

        public async Task<AttributeValueTipoProductoResponse> EditAttributeValueTipoProductoByIdAsync(Guid id, AttributeValueTipoProductoRequest objRequest)
        {
            var attributeValueTipoProducto = await _attributeValueTipoProductoRepository.GetByIDAsync(id);

            if (attributeValueTipoProducto == null)
            {
                throw new AttributeValueTipoProductoNotFoundException("Objeto no encontrado.");
            }

            attributeValueTipoProducto.IDAttributeValue = objRequest.IDAttributeValue;
            attributeValueTipoProducto.IDTipoProducto = objRequest.IDTipoProducto;            

            _attributeValueTipoProductoRepository.Update(attributeValueTipoProducto);
            await _attributeValueTipoProductoRepository.SaveAsync();

            return _mapper.Map<AttributeValueTipoProductoResponse>(attributeValueTipoProducto);
        }
    }
}
