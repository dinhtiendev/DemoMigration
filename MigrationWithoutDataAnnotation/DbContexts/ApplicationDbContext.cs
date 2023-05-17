using System;
using Microsoft.EntityFrameworkCore;
using MigrationWithoutDataAnnotation.Models;

namespace DemoMigration.DbContexts
{	
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property<int>("Id")
                .IsRequired()
                .HasColumnType("int");

                entity.Property<double>("Price")
                .IsRequired()
                .HasColumnType("float");

                entity.Property<string>("Name")
                .IsRequired()
                .HasColumnType("nvarchar(20)");

                entity.Property<string>("Description")
                .IsRequired()
                .HasColumnType("nvarchar(500)");

                entity.Property<string>("CategoryName")
                .IsRequired()
                .HasColumnType("nvarchar(20)");

                entity.HasKey(p => p.Id);
            });
        }
    }
}

