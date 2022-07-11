using System;
using vefast_src.Domain.Exceptions.AttributeValuesProductTypes;
using vefast_src.Domain.Repositories.AttributeValuesProductTypes;
using vefast_src.DTO.AttributeValuesProductTypes;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace vefast_src.Domain.Services.AttributeValuesProductTypes
{
    public class AttributeValuesProductTypesService : IAttributeValuesProductTypesService
    {
        private readonly IMapper _mapper;
        private readonly IAttributeValuesProductTypesRepository _attributeValueTipoProductoRepository;

        public AttributeValuesProductTypesService(IMapper mapper, IAttributeValuesProductTypesRepository attributeValueTipoProductoRepository)
        {
            this._mapper = mapper;
            this._attributeValueTipoProductoRepository = attributeValueTipoProductoRepository;
        }

        public IEnumerable<AttributeValuesProductTypesResponse> GetAllAttributeValueTipoProducto()
        {
            return _mapper.Map<IEnumerable<AttributeValuesProductTypesResponse>>(_attributeValueTipoProductoRepository.GetAll());
        }

        public async Task<AttributeValuesProductTypesResponse> CreateAttributeValueTipoProductoAsync(AttributeValuesProductTypesRequest objRequest)
        {
            var attributeValueTipoProducto = _mapper.Map<Entities.AttributeValuesProductTypes.AttributeValuesProducts>(objRequest);
            _attributeValueTipoProductoRepository.Add(attributeValueTipoProducto);

            try
            {
                await _attributeValueTipoProductoRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<AttributeValuesProductTypesResponse>(attributeValueTipoProducto);
        }

        public async Task<AttributeValuesProductTypesResponse> GetAttributeValueTipoProductoByIdAsync(Guid id)
        {
            var attributeValueTipoProducto = await _attributeValueTipoProductoRepository.GetByIDAsync(id);
            if (attributeValueTipoProducto == null)
            {
                throw new AttributeValuesProductTypesNotFoundException("Objeto no encontrado.");
            }

            return _mapper.Map<AttributeValuesProductTypesResponse>(attributeValueTipoProducto);
        }

        public async Task DeleteAttributeValueTipoProductoById(Guid id)
        {
            var attributeValueTipoProducto = _attributeValueTipoProductoRepository.GetByID(id);

            if (attributeValueTipoProducto == null)
            {
                throw new AttributeValuesProductTypesNotFoundException("Objeto no encontrado.");
            }

            _attributeValueTipoProductoRepository.Delete(attributeValueTipoProducto);
            await _attributeValueTipoProductoRepository.SaveAsync();
        }

        public async Task<AttributeValuesProductTypesResponse> EditAttributeValueTipoProductoByIdAsync(Guid id, AttributeValuesProductTypesRequest objRequest)
        {
            var attributeValueTipoProducto = await _attributeValueTipoProductoRepository.GetByIDAsync(id);

            if (attributeValueTipoProducto == null)
            {
                throw new AttributeValuesProductTypesNotFoundException("Objeto no encontrado.");
            }

            attributeValueTipoProducto.ID_AttributeValue = objRequest.ID_AttributeValue;
            attributeValueTipoProducto.ID_ProductType = objRequest.ID_ProductType;            

            _attributeValueTipoProductoRepository.Update(attributeValueTipoProducto);
            await _attributeValueTipoProductoRepository.SaveAsync();

            return _mapper.Map<AttributeValuesProductTypesResponse>(attributeValueTipoProducto);
        }
    }
}
