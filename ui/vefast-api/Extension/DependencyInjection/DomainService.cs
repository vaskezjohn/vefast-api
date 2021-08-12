using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Services.Company;

namespace vefast_api.Extension.DependencyInjection
{
    public static class DomainService
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddTransient<ICompanyService, CompanyService>();
            return services;
        }
    }
}
