using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vefast_src.DTO.Company;

namespace vefast_src.Domain.Services.Company
{
    public interface ICompanyService
    {
        IEnumerable<CompanyResponse> GetAllCompany();
        Task<CompanyResponse> CreateCompanyAsync(CompanyRequest objRequest);
        Task<CompanyResponse> GetCompanyByIdAsync(Guid id);
        Task DeleteCompanyById(Guid id);
        Task<CompanyResponse> EditCompanyByIdAsync(Guid id, CompanyRequest objRequest);
    }
}
