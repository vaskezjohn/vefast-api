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
using vefast_src.Domain.Repositories.AttributeValue;
using vefast_src.Infrastructure.Repositories.AttributeValue;
using vefast_src.Domain.Repositories.Attributes;
using vefast_src.Infrastructure.Repositories.Attributes;
using vefast_src.Domain.Repositories.OrdersItem;
using vefast_src.Infrastructure.Repositories.OrdersItem;
using vefast_src.Domain.Repositories.Orders;
using vefast_src.Infrastructure.Repositories.Orders;
using vefast_src.Domain.Repositories.UserGroup;
using vefast_src.Infrastructure.Repositories.UserGroup;
using vefast_src.Domain.Repositories.Groups;
using vefast_src.Infrastructure.Repositories.Groups;
using vefast_src.Infrastructure.Repositories.Stock;
using vefast_src.Domain.Repositories.Stock;
using vefast_src.Infrastructure.Repositories.TipoProducto;
using vefast_src.Domain.Repositories.TipoProducto;
using vefast_src.Infrastructure.Repositories.AttributeValueTipoProducto;
using vefast_src.Domain.Repositories.AttributeValueTipoProducto;


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
            services.AddTransient<ICompanyRepository, CompanyRepositoryEF>();
            services.AddTransient<IProductsRepository, ProductsRepositoryEF>();
            services.AddTransient<IStoresRepository, StoresRepositoryEF>();
            services.AddTransient<IBrandsRepository, BrandsRepositoryEF>();
            services.AddTransient<ICategoriesRepository, CategoriesRepositoryEF>();
            services.AddTransient<IAttributeValueRepository, AttributeValueRepositoryEF>();
            services.AddTransient<IAttributesRepository, AttributesRepositoryEF>();
            services.AddTransient<IOrdersItemRepository, OrdersItemRepositoryEF>();
            services.AddTransient<IOrdersRepository, OrdersRepositoryEF>();
            services.AddTransient<IUserGroupRepository, UserGroupRepositoryEF>();
            services.AddTransient<IGroupsRepository, GroupsRepositoryEF>();
            services.AddTransient<IStockRepository, StockRepositoryEF>();
            services.AddTransient<ITipoProductoRepository, TipoProductoRepositoryEF>();
            services.AddTransient<IAttributeValueTipoProductoRepository, AttributeValueTipoProductoRepositoryEF>();


            return services;
        }
    }
}
