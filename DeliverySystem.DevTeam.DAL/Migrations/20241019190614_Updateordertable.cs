using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliverySystem.DevTeam.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Updateordertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsCashOnDelivery",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsCashOnDelivery",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Orders");
        }
    }
}
