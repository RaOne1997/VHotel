using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHotel.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_RoomTypes_RoomTypeRefID",
                schema: "Hotels",
                table: "Hotel");

            migrationBuilder.DropIndex(
                name: "IX_Hotel_RoomTypeRefID",
                schema: "Hotels",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "RoomTypeRefID",
                schema: "Hotels",
                table: "Hotel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomTypeRefID",
                schema: "Hotels",
                table: "Hotel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_RoomTypeRefID",
                schema: "Hotels",
                table: "Hotel",
                column: "RoomTypeRefID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_RoomTypes_RoomTypeRefID",
                schema: "Hotels",
                table: "Hotel",
                column: "RoomTypeRefID",
                principalSchema: "RoomDetails",
                principalTable: "RoomTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
