using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeMuTrip.Migrations
{
    public partial class useriddatatypechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightBooking_Account_AccountRefID",
                schema: "TransactionData",
                table: "FlightBooking");

            migrationBuilder.AlterColumn<string>(
                name: "AccountRefID",
                schema: "TransactionData",
                table: "FlightBooking",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightBooking_AspNetUsers_AccountRefID",
                schema: "TransactionData",
                table: "FlightBooking",
                column: "AccountRefID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightBooking_AspNetUsers_AccountRefID",
                schema: "TransactionData",
                table: "FlightBooking");

            migrationBuilder.AlterColumn<int>(
                name: "AccountRefID",
                schema: "TransactionData",
                table: "FlightBooking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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
    }
}
