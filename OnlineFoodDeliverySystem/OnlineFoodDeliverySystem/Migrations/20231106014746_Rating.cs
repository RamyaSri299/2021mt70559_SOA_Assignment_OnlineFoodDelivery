using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineFoodDeliverySystem.Migrations
{
    /// <inheritdoc />
    public partial class Rating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75a8af39-5c0a-44d0-9453-b6fe16a7c4fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95006f74-6f16-4347-b8f1-54881db3bbe5");

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    rating_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rating = table.Column<int>(type: "int", nullable: true),
                    restaurant_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.rating_id);
                    table.ForeignKey(
                        name: "FK_Rating_RestaurantDetails_restaurant_id",
                        column: x => x.restaurant_id,
                        principalTable: "RestaurantDetails",
                        principalColumn: "Restaurant_id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d3dd3f8-1c67-43d8-a122-afe7e1e2d877", "1", "Admin", "Admin" },
                    { "561494a1-d5e3-41d3-a408-ad6830116182", "1", "User", "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rating_restaurant_id",
                table: "Rating",
                column: "restaurant_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d3dd3f8-1c67-43d8-a122-afe7e1e2d877");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "561494a1-d5e3-41d3-a408-ad6830116182");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "75a8af39-5c0a-44d0-9453-b6fe16a7c4fa", "1", "Admin", "Admin" },
                    { "95006f74-6f16-4347-b8f1-54881db3bbe5", "1", "User", "User" }
                });
        }
    }
}
