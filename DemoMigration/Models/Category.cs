using System;
using System.ComponentModel.DataAnnotations;

namespace DemoMigration.Models
{
	public class Category
	{
        [Key]
        public int CategoryId { get; set; }
        [RegularExpression(@"^[A-Za-z ]*$")]
        public string Name { get; set; }
    }
}

