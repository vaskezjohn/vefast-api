using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Services.Company;
using vefast_src.Domain.Services.Products;
using vefast_src.Domain.Services.Stores;

namespace vefast_api.Extension.DependencyInjection
{
    public static class DomainService
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            /*AGREGO MI SERVICIO*/
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<IStoresService, StoresService>();
            return services;
        }
    }
}
