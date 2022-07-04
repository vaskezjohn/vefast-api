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
using vefast_src.Domain.Entities.AttributeValue;
using vefast_src.Domain.Entities.Attributes;
using vefast_src.Domain.Entities.OrdersItem;
using vefast_src.Domain.Entities.Orders;
using vefast_src.Domain.Entities.Groups;
using vefast_src.Domain.Entities.Users;
using vefast_src.Domain.Entities.UsersGroups;
using vefast_src.Domain.Entities.Companes;

namespace vefast_src.Infrastructure
{

    public class VefastDataContext : DbContext
    {
        public VefastDataContext(DbContextOptions<VefastDataContext> options) : base(options) { }

        public DbSet<Companes> Company { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Stores> Stores { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<AttributeValue> AttributeValue { get; set; }
        public DbSet<Attributes> Attributes { get; set; }
        public DbSet<OrdersItem> Ordersitem { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<UsersGroups> UserGroup { get; set; }
        public DbSet<Groups> Groups { get; set; }
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
