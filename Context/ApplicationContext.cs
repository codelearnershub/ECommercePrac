using ECommerce.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(a => a.HasIndex(a => a.ProductName).IsUnique());
            modelBuilder.Entity<Product>(a => a.Property(a => a.ProductName).HasColumnType("varchar(30)").IsRequired());
            modelBuilder.Entity<OrderBrand>(a =>
            {
                a.HasIndex(a => new { a.OrderId, a.BrandId }).IsUnique();
            });

            modelBuilder.Entity<ProductCategory>(a =>
            {
                a.HasIndex(a => new { a.ProductId, a.CategoryId }).IsUnique();
            });

            modelBuilder.Entity<StoreBrand>(a =>
            {
                a.HasIndex(a => new { a.StoreId, a.BrandId }).IsUnique();
            });

            modelBuilder.Entity<UserRole>(a =>
            {
                a.HasIndex(a => new { a.UserId, a.RoleId }).IsUnique();
            });

        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderBrand> OrderBrands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreBrand> StoreBrands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }



    }
}
