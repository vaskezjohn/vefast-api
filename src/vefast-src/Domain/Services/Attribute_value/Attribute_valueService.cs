using System;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using vefast_src.Domain.Exceptions.Attribute_value;
using vefast_src.Domain.Repositories.Attribute_value;
using vefast_src.DTO.Attribute_value;


namespace vefast_src.Domain.Services.Attribute_value
{
    public class Attribute_valueService : IAttribute_valueService
    {
        private readonly IMapper _mapper;
        private readonly IAttribute_valueRepository _attribute_valueRepository;

        public Attribute_valueService(IMapper mapper, IAttribute_valueRepository attribute_valueRepository)
        {
            this._mapper = mapper;
            this._attribute_valueRepository = attribute_valueRepository;
        }

        //private string GenerateCodigoVEFAST()
        //{
        //    string lastCode = this._attribute_valueRepository.GetAll().OrderByDescending(x => x.InsertDate).OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();
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
        public IEnumerable<Attribute_valueResponse> GetAllAttribute_value()
        {
            return _mapper.Map<IEnumerable<Attribute_valueResponse>>(_attribute_valueRepository.GetAll());
        }

        public async Task<Attribute_valueResponse> CreateAttribute_valueAsync(Attribute_valueRequest objRequest)
        {
            var attribute_value = _mapper.Map<Entities.Attribute_value.Attribute_value>(objRequest);
            _attribute_valueRepository.Add(attribute_value);

            try
            {
                await _attribute_valueRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<Attribute_valueResponse>(attribute_value);
        }

        public async Task<Attribute_valueResponse> GetAttribute_valueByIdAsync(Guid id)
        {
            var attribute_value = await _attribute_valueRepository.GetByIDAsync(id);
            if (attribute_value == null)
            {
                throw new Attribute_valueNotFoundException("Valor de atributo no encontrado.");
            }

            return _mapper.Map<Attribute_valueResponse>(attribute_value);
        }

        public async Task DeleteAttribute_valueById(Guid id)
        {
            var attribute_value = _attribute_valueRepository.GetByID(id);

            if (attribute_value == null)
            {
                throw new Attribute_valueNotFoundException("Valor de atributo no encontrado.");
            }

            _attribute_valueRepository.Delete(attribute_value);
            await _attribute_valueRepository.SaveAsync();
        }

        public async Task<Attribute_valueResponse> EditAttribute_valueByIdAsync(Guid id, Attribute_valueRequest objRequest)
        {
            var attribute_value = await _attribute_valueRepository.GetByIDAsync(id);

            if (attribute_value == null)
            {
                throw new Attribute_valueNotFoundException("Valor de atributo no encontrado.");
            }

            attribute_value.value = objRequest.value;
            attribute_value.attribute_parent_id = objRequest.attribute_parent_id;
            attribute_value.products_id = objRequest.products_id;
            attribute_value.attributes_id = objRequest.attributes_id;
            

            _attribute_valueRepository.Update(attribute_value);
            await _attribute_valueRepository.SaveAsync();

            return _mapper.Map<Attribute_valueResponse>(attribute_value);
        }
    }
}
