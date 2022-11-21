using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHotel.Migrations
{
    public partial class AirportImageadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "AirportImage",
                schema: "RoomDetails",
                table: "Airport",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirportImage",
                schema: "RoomDetails",
                table: "Airport");
        }
    }
}
