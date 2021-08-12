using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vefast_src.Domain.Entities.Company;
using vefast_src.Domain.Entities.Products;

namespace vefast_src.Infrastructure
{

    public class VefastDataContext : DbContext
    {
        public VefastDataContext(DbContextOptions<VefastDataContext> options) : base(options) { }

        public DbSet<Company> Company { get; set; }
        public DbSet<Products> Products { get; set; }

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
