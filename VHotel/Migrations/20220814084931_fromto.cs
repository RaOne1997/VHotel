using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeMuTrip.Migrations
{
    public partial class fromto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Flight_FromAirportRefId",
                table: "Flight",
                column: "FromAirportRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_ToAirportRefId",
                table: "Flight",
                column: "ToAirportRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airport_FromAirportRefId",
                table: "Flight",
                column: "FromAirportRefId",
                principalSchema: "RoomDetails",
                principalTable: "Airport",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airport_ToAirportRefId",
                table: "Flight",
                column: "ToAirportRefId",
                principalSchema: "RoomDetails",
                principalTable: "Airport",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airport_FromAirportRefId",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airport_ToAirportRefId",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_FromAirportRefId",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_ToAirportRefId",
                table: "Flight");
        }
    }
}
