using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class editLaptopImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaptopImagess_Laptops_LaptopId",
                table: "LaptopImagess");

            migrationBuilder.RenameColumn(
                name: "LaptopId",
                table: "LaptopImagess",
                newName: "laptopId");

            migrationBuilder.RenameIndex(
                name: "IX_LaptopImagess_LaptopId",
                table: "LaptopImagess",
                newName: "IX_LaptopImagess_laptopId");

            migrationBuilder.AddForeignKey(
                name: "FK_LaptopImagess_Laptops_laptopId",
                table: "LaptopImagess",
                column: "laptopId",
                principalTable: "Laptops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaptopImagess_Laptops_laptopId",
                table: "LaptopImagess");

            migrationBuilder.RenameColumn(
                name: "laptopId",
                table: "LaptopImagess",
                newName: "LaptopId");

            migrationBuilder.RenameIndex(
                name: "IX_LaptopImagess_laptopId",
                table: "LaptopImagess",
                newName: "IX_LaptopImagess_LaptopId");

            migrationBuilder.AddForeignKey(
                name: "FK_LaptopImagess_Laptops_LaptopId",
                table: "LaptopImagess",
                column: "LaptopId",
                principalTable: "Laptops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
