using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeMuTrip.Migrations
{
    public partial class keyadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountRefID",
                schema: "TransactionData",
                table: "FlightBooking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FlightBooking_AccountRefID",
                schema: "TransactionData",
                table: "FlightBooking",
                column: "AccountRefID");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightBooking_Account_AccountRefID",
                schema: "TransactionData",
                table: "FlightBooking",
                column: "AccountRefID",
                principalSchema: "Master",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightBooking_Account_AccountRefID",
                schema: "TransactionData",
                table: "FlightBooking");

            migrationBuilder.DropIndex(
                name: "IX_FlightBooking_AccountRefID",
                schema: "TransactionData",
                table: "FlightBooking");

            migrationBuilder.DropColumn(
                name: "AccountRefID",
                schema: "TransactionData",
                table: "FlightBooking");
        }
    }
}
