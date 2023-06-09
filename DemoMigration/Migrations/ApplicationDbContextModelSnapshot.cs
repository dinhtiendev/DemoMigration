﻿// <auto-generated />
using DemoMigration.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoMigration.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DemoMigration.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "16.2 inch"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "14.2 inch"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "16 GB"
                        },
                        new
                        {
                            CategoryId = 4,
                            Name = "8 GB"
                        });
                });

            modelBuilder.Entity("DemoMigration.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Description = "Description",
                            Name = "Macbook M1",
                            Price = 10.0
                        },
                        new
                        {
                            ProductId = 2,
                            Description = "Description",
                            Name = "Macbook M2",
                            Price = 10.0
                        },
                        new
                        {
                            ProductId = 3,
                            Description = "Description",
                            Name = "Macbook Pro M1",
                            Price = 10.0
                        },
                        new
                        {
                            ProductId = 4,
                            Description = "Description",
                            Name = "Macbook Pro M2",
                            Price = 10.0
                        });
                });

            modelBuilder.Entity("DemoMigration.Models.ProductCategory", b =>
                {
                    b.Property<int>("ProductCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductCategoryId"), 1L, 1);

                    b.Property<int>("CId")
                        .HasColumnType("int");

                    b.Property<int>("PId")
                        .HasColumnType("int");

                    b.HasKey("ProductCategoryId");

                    b.HasIndex("PId");

                    b.HasIndex("CId", "PId")
                        .IsUnique();

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            ProductCategoryId = 1,
                            CId = 1,
                            PId = 1
                        },
                        new
                        {
                            ProductCategoryId = 2,
                            CId = 3,
                            PId = 1
                        },
                        new
                        {
                            ProductCategoryId = 3,
                            CId = 1,
                            PId = 2
                        },
                        new
                        {
                            ProductCategoryId = 4,
                            CId = 4,
                            PId = 2
                        });
                });

            modelBuilder.Entity("DemoMigration.Models.ProductCategory", b =>
                {
                    b.HasOne("DemoMigration.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DemoMigration.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("PId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
