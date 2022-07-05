using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Entities.Companies;
using vefast_src.Domain.Exceptions.Companies;
using vefast_src.Domain.Repositories.Companies;
using vefast_src.DTO.Company;

namespace vefast_src.Domain.Services.Companies
{
    public class CompaniesService : ICompaniesService
    {
        private readonly IMapper _mapper;
        private readonly ICompaniesRepository _companyRepository;

        public CompaniesService(IMapper mapper, ICompaniesRepository companyRepository)
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
        public IEnumerable<CompaniesResponse> GetAllCompany()
        {
            return _mapper.Map<IEnumerable<CompaniesResponse>>(_companyRepository.GetAll());
        }

        public async Task<CompaniesResponse> CreateCompanyAsync(CompaniesRequest objRequest)
        {
            var company = _mapper.Map<Entities.Companies.Companies>(objRequest);
            _companyRepository.Add(company);

            try
            {
                await _companyRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<CompaniesResponse>(company);
        }

        public async Task<CompaniesResponse> GetCompanyByIdAsync(Guid id)
        {
            var company = await _companyRepository.GetByIDAsync(id);
            if (company == null)
            {
                throw new CompaniesNotFoundException("Empresa no encontrada.");
            }

            return _mapper.Map<CompaniesResponse>(company);
        }

        public async Task DeleteCompanyById(Guid id)
        {
            var company = _companyRepository.GetByID(id);

            if (company == null)
            {
                throw new CompaniesNotFoundException("Empresa no encontrada.");
            }

            _companyRepository.Delete(company);
            await _companyRepository.SaveAsync();
        }

        public async Task<CompaniesResponse> EditCompanyByIdAsync(Guid id, CompaniesRequest objRequest)
        {
            var company = await _companyRepository.GetByIDAsync(id);

            if (company == null)
            {
                throw new CompaniesNotFoundException("Empresa no encontrada.");
            }

            company.Address = objRequest.address;
            company.CompanyName = objRequest.company_name;
            company.Country = objRequest.country;
            company.Currency = objRequest.currency;
            company.Message = objRequest.message;
            company.Phone = objRequest.phone;
            company.UpdateDate = DateTime.Now;

            _companyRepository.Update(company);
            await _companyRepository.SaveAsync();

            return _mapper.Map<CompaniesResponse>(company);
        }
    }
}
