using System;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using vefast_src.Domain.Exceptions.AttributeValue;
using vefast_src.Domain.Repositories.AttributeValue;
using vefast_src.DTO.AttributeValue;


namespace vefast_src.Domain.Services.AttributeValue
{
    public class AttributeValueService : IAttributeValueService
    {
        private readonly IMapper _mapper;
        private readonly IAttributeValueRepository _attributeValueRepository;

        public AttributeValueService(IMapper mapper, IAttributeValueRepository attribute_valueRepository)
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
        public IEnumerable<AttributeValueResponse> GetAllAttributeValue()
        {
            return _mapper.Map<IEnumerable<AttributeValueResponse>>(_attributeValueRepository.GetAll());
        }

        public async Task<AttributeValueResponse> CreateAttributeValueAsync(AttributeValueRequest objRequest)
        {
            var attribute_value = _mapper.Map<Entities.AttributeValue.AttributeValue>(objRequest);
            _attributeValueRepository.Add(attribute_value);

            try
            {
                await _attributeValueRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<AttributeValueResponse>(attribute_value);
        }

        public async Task<AttributeValueResponse> GetAttributeValueByIdAsync(Guid id)
        {
            var attribute_value = await _attributeValueRepository.GetByIDAsync(id);
            if (attribute_value == null)
            {
                throw new AttributeValueNotFoundException("Valor de atributo no encontrado.");
            }

            return _mapper.Map<AttributeValueResponse>(attribute_value);
        }

        public async Task DeleteAttributeValueById(Guid id)
        {
            var attribute_value = _attributeValueRepository.GetByID(id);

            if (attribute_value == null)
            {
                throw new AttributeValueNotFoundException("Valor de atributo no encontrado.");
            }

            _attributeValueRepository.Delete(attribute_value);
            await _attributeValueRepository.SaveAsync();
        }

        public async Task<AttributeValueResponse> EditAttributeValueByIdAsync(Guid id, AttributeValueRequest objRequest)
        {
            var attribute_value = await _attributeValueRepository.GetByIDAsync(id);

            if (attribute_value == null)
            {
                throw new AttributeValueNotFoundException("Valor de atributo no encontrado.");
            }

            attribute_value.value = objRequest.value;
            attribute_value.attribute_parent_id = objRequest.attribute_parent_id;            
            attribute_value.attributes_id = objRequest.attributes_id;
            

            _attributeValueRepository.Update(attribute_value);
            await _attributeValueRepository.SaveAsync();

            return _mapper.Map<AttributeValueResponse>(attribute_value);
        }
    }
}
