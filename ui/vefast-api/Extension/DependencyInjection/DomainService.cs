using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Services.Company;
using vefast_src.Domain.Services.Products;
using vefast_src.Domain.Services.Stores;
using vefast_src.Domain.Services.Brands;
using vefast_src.Domain.Services.Categories;
using vefast_src.Domain.Services.AttributeValue;
using vefast_src.Domain.Services.Attributes;
using vefast_src.Domain.Services.OrdersItem;
using vefast_src.Domain.Services.Orders;
using vefast_src.Domain.Services.UserGroup;
using vefast_src.Domain.Services.Groups;
using vefast_src.Domain.Services.Stock;
using vefast_src.Domain.Services.TipoProducto;
using vefast_src.Domain.Services.AttributeValueTipoProducto;
using vefast_src.Domain.Services.User;

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
            services.AddTransient<IBrandsService, BrandsService>();
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IAttributeValueService, AttributeValueService>();
            services.AddTransient<IAttributesService, AttributesService>();
            services.AddTransient<IOrdersItemService, OrdersItemService>();
            services.AddTransient<IOrdersService, OrdersService>();
            services.AddTransient<IUserGroupService, UserGroupService>();
            services.AddTransient<IGroupsService, GroupsService>();
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<ITipoProductoService, TipoProductoService>();
            services.AddTransient<IAttributeValueTipoProductoService, AttributeValueTipoProductoService>();
            services.AddTransient<IUsersService, UsersService>();

            return services;
        }
    }
}

