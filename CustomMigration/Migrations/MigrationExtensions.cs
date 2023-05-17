using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace CustomMigration.Migrations
{
	public static class MigrationExtensions
	{
		public static OperationBuilder<SqlOperation> InsertProduct(
			this MigrationBuilder migrationBuilder,
			string name,
			double price,
			string description)
		{
			string sql = $"INSERT INTO PRODUCTS VALUES ('{name}', {price}, '{description}')";
			return migrationBuilder.Sql(sql);
		}
	}
}

