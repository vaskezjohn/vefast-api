using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using vafast_src.Domain.Repositories.Company;
using vafast_src.Infrastructure;
using vafast_src.Infrastructure.Repositories.Company;

namespace vefast_api.Extension.DependencyInjection
{
    public static class Infrastructure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
             IConfiguration configuration)
        {
            services.AddDbContext<VafastDataContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("VAFAST"), new MySqlServerVersion(new Version(8, 0, 25)));
            }); 

            services.AddTransient<ICompanyRepository, CompanyRepositoryEF>();
            return services;
        }
    }
}
