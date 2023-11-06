using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineFoodDeliverySystem.Migrations
{
    /// <inheritdoc />
    public partial class delivery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65cc7198-8d59-420e-841a-c62c92178e82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efc67a06-c4f4-44f4-8644-54deb421b7eb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "36c16cdf-e3ea-4df0-b15e-5cb60fd5e04f", "1", "User", "User" },
                    { "d1bc70df-540c-4dca-82fd-01cbac073c14", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36c16cdf-e3ea-4df0-b15e-5cb60fd5e04f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1bc70df-540c-4dca-82fd-01cbac073c14");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "65cc7198-8d59-420e-841a-c62c92178e82", "1", "Admin", "Admin" },
                    { "efc67a06-c4f4-44f4-8644-54deb421b7eb", "1", "User", "User" }
                });
        }
    }
}
