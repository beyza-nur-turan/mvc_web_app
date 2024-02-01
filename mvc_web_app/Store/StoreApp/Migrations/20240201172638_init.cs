using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    productName = table.Column<string>(type: "TEXT", nullable: false),
                    price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productId);
                });

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
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
