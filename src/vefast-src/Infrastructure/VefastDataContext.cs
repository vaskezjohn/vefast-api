using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vefast_src.Domain.Entities.Products;
using vefast_src.Domain.Entities.Stores;
using vefast_src.Domain.Entities.Brands;
using vefast_src.Domain.Entities.Categories;
using vefast_src.Domain.Entities.Attributes;
using vefast_src.Domain.Entities.Orders;
using vefast_src.Domain.Entities.Groups;
using vefast_src.Domain.Entities.Users;
using vefast_src.Domain.Entities.Companies;
using vefast_src.Domain.Entities.AttributeValues;
using vefast_src.Domain.Entities.UserGroups;
using vefast_src.Domain.Entities.OrderItems;
using vefast_src.Domain.Entities.AttributeValuesProductTypes;
using vefast_src.Domain.Entities.ProductTypes;
using vefast_src.Domain.Entities.Stock;

namespace vefast_src.Infrastructure
{

    public class VefastDataContext : DbContext
    {
        public VefastDataContext(DbContextOptions<VefastDataContext> options) : base(options) { }

        public DbSet<Attributes> Attributes { get; set; }
        public DbSet<AttributeValuesProductTypes> AttributeValuesProductTypes { get; set; }
        public DbSet<AttributeValues> AttributeValues { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Companies> Companies { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductTypes> ProductTypes { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Stores> Stores { get; set; }
        public DbSet<UserGroups> UserGroups { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                    .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Cascade;
            }
        }
    }
}
