using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineFoodDeliverySystem.Migrations
{
    /// <inheritdoc />
    public partial class customuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c175a4e1-f51b-4432-b943-f0d2571ef562");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9f947b7-4af0-412c-a121-7e3336eba8d4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "75a8af39-5c0a-44d0-9453-b6fe16a7c4fa", "1", "Admin", "Admin" },
                    { "95006f74-6f16-4347-b8f1-54881db3bbe5", "1", "User", "User" }
                });
            migrationBuilder.Sql("Insert into CustomUserDetails (UserName,Email) Select UserName,Email from ASPNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75a8af39-5c0a-44d0-9453-b6fe16a7c4fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95006f74-6f16-4347-b8f1-54881db3bbe5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c175a4e1-f51b-4432-b943-f0d2571ef562", "1", "Admin", "Admin" },
                    { "d9f947b7-4af0-412c-a121-7e3336eba8d4", "1", "User", "User" }
                });
        }
    }
}
