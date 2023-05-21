﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Shopping.Infrastructure.DataAccess;

#nullable disable

namespace Shopping.Infrastructure.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20230516181808_init10")]
    partial class init10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Shopping.Domain.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("category_name");

                    b.HasKey("CategoryId");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("Shopping.Domain.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("customer_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("customer_name");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.HasKey("CustomerId");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("Shopping.Domain.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("order_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("Shopping.Domain.Models.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("integer")
                        .HasColumnName("order_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("product_id");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("order_products");
                });

            modelBuilder.Entity("Shopping.Domain.Models.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("permission_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PermissionId"));

                    b.Property<string>("PermissionName")
                        .HasColumnType("text")
                        .HasColumnName("permission_name");

                    b.HasKey("PermissionId");

                    b.ToTable("permissions");
                });

            modelBuilder.Entity("Shopping.Domain.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("product_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("product_description");

                    b.Property<string>("Picture")
                        .HasColumnType("text")
                        .HasColumnName("product_picture");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("product_price");

                    b.Property<string>("ProductName")
                        .HasColumnType("text")
                        .HasColumnName("product_name");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("products");
                });

            modelBuilder.Entity("Shopping.Domain.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("role_name");

                    b.HasKey("RoleId");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("Shopping.Domain.Models.RolePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PermissionId")
                        .HasColumnType("integer")
                        .HasColumnName("permission_id");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("roles_permissions");
                });

            modelBuilder.Entity("Shopping.Domain.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Shopping.Domain.Models.UserRefreshToken", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("ExpiresTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_refreshtoken");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_email");

                    b.HasKey("UserId");

                    b.ToTable("user_tokens");
                });

            modelBuilder.Entity("Shopping.Domain.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("RoleId")
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("users_roles");
                });

            modelBuilder.Entity("Shopping.Domain.Models.Order", b =>
                {
                    b.HasOne("Shopping.Domain.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shopping.Domain.Models.OrderProduct", b =>
                {
                    b.HasOne("Shopping.Domain.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shopping.Domain.Models.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shopping.Domain.Models.Product", b =>
                {
                    b.HasOne("Shopping.Domain.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Shopping.Domain.Models.RolePermission", b =>
                {
                    b.HasOne("Shopping.Domain.Models.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shopping.Domain.Models.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Shopping.Domain.Models.UserRole", b =>
                {
                    b.HasOne("Shopping.Domain.Models.Role", "Role")
                        .WithMany("UsersRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shopping.Domain.Models.User", "User")
                        .WithMany("UsersRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shopping.Domain.Models.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("Shopping.Domain.Models.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("Shopping.Domain.Models.Product", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("Shopping.Domain.Models.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UsersRoles");
                });

            modelBuilder.Entity("Shopping.Domain.Models.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("UsersRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
