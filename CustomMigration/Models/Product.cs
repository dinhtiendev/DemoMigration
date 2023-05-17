using System;
using System.ComponentModel.DataAnnotations;

namespace DemoMigration.Models
{
	public class Product
	{
		[Key]
		public int ProductId { get; set; }
        [RegularExpression(@"^[A-Za-z ]*$")]
        public string Name { get; set; }
		[Range(0, 10000)]
		public double Price { get; set; }
        [StringLength(500, MinimumLength = 0)]
        public string Description { get; set; }
	}
}

