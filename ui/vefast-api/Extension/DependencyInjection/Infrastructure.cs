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
using vefast_src.Domain.Repositories.Brands;
using vefast_src.Infrastructure.Repositories.Brands;
using vefast_src.Domain.Repositories.Categories;
using vefast_src.Infrastructure.Repositories.Categories;
using vefast_src.Domain.Repositories.Attribute_value;
using vefast_src.Infrastructure.Repositories.Attribute_value;
using vefast_src.Domain.Repositories.Attributes;
using vefast_src.Infrastructure.Repositories.Attributes;
using vefast_src.Domain.Repositories.Orders_item;
using vefast_src.Infrastructure.Repositories.Orders_item;
using vefast_src.Domain.Repositories.Orders;
using vefast_src.Infrastructure.Repositories.Orders;
using vefast_src.Domain.Repositories.User_group;
using vefast_src.Infrastructure.Repositories.User_group;
using vefast_src.Domain.Repositories.Groups;
using vefast_src.Infrastructure.Repositories.Groups;


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
            services.AddTransient<IBrandsRepository, BrandsRepositoryEF>();
            services.AddTransient<ICategoriesRepository, CategoriesRepositoryEF>();
            services.AddTransient<IAttribute_valueRepository, Attribute_valueRepositoryEF>();
            services.AddTransient<IAttributesRepository, AttributesRepositoryEF>();
            services.AddTransient<IOrders_itemRepository, Orders_itemRepositoryEF>();
            services.AddTransient<IOrdersRepository, OrdersRepositoryEF>();
            services.AddTransient<IUser_groupRepository, User_groupRepositoryEF>();
            services.AddTransient<IGroupsRepository, GroupsRepositoryEF>();

            return services;
        }
    }
}
