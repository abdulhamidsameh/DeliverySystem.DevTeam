using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliverySystem.DevTeam.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RelationBetweenMerchantandProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MerchantId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_MerchantId",
                table: "Products",
                column: "MerchantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Merchants_MerchantId",
                table: "Products",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Merchants_MerchantId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MerchantId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "Products");
        }
    }
}
