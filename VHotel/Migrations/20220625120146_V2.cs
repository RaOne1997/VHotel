using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHotel.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RoomTypeRefID",
                schema: "RoomDetails",
                table: "RoomDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_RoomDetails_RoomTypeRefID",
                schema: "RoomDetails",
                table: "RoomDetails",
                column: "RoomTypeRefID");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomDetails_RoomTypes_RoomTypeRefID",
                schema: "RoomDetails",
                table: "RoomDetails",
                column: "RoomTypeRefID",
                principalSchema: "RoomDetails",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomDetails_RoomTypes_RoomTypeRefID",
                schema: "RoomDetails",
                table: "RoomDetails");

            migrationBuilder.DropIndex(
                name: "IX_RoomDetails_RoomTypeRefID",
                schema: "RoomDetails",
                table: "RoomDetails");

            migrationBuilder.AlterColumn<string>(
                name: "RoomTypeRefID",
                schema: "RoomDetails",
                table: "RoomDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
