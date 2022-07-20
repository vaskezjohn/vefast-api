using System;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using vefast_src.Domain.Exceptions.AttributeValues;
using vefast_src.Domain.Repositories.AttributeValues;
using vefast_src.DTO.AttributeValues;
using vefast_src.Domain.Entities.AttributeValues;

namespace vefast_src.Domain.Services.AttributeValues
{
    public class AttributeValuesService : IAttributeValuesService
    {
        private readonly IMapper _mapper;
        private readonly IAttributeValuesRepository _attributeValueRepository;

        public AttributeValuesService(IMapper mapper, IAttributeValuesRepository attribute_valueRepository)
        {
            this._mapper = mapper;
            this._attributeValueRepository = attribute_valueRepository;
        }

        //private string GenerateCodigoVEFAST()
        //{
        //    string lastCode = this._attributeValueRepository.GetAll().OrderByDescending(x => x.InsertDate).OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();
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
        public ICollection<AttributeValuesResponse> GetAllAttributeValue()
        {
            return _mapper.Map<ICollection<AttributeValuesResponse>>(_attributeValueRepository.GetAll());
        }

        public async Task<AttributeValuesResponse> CreateAttributeValueAsync(AttributeValuesRequest objRequest)
        {
            var attribute_value = _mapper.Map<Entities.AttributeValues.AttributeValues>(objRequest);
            _attributeValueRepository.Add(attribute_value);

            try
            {
                await _attributeValueRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<AttributeValuesResponse>(attribute_value);
        }

        public async Task<AttributeValuesResponse> GetAttributeValueByIdAsync(Guid id)
        {
            var attribute_value = await _attributeValueRepository.GetByIDAsync(id);
            if (attribute_value == null)
            {
                throw new AttributeValuesNotFoundException("Valor de atributo no encontrado.");
            }

            return _mapper.Map<AttributeValuesResponse>(attribute_value);
        }

        public async Task DeleteAttributeValueById(Guid id)
        {
            var attribute_value = _attributeValueRepository.GetByID(id);

            if (attribute_value == null)
            {
                throw new AttributeValuesNotFoundException("Valor de atributo no encontrado.");
            }

            _attributeValueRepository.Delete(attribute_value);
            await _attributeValueRepository.SaveAsync();
        }

        public async Task<AttributeValuesResponse> EditAttributeValueByIdAsync(Guid id, AttributeValuesRequest objRequest)
        {
            var attribute_value = await _attributeValueRepository.GetByIDAsync(id);

            if (attribute_value == null)
            {
                throw new AttributeValuesNotFoundException("Valor de atributo no encontrado.");
            }

            attribute_value.Value = objRequest.Value;
            attribute_value.ID_Attribute = objRequest.ID_Attribute;
            

            _attributeValueRepository.Update(attribute_value);
            await _attributeValueRepository.SaveAsync();

            return _mapper.Map<AttributeValuesResponse>(attribute_value);
        }
    }
}
