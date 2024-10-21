using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliverySystem.DevTeam.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MerchantName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MerchantName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MerchantName",
                table: "Orders");
        }
    }
}
