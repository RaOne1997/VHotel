using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHotel.Migrations
{
    public partial class IsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Isactive",
                schema: "RoomDetails",
                table: "Airport",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Isactive",
                schema: "RoomDetails",
                table: "Airport");
        }
    }
}
