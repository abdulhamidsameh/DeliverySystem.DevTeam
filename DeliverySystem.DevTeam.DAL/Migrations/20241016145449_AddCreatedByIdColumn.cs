using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliverySystem.DevTeam.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedByIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Warehouses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedById",
                table: "Warehouses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedById",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Merchants",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedById",
                table: "Merchants",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Citys",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedById",
                table: "Citys",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedById",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_CreatedById",
                table: "Warehouses",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_LastUpdatedById",
                table: "Warehouses",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedById",
                table: "Products",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LastUpdatedById",
                table: "Products",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_CreatedById",
                table: "Merchants",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_LastUpdatedById",
                table: "Merchants",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Citys_CreatedById",
                table: "Citys",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Citys_LastUpdatedById",
                table: "Citys",
                column: "LastUpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Citys_AspNetUsers_CreatedById",
                table: "Citys",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Citys_AspNetUsers_LastUpdatedById",
                table: "Citys",
                column: "LastUpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Merchants_AspNetUsers_CreatedById",
                table: "Merchants",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Merchants_AspNetUsers_LastUpdatedById",
                table: "Merchants",
                column: "LastUpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_CreatedById",
                table: "Products",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_LastUpdatedById",
                table: "Products",
                column: "LastUpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_AspNetUsers_CreatedById",
                table: "Warehouses",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_AspNetUsers_LastUpdatedById",
                table: "Warehouses",
                column: "LastUpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citys_AspNetUsers_CreatedById",
                table: "Citys");

            migrationBuilder.DropForeignKey(
                name: "FK_Citys_AspNetUsers_LastUpdatedById",
                table: "Citys");

            migrationBuilder.DropForeignKey(
                name: "FK_Merchants_AspNetUsers_CreatedById",
                table: "Merchants");

            migrationBuilder.DropForeignKey(
                name: "FK_Merchants_AspNetUsers_LastUpdatedById",
                table: "Merchants");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_CreatedById",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_LastUpdatedById",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_AspNetUsers_CreatedById",
                table: "Warehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_AspNetUsers_LastUpdatedById",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_CreatedById",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_LastUpdatedById",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Products_CreatedById",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_LastUpdatedById",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Merchants_CreatedById",
                table: "Merchants");

            migrationBuilder.DropIndex(
                name: "IX_Merchants_LastUpdatedById",
                table: "Merchants");

            migrationBuilder.DropIndex(
                name: "IX_Citys_CreatedById",
                table: "Citys");

            migrationBuilder.DropIndex(
                name: "IX_Citys_LastUpdatedById",
                table: "Citys");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Citys");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                table: "Citys");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                table: "AspNetUsers");
        }
    }
}
