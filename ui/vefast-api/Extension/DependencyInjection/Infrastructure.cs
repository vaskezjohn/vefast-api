using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using vefast_src.Domain.Repositories.Companies;
using vefast_src.Infrastructure;
using vefast_src.Infrastructure.Repositories.Companies;
using vefast_src.Domain.Repositories.Products;
using vefast_src.Infrastructure.Repositories.Products;
using vefast_src.Domain.Repositories.Stores;
using vefast_src.Infrastructure.Repositories.Stores;
using vefast_src.Domain.Repositories.Brands;
using vefast_src.Infrastructure.Repositories.Brands;
using vefast_src.Domain.Repositories.Categories;
using vefast_src.Infrastructure.Repositories.Categories;
using vefast_src.Domain.Repositories.AttributeValues;
using vefast_src.Infrastructure.Repositories.AttributeValues;
using vefast_src.Domain.Repositories.Attributes;
using vefast_src.Infrastructure.Repositories.Attributes;
using vefast_src.Domain.Repositories.OrderItems;
using vefast_src.Infrastructure.Repositories.OrderItems;
using vefast_src.Domain.Repositories.Orders;
using vefast_src.Infrastructure.Repositories.Orders;
using vefast_src.Domain.Repositories.UserGroups;
using vefast_src.Infrastructure.Repositories.UserGroups;
using vefast_src.Domain.Repositories.Groups;
using vefast_src.Infrastructure.Repositories.Groups;
using vefast_src.Infrastructure.Repositories.Stock;
using vefast_src.Domain.Repositories.Stock;
using vefast_src.Infrastructure.Repositories.ProductTypes;
using vefast_src.Domain.Repositories.ProductTypes;
using vefast_src.Infrastructure.Repositories.AttributeValuesProductTypes;
using vefast_src.Domain.Repositories.AttributeValuesProductTypes;

namespace vefast_api.Extension.DependencyInjection
{
    public static class Infrastructure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
             IConfiguration configuration)
        {
            services.AddDbContext<VefastDataContext>(options => options
                .UseMySql(configuration.GetConnectionString("vefast"), new MySqlServerVersion(new Version(8, 0, 25)),
                    mySqlOptionsAction: mySqlOptions =>
                    {
                        mySqlOptions.EnableRetryOnFailure();
                    })
                );

            //new MySqlServerVersion(new Version(8, 0, 25))

            /*AGREGO MI REPOSITORIO*/
            services.AddTransient<ICompaniesRepository, CompaniesRepositoryEF>();
            services.AddTransient<IProductsRepository, ProductsRepositoryEF>();
            services.AddTransient<IStoresRepository, StoresRepositoryEF>();
            services.AddTransient<IBrandsRepository, BrandsRepositoryEF>();
            services.AddTransient<ICategoriesRepository, CategoriesRepositoryEF>();
            services.AddTransient<IAttributeValuesRepository, AttributeValuesRepositoryEF>();
            services.AddTransient<IAttributesRepository, AttributesRepositoryEF>();
            services.AddTransient<IOrderItemsRepository, OrderItemsRepositoryEF>();
            services.AddTransient<IOrdersRepository, OrdersRepositoryEF>();
            services.AddTransient<IUserGroupsRepository, UserGroupsRepositoryEF>();
            services.AddTransient<IGroupsRepository, GroupsRepositoryEF>();
            services.AddTransient<IStockRepository, StockRepositoryEF>();
            services.AddTransient<IProductTypesRepository, ProductTypesRepositoryEF>();
            services.AddTransient<IAttributeValuesProductTypesRepository, AttributeValuesProductTypesRepositoryEF>();

            return services;
        }
    }
}
