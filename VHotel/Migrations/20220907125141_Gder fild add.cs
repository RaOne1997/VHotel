using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeMuTrip.Migrations
{
    public partial class Gderfildadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "customers",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "customers");
        }
    }
}
