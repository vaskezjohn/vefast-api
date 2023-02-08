using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vefast_src.Domain.Services.Companies;
using vefast_src.Domain.Services.Products;
using vefast_src.Domain.Services.Stores;
using vefast_src.Domain.Services.Brands;
using vefast_src.Domain.Services.Categories;
using vefast_src.Domain.Services.AttributeValues;
using vefast_src.Domain.Services.Attributes;
using vefast_src.Domain.Services.OrderItems;
using vefast_src.Domain.Services.Orders;
using vefast_src.Domain.Services.UserGroups;
using vefast_src.Domain.Services.Groups;
using vefast_src.Domain.Services.Stock;
using vefast_src.Domain.Services.ProductTypes;
using vefast_src.Domain.Services.AttributeValuesProductTypes;
using vefast_src.Domain.Services.User;
using vefast_src.Domain.Services.Afip;

namespace vefast_api.Extension.DependencyInjection
{
    public static class DomainService
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            /*AGREGO MI SERVICIO*/
            services.AddTransient<ICompaniesService, CompaniesService>();
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<IStoresService, StoresService>();
            services.AddTransient<IBrandsService, BrandsService>();
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IAttributeValuesService, AttributeValuesService>();
            services.AddTransient<IAttributesService, AttributesService>();
            services.AddTransient<IOrderItemsService, OrderItemsService>();
            services.AddTransient<IOrdersService, OrdersService>();
            services.AddTransient<IUserGroupsService, UserGroupsService>();
            services.AddTransient<IGroupsService, GroupsService>();
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<IProductTypesService, ProductTypesService>();
            services.AddTransient<IAttributeValuesProductTypesService, AttributeValuesProductTypesService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IAfipService, AfipService>();           

            return services;
        }
    }
}
