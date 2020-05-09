using Microsoft.EntityFrameworkCore.Migrations;

namespace web_scraper.Data.Migrations
{
    public partial class InitialMigrationProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tv",
                table: "Tv");

            migrationBuilder.DeleteData(
                table: "Tv",
                keyColumn: "TvId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tv",
                keyColumn: "TvId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "TvId",
                table: "Tv");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Tv",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Tv",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SiteUrl",
                table: "Tv",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tv",
                table: "Tv",
                column: "ProductId");

            migrationBuilder.InsertData(
                table: "Tv",
                columns: new[] { "ProductId", "Brand", "CategoryId", "ImageThumbnailUrl", "ImageUrl", "LongDescription", "Model", "Price", "ProductName", "ShortDescription", "SiteUrl" },
                values: new object[] { 1, "Samsung", 1, "", "", "Samsung 65 inch TU 8000 Series 4K TV", "UN65TU8000FXZA", 697.99m, null, "Samsung 65 inch TU 8000", null });

            migrationBuilder.InsertData(
                table: "Tv",
                columns: new[] { "ProductId", "Brand", "CategoryId", "ImageThumbnailUrl", "ImageUrl", "LongDescription", "Model", "Price", "ProductName", "ShortDescription", "SiteUrl" },
                values: new object[] { 2, "TCL", 1, "", "", "TCL 55 inch 4 Series 4K TV", "55S425", 279.99m, null, "TCL 55 inch 4 Series", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tv",
                table: "Tv");

            migrationBuilder.DeleteData(
                table: "Tv",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tv",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Tv");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Tv");

            migrationBuilder.DropColumn(
                name: "SiteUrl",
                table: "Tv");

            migrationBuilder.AddColumn<int>(
                name: "TvId",
                table: "Tv",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tv",
                table: "Tv",
                column: "TvId");

            migrationBuilder.InsertData(
                table: "Tv",
                columns: new[] { "TvId", "Brand", "CategoryId", "ImageThumbnailUrl", "ImageUrl", "LongDescription", "Model", "Price", "ShortDescription" },
                values: new object[] { 1, "Samsung", 1, "", "", "Samsung 65 inch TU 8000 Series 4K TV", "UN65TU8000FXZA", 697.99m, "Samsung 65 inch TU 8000" });

            migrationBuilder.InsertData(
                table: "Tv",
                columns: new[] { "TvId", "Brand", "CategoryId", "ImageThumbnailUrl", "ImageUrl", "LongDescription", "Model", "Price", "ShortDescription" },
                values: new object[] { 2, "TCL", 1, "", "", "TCL 55 inch 4 Series 4K TV", "55S425", 279.99m, "TCL 55 inch 4 Series" });
        }
    }
}
