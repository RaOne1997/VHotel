using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHotel.Migrations
{
    public partial class changefilghtbooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PassengerNameRecord",
                schema: "TransactionData",
                table: "FlightBooking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirlineRefId",
                table: "Flight",
                column: "AirlineRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_AirlineDetails_AirlineRefId",
                table: "Flight",
                column: "AirlineRefId",
                principalSchema: "Master",
                principalTable: "AirlineDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_AirlineDetails_AirlineRefId",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_AirlineRefId",
                table: "Flight");

            migrationBuilder.AlterColumn<int>(
                name: "PassengerNameRecord",
                schema: "TransactionData",
                table: "FlightBooking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
