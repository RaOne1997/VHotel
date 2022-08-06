using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeMyTrip.Migrations
{
    public partial class BookRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BooksCategories",
                table: "books");

            migrationBuilder.DropColumn(
                name: "url",
                table: "books");

            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutherName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "bookdetals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bookrefid = table.Column<int>(type: "int", nullable: false),
                    AuthorsRefID = table.Column<int>(type: "int", nullable: false),
                    publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isbn10 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriesRefid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookdetals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_bookdetals_authors_Bookrefid",
                        column: x => x.Bookrefid,
                        principalTable: "authors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_bookdetals_books_Bookrefid",
                        column: x => x.Bookrefid,
                        principalTable: "books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_bookdetals_categories_CategoriesRefid",
                        column: x => x.CategoriesRefid,
                        principalTable: "categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookdetals_Bookrefid",
                table: "bookdetals",
                column: "Bookrefid");

            migrationBuilder.CreateIndex(
                name: "IX_bookdetals_CategoriesRefid",
                table: "bookdetals",
                column: "CategoriesRefid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookdetals");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.AddColumn<string>(
                name: "BooksCategories",
                table: "books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "url",
                table: "books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
