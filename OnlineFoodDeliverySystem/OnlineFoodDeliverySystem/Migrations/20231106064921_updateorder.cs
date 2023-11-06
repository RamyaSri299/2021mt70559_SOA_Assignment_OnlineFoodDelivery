using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineFoodDeliverySystem.Migrations
{
    /// <inheritdoc />
    public partial class updateorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1fb2de0-d60e-484a-8bf1-e116afd42278");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc1573cd-4c23-4aae-9539-fa968510d55b");

            migrationBuilder.AddColumn<string>(
                name: "Delivery_status",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "65cc7198-8d59-420e-841a-c62c92178e82", "1", "Admin", "Admin" },
                    { "efc67a06-c4f4-44f4-8644-54deb421b7eb", "1", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65cc7198-8d59-420e-841a-c62c92178e82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efc67a06-c4f4-44f4-8644-54deb421b7eb");

            migrationBuilder.DropColumn(
                name: "Delivery_status",
                table: "OrderDetails");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d1fb2de0-d60e-484a-8bf1-e116afd42278", "1", "User", "User" },
                    { "fc1573cd-4c23-4aae-9539-fa968510d55b", "1", "Admin", "Admin" }
                });
        }
    }
}
