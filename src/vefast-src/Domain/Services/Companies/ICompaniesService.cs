using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vefast_src.DTO.Company;

namespace vefast_src.Domain.Services.Companies
{
    public interface ICompanyService
    {
        IEnumerable<CompaniesResponse> GetAllCompany();
        Task<CompaniesResponse> CreateCompanyAsync(CompaniesRequest objRequest);
        Task<CompaniesResponse> GetCompanyByIdAsync(Guid id);
        Task DeleteCompanyById(Guid id);
        Task<CompaniesResponse> EditCompanyByIdAsync(Guid id, CompaniesRequest objRequest);
    }
}
