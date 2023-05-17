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

        public DbSet<Product> Products { get; set; }
    }
}

