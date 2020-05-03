using Microsoft.EntityFrameworkCore.Migrations;

namespace web_scraper.Data.Migrations
{
    public partial class InitialMigrationTv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Tv",
                columns: table => new
                {
                    TvId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    LongDescription = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    ImageThumbnailUrl = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tv", x => x.TvId);
                    table.ForeignKey(
                        name: "FK_Tv_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 1, "TV", "Televisions" });

            migrationBuilder.InsertData(
                table: "Tv",
                columns: new[] { "TvId", "Brand", "CategoryId", "ImageThumbnailUrl", "ImageUrl", "LongDescription", "Model", "Price", "ShortDescription" },
                values: new object[] { 1, "Samsung", 1, "", "", "Samsung 65 inch TU 8000 Series 4K TV", "UN65TU8000FXZA", 697.99m, "Samsung 65 inch TU 8000" });

            migrationBuilder.InsertData(
                table: "Tv",
                columns: new[] { "TvId", "Brand", "CategoryId", "ImageThumbnailUrl", "ImageUrl", "LongDescription", "Model", "Price", "ShortDescription" },
                values: new object[] { 2, "TCL", 1, "", "", "TCL 55 inch 4 Series 4K TV", "55S425", 279.99m, "TCL 55 inch 4 Series" });

            migrationBuilder.CreateIndex(
                name: "IX_Tv_CategoryId",
                table: "Tv",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tv");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
