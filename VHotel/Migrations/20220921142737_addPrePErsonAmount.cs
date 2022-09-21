using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHotel.Migrations
{
    public partial class addPrePErsonAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "price",
                schema: "TransactionData",
                table: "FlightSchedule",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                schema: "TransactionData",
                table: "FlightSchedule");
        }
    }
}
