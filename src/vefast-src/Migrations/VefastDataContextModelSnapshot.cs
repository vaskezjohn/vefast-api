﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using vefast_src.Infrastructure;

namespace vefast_src.Migrations
{
    [DbContext(typeof(VefastDataContext))]
    partial class VefastDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("vefast_src.Domain.Entities.AttributeValues.AttributeValues", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ID_Attribute")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("InsertUserID")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UpdateUserID")
                        .HasColumnType("char(36)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.HasIndex("ID_Attribute");

                    b.HasIndex("InsertUserID");

                    b.HasIndex("UpdateUserID");

                    b.ToTable("AttributeValues");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.AttributeValuesProductTypes.AttributeValuesProductTypes", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("AttributeValueID")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ID_AttributeValue")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ID_ProductType")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("InsertUserID")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ProductTypeID")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UpdateUserID")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.HasIndex("AttributeValueID");

                    b.HasIndex("InsertUserID");

                    b.HasIndex("ProductTypeID");

                    b.HasIndex("UpdateUserID");

                    b.ToTable("AttributeValuesProductTypes");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.Attributes.Attributes", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("InsertUserID")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UpdateUserID")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.HasIndex("InsertUserID");

                    b.HasIndex("UpdateUserID");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.Brands.Brands", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("InsertUserID")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UpdateUserID")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.HasIndex("InsertUserID");

                    b.HasIndex("UpdateUserID");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.Categories.Categories", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("InsertUserID")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UpdateUserID")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.HasIndex("InsertUserID");

                    b.HasIndex("UpdateUserID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.Companies.Companies", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CompanyName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Country")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Currency")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("InsertUserID")
                        .HasColumnType("char(36)");

                    b.Property<string>("Message")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ServiceChargeValue")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UpdateUserID")
                        .HasColumnType("char(36)");

                    b.Property<string>("VatChargeValue")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("ID");

                    b.HasIndex("InsertUserID");

                    b.HasIndex("UpdateUserID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.Groups.Groups", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("GroupName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("InsertUserID")
                        .HasColumnType("char(36)");

                    b.Property<string>("Permission")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UpdateUserID")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.HasIndex("InsertUserID");

                    b.HasIndex("UpdateUserID");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.OrderItems.OrderItems", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<double>("Amount")
                        .HasColumnType("double");

                    b.Property<Guid>("ID_Order")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ID_Product")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("InsertUserID")
                        .HasColumnType("char(36)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UpdateUserID")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.HasIndex("ID_Order")
                        .IsUnique();

                    b.HasIndex("ID_Product");

                    b.HasIndex("InsertUserID");

                    b.HasIndex("UpdateUserID");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.Orders.Orders", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("BillNo")
                        .HasColumnType("longtext");

                    b.Property<string>("CustomerAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("CustomerName")
                        .HasColumnType("longtext");

                    b.Property<string>("CustomerPhone")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateTimeIn")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Discount")
                        .HasColumnType("double");

                    b.Property<double>("GrossAmount")
                        .HasColumnType("double");

                    b.Property<Guid>("ID_OrderItem")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ID_User")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("InsertUserID")
                        .HasColumnType("char(36)");

                    b.Property<double>("NetAmount")
                        .HasColumnType("double");

                    b.Property<int>("PaidStatus")
                        .HasColumnType("int");

                    b.Property<double>("ServiceCharge")
                        .HasColumnType("double");

                    b.Property<double>("ServiceChargeRate")
                        .HasColumnType("double");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UpdateUserID")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("char(36)");

                    b.Property<double>("VatCharge")
                        .HasColumnType("double");

                    b.Property<double>("VatChargeRate")
                        .HasColumnType("double");

                    b.HasKey("ID");

                    b.HasIndex("InsertUserID");

                    b.HasIndex("UpdateUserID");

                    b.HasIndex("UserID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.ProductTypes.ProductTypes", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("InsertUserID")
                        .HasColumnType("char(36)");

                    b.Property<string>("ProductType")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UpdateUserID")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.HasIndex("InsertUserID");

                    b.HasIndex("UpdateUserID");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.Products.Products", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Availability")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("BrandID")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CategoryID")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("Text");

                    b.Property<Guid>("ID_Brand")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ID_Category")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ID_ProductType")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ID_Store")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("InsertUserID")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<Guid?>("ProductTypeID")
                        .HasColumnType("char(36)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Sku")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<Guid?>("StoreID")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UpdateUserID")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.HasIndex("BrandID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("InsertUserID");

                    b.HasIndex("ProductTypeID");

                    b.HasIndex("StoreID");

                    b.HasIndex("UpdateUserID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.Stock.Stock", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<Guid>("ID_Product")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("InsertUserID")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ProductID")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UpdateUserID")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.HasIndex("InsertUserID");

                    b.HasIndex("ProductID");

                    b.HasIndex("UpdateUserID");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.Stores.Stores", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("CompanyID")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ID_Company")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("InsertUserID")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UpdateUserID")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.HasIndex("CompanyID");

                    b.HasIndex("InsertUserID");

                    b.HasIndex("UpdateUserID");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.UserGroups.UserGroups", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ID_User")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ID_UserGroup")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("InsertUserID")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UpdateUserID")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.HasIndex("ID_UserGroup");

                    b.HasIndex("InsertUserID");

                    b.HasIndex("UpdateUserID");

                    b.HasIndex("UserID");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.Users.Users", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Firstname")
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<string>("User")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.AttributeValues.AttributeValues", b =>
                {
                    b.HasOne("vefast_src.Domain.Entities.Attributes.Attributes", "Attribute")
                        .WithMany("AttributeValues")
                        .HasForeignKey("ID_Attribute")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "InsertUser")
                        .WithMany()
                        .HasForeignKey("InsertUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Attribute");

                    b.Navigation("InsertUser");

                    b.Navigation("UpdateUser");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.AttributeValuesProductTypes.AttributeValuesProductTypes", b =>
                {
                    b.HasOne("vefast_src.Domain.Entities.AttributeValues.AttributeValues", "AttributeValue")
                        .WithMany()
                        .HasForeignKey("AttributeValueID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "InsertUser")
                        .WithMany()
                        .HasForeignKey("InsertUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vefast_src.Domain.Entities.ProductTypes.ProductTypes", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("AttributeValue");

                    b.Navigation("InsertUser");

                    b.Navigation("ProductType");

                    b.Navigation("UpdateUser");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.Attributes.Attributes", b =>
                {
                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "InsertUser")
                        .WithMany()
                        .HasForeignKey("InsertUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("InsertUser");

                    b.Navigation("UpdateUser");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.Brands.Brands", b =>
                {
                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "InsertUser")
                        .WithMany()
                        .HasForeignKey("InsertUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("InsertUser");

                    b.Navigation("UpdateUser");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.Categories.Categories", b =>
                {
                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "InsertUser")
                        .WithMany()
                        .HasForeignKey("InsertUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("InsertUser");

                    b.Navigation("UpdateUser");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.Companies.Companies", b =>
                {
                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "InsertUser")
                        .WithMany()
                        .HasForeignKey("InsertUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("InsertUser");

                    b.Navigation("UpdateUser");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.Groups.Groups", b =>
                {
                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "InsertUser")
                        .WithMany()
                        .HasForeignKey("InsertUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("InsertUser");

                    b.Navigation("UpdateUser");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.OrderItems.OrderItems", b =>
                {
                    b.HasOne("vefast_src.Domain.Entities.Orders.Orders", "Orders")
                        .WithOne("OrderItem")
                        .HasForeignKey("vefast_src.Domain.Entities.OrderItems.OrderItems", "ID_Order")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vefast_src.Domain.Entities.Products.Products", "Products")
                        .WithMany()
                        .HasForeignKey("ID_Product")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "InsertUser")
                        .WithMany()
                        .HasForeignKey("InsertUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("InsertUser");

                    b.Navigation("Orders");

                    b.Navigation("Products");

                    b.Navigation("UpdateUser");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.Orders.Orders", b =>
                {
                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "InsertUser")
                        .WithMany()
                        .HasForeignKey("InsertUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("InsertUser");

                    b.Navigation("UpdateUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.ProductTypes.ProductTypes", b =>
                {
                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "InsertUser")
                        .WithMany()
                        .HasForeignKey("InsertUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("InsertUser");

                    b.Navigation("UpdateUser");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.Products.Products", b =>
                {
                    b.HasOne("vefast_src.Domain.Entities.Brands.Brands", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vefast_src.Domain.Entities.Categories.Categories", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "InsertUser")
                        .WithMany()
                        .HasForeignKey("InsertUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vefast_src.Domain.Entities.ProductTypes.ProductTypes", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vefast_src.Domain.Entities.Stores.Stores", "Store")
                        .WithMany()
                        .HasForeignKey("StoreID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("InsertUser");

                    b.Navigation("ProductType");

                    b.Navigation("Store");

                    b.Navigation("UpdateUser");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.Stock.Stock", b =>
                {
                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "InsertUser")
                        .WithMany()
                        .HasForeignKey("InsertUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vefast_src.Domain.Entities.Products.Products", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("InsertUser");

                    b.Navigation("Product");

                    b.Navigation("UpdateUser");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.Stores.Stores", b =>
                {
                    b.HasOne("vefast_src.Domain.Entities.Companies.Companies", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "InsertUser")
                        .WithMany()
                        .HasForeignKey("InsertUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Company");

                    b.Navigation("InsertUser");

                    b.Navigation("UpdateUser");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.UserGroups.UserGroups", b =>
                {
                    b.HasOne("vefast_src.Domain.Entities.UserGroups.UserGroups", "UserGroup")
                        .WithMany()
                        .HasForeignKey("ID_UserGroup")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "InsertUser")
                        .WithMany()
                        .HasForeignKey("InsertUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vefast_src.Domain.Entities.Users.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("InsertUser");

                    b.Navigation("UpdateUser");

                    b.Navigation("User");

                    b.Navigation("UserGroup");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.Attributes.Attributes", b =>
                {
                    b.Navigation("AttributeValues");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.Brands.Brands", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.Categories.Categories", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.Orders.Orders", b =>
                {
                    b.Navigation("OrderItem");
                });

            modelBuilder.Entity("vefast_src.Domain.Entities.ProductTypes.ProductTypes", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
