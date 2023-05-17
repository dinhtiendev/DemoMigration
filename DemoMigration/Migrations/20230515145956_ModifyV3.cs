using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoMigration.Migrations
{
    public partial class ModifyV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_CId",
                table: "ProductCategories");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CId_PId",
                table: "ProductCategories",
                columns: new[] { "CId", "PId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_CId_PId",
                table: "ProductCategories");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CId",
                table: "ProductCategories",
                column: "CId");
        }
    }
}
