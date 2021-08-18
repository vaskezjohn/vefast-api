using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using vefast_src.Domain.Repositories.Company;
using vefast_src.Infrastructure;
using vefast_src.Infrastructure.Repositories.Company;
using vefast_src.Domain.Repositories.Products;
using vefast_src.Infrastructure.Repositories.Products;
using vefast_src.Domain.Repositories.Stores;
using vefast_src.Infrastructure.Repositories.Stores;


namespace vefast_api.Extension.DependencyInjection
{
    public static class Infrastructure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
             IConfiguration configuration)
        {
            services.AddDbContext<VefastDataContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("vefast"), new MySqlServerVersion(new Version(8, 0, 25)));
            });

            /*AGREGO MI REPOSITORIO*/
            services.AddTransient<ICompanyRepository, CompanyRepositoryEF>();
            services.AddTransient<IProductsRepository, ProductsRepositoryEF>();
            services.AddTransient<IStoresRepository, StoresRepositoryEF>();

            return services;
        }
    }
}
