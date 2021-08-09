using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vafast_src.DTO.Company;

namespace vafast_src.Domain.Services.Company
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
