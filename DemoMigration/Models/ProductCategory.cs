using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMigration.Models
{
	public class ProductCategory
	{
		public int ProductCategoryId { get; set; }

		public int CId { get; set; }
		[ForeignKey("CId")]
		public Category Category { get; set; }

		public int PId { get; set; }
		[ForeignKey("PId")]
        public Product Product { get; set; }
    }
}

