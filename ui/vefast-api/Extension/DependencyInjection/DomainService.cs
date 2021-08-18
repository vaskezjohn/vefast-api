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
using vefast_src.Domain.Services.Attribute_value;
using vefast_src.Domain.Services.Attributes;
using vefast_src.Domain.Services.Orders_item;
using vefast_src.Domain.Services.Orders;
using vefast_src.Domain.Services.User_group;
using vefast_src.Domain.Services.Groups;

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
            services.AddTransient<IAttribute_valueService, Attribute_valueService>();
            services.AddTransient<IAttributesService, AttributesService>();
            services.AddTransient<IOrders_itemService, Orders_itemService>();
            services.AddTransient<IOrdersService, OrdersService>();
            services.AddTransient<IUser_groupService, User_groupService>();
            services.AddTransient<IGroupsService, GroupsService>();

            return services;
        }
    }
}
