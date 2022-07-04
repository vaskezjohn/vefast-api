using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Entities.Companes;
using vefast_src.Domain.Exceptions.Company;
using vefast_src.Domain.Repositories.Company;
using vefast_src.DTO.Company;

namespace vefast_src.Domain.Services.Company
{
    public class CompanyService : ICompanyService
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(IMapper mapper, ICompanyRepository companyRepository)
        {
            this._mapper = mapper;
            this._companyRepository = companyRepository;
        }

        //private string GenerateCodigoVEFAST()
        //{
        //    string lastCode = this._companyRepository.GetAll().OrderByDescending(x => x.InsertDate).OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();
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
        public IEnumerable<CompanyResponse> GetAllCompany()
        {
            return _mapper.Map<IEnumerable<CompanyResponse>>(_companyRepository.GetAll());
        }

        public async Task<CompanyResponse> CreateCompanyAsync(CompanyRequest objRequest)
        {
            var company = _mapper.Map<Companes>(objRequest);
            _companyRepository.Add(company);

            try
            {
                await _companyRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<CompanyResponse>(company);
        }

        public async Task<CompanyResponse> GetCompanyByIdAsync(Guid id)
        {
            var company = await _companyRepository.GetByIDAsync(id);
            if (company == null)
            {
                throw new CompanyNotFoundException("Empresa no encontrada.");
            }

            return _mapper.Map<CompanyResponse>(company);
        }

        public async Task DeleteCompanyById(Guid id)
        {
            var company = _companyRepository.GetByID(id);

            if (company == null)
            {
                throw new CompanyNotFoundException("Empresa no encontrada.");
            }

            _companyRepository.Delete(company);
            await _companyRepository.SaveAsync();
        }

        public async Task<CompanyResponse> EditCompanyByIdAsync(Guid id, CompanyRequest objRequest)
        {
            var company = await _companyRepository.GetByIDAsync(id);

            if (company == null)
            {
                throw new CompanyNotFoundException("Empresa no encontrada.");
            }

            company.address = objRequest.address;
            company.company_name = objRequest.company_name;
            company.country = objRequest.country;
            company.currency = objRequest.currency;
            company.message = objRequest.message;
            company.phone = objRequest.phone;
            company.UpdateDate = DateTime.Now;

            _companyRepository.Update(company);
            await _companyRepository.SaveAsync();

            return _mapper.Map<CompanyResponse>(company);
        }
    }
}
