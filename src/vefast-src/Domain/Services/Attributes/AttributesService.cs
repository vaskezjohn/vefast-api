using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Exceptions.Attributes;
using vefast_src.Domain.Repositories.Attributes;
using vefast_src.DTO.Attributes;


namespace vefast_src.Domain.Services.Attributes
{
    public class AttributesService : IAttributesService
    {
        private readonly IMapper _mapper;
        private readonly IAttributesRepository _attributesRepository;

        public AttributesService(IMapper mapper, IAttributesRepository attributesRepository)
        {
            this._mapper = mapper;
            this._attributesRepository = attributesRepository;
        }

        //private string GenerateCodigoVEFAST()
        //{
        //    string lastCode = this._attributesRepository.GetAll().OrderByDescending(x => x.InsertDate).OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();
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
        public IEnumerable<AttributesResponse> GetAllAttributes()
        {
            return _mapper.Map<IEnumerable<AttributesResponse>>(_attributesRepository.GetAll());
        }

        public async Task<AttributesResponse> CreateAttributesAsync(AttributesRequest objRequest)
        {
            var attributes = _mapper.Map<Entities.Attributes.Attributes>(objRequest);
            _attributesRepository.Add(attributes);

            try
            {
                await _attributesRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<AttributesResponse>(attributes);
        }

        public async Task<AttributesResponse> GetAttributesByIdAsync(Guid id)
        {
            var attributes = await _attributesRepository.GetByIDAsync(id);
            if (attributes == null)
            {
                throw new AttributesNotFoundException("Empresa no encontrada.");
            }

            return _mapper.Map<AttributesResponse>(attributes);
        }

        public async Task DeleteAttributesById(Guid id)
        {
            var attributes = _attributesRepository.GetByID(id);

            if (attributes == null)
            {
                throw new AttributesNotFoundException("Empresa no encontrada.");
            }

            _attributesRepository.Delete(attributes);
            await _attributesRepository.SaveAsync();
        }

        public async Task<AttributesResponse> EditAttributesByIdAsync(Guid id, AttributesRequest objRequest)
        {
            var attributes = await _attributesRepository.GetByIDAsync(id);

            if (attributes == null)
            {
                throw new AttributesNotFoundException("Empresa no encontrada.");
            }

            attributes.Name = objRequest.name;
            attributes.Active = objRequest.active;
           

            _attributesRepository.Update(attributes);
            await _attributesRepository.SaveAsync();

            return _mapper.Map<AttributesResponse>(attributes);
        }
    }
}
