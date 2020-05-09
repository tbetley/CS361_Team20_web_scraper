using Microsoft.EntityFrameworkCore.Migrations;

namespace web_scraper.Data.Migrations
{
    public partial class InitialMigrationAccessory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tv_Categories_CategoryId",
                table: "Tv");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tv",
                table: "Tv");

            migrationBuilder.RenameTable(
                name: "Tv",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Tv_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 2, "Accessory", "Accessories" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Brand", "CategoryId", "ImageThumbnailUrl", "ImageUrl", "LongDescription", "Model", "Price", "ProductName", "ShortDescription", "SiteUrl" },
                values: new object[] { 3, "Logitech", 2, "", "", "Logitech Harmony Remote 950 Advanced Universal Remote", "Harmony 950", 249.99m, null, "Logitech Harmony Remote 950", null });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Tv");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Tv",
                newName: "IX_Tv_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tv",
                table: "Tv",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tv_Categories_CategoryId",
                table: "Tv",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
