using System;
using DemoMigration.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoMigration.DbContexts
{	
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasIndex(productCategory => new { productCategory.CId, productCategory.PId })
                .IsUnique();
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Macbook M1",
                Price = 10,
                Description = "Description"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Macbook M2",
                Price = 10,
                Description = "Description"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Macbook Pro M1",
                Price = 10,
                Description = "Description"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Macbook Pro M2",
                Price = 10,
                Description = "Description"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 1,
                Name = "16.2 inch"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 2,
                Name = "14.2 inch"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 3,
                Name = "16 GB"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 4,
                Name = "8 GB"
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                ProductCategoryId = 1,
                CId = 1,
                PId = 1
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                ProductCategoryId = 2,
                CId = 3,
                PId = 1
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                ProductCategoryId = 3,
                CId = 1,
                PId = 2
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                ProductCategoryId = 4,
                CId = 4,
                PId = 2
            });
        }
    }
}

