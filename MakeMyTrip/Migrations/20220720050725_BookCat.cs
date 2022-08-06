using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeMyTrip.Migrations
{
    public partial class BookCat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BooksCategories",
                table: "books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BooksCategories",
                table: "books");
        }
    }
}
