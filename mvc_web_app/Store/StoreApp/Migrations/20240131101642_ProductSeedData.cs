using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Migrations
{
    public partial class ProductSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "productId", "price", "productName" },
                values: new object[] { 1, 20000m, "Computer" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "productId", "price", "productName" },
                values: new object[] { 2, 1000m, "Keyboard" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "productId", "price", "productName" },
                values: new object[] { 3, 500m, "Mouse" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "productId", "price", "productName" },
                values: new object[] { 4, 10000m, "Monitor" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "productId", "price", "productName" },
                values: new object[] { 5, 1500m, "Deck" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "productId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "productId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "productId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "productId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "productId",
                keyValue: 5);
        }
    }
}
