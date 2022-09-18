using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeMuTrip.Migrations
{
    public partial class customerbookinginf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightCustomerDetail_customers_CustomerRefId",
                schema: "TransactionData",
                table: "FlightCustomerDetail");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightCustomerDetail_CustomerInformation_CustomerRefId",
                schema: "TransactionData",
                table: "FlightCustomerDetail",
                column: "CustomerRefId",
                principalTable: "CustomerInformation",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightCustomerDetail_CustomerInformation_CustomerRefId",
                schema: "TransactionData",
                table: "FlightCustomerDetail");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightCustomerDetail_customers_CustomerRefId",
                schema: "TransactionData",
                table: "FlightCustomerDetail",
                column: "CustomerRefId",
                principalTable: "customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
