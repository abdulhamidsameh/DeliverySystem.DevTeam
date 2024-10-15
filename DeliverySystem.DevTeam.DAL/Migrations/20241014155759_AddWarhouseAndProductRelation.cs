using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliverySystem.DevTeam.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddWarhouseAndProductRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarhouseId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_WarhouseId",
                table: "Products",
                column: "WarhouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Warehouses_WarhouseId",
                table: "Products",
                column: "WarhouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Warehouses_WarhouseId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_WarhouseId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WarhouseId",
                table: "Products");
        }
    }
}
