using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VHotel.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Location");

            migrationBuilder.EnsureSchema(
                name: "RoomDetails");

            migrationBuilder.CreateTable(
                name: "CountryMaster",
                schema: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                schema: "RoomDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomType = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StateMaster",
                schema: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryrefID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StateMaster_CountryMaster_CountryrefID",
                        column: x => x.CountryrefID,
                        principalSchema: "Location",
                        principalTable: "CountryMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RoomDetails",
                schema: "RoomDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoomTypeRefID = table.Column<int>(type: "int", nullable: false),
                    RoomImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RoomLevel = table.Column<int>(type: "int", nullable: false),
                    RoomPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RoomDetails_RoomTypes_RoomTypeRefID",
                        column: x => x.RoomTypeRefID,
                        principalSchema: "RoomDetails",
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    checkout = table.Column<DateTime>(type: "datetime2", nullable: false),
                    checkin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GaustNo = table.Column<int>(type: "int", nullable: false),
                    RoomtypeRef = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaterefID = table.Column<int>(type: "int", nullable: false),
                    CountryRefID = table.Column<int>(type: "int", nullable: false),
                    Landmark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hotels_CountryMaster_CountryRefID",
                        column: x => x.CountryRefID,
                        principalSchema: "Location",
                        principalTable: "CountryMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_hotels_RoomTypes_RoomtypeRef",
                        column: x => x.RoomtypeRef,
                        principalSchema: "RoomDetails",
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_hotels_StateMaster_StaterefID",
                        column: x => x.StaterefID,
                        principalSchema: "Location",
                        principalTable: "StateMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hotels_CountryRefID",
                table: "hotels",
                column: "CountryRefID");

            migrationBuilder.CreateIndex(
                name: "IX_hotels_RoomtypeRef",
                table: "hotels",
                column: "RoomtypeRef");

            migrationBuilder.CreateIndex(
                name: "IX_hotels_StaterefID",
                table: "hotels",
                column: "StaterefID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomDetails_RoomNumber",
                schema: "RoomDetails",
                table: "RoomDetails",
                column: "RoomNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomDetails_RoomTypeRefID",
                schema: "RoomDetails",
                table: "RoomDetails",
                column: "RoomTypeRefID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypes_RoomType",
                schema: "RoomDetails",
                table: "RoomTypes",
                column: "RoomType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StateMaster_CountryrefID",
                schema: "Location",
                table: "StateMaster",
                column: "CountryrefID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hotels");

            migrationBuilder.DropTable(
                name: "RoomDetails",
                schema: "RoomDetails");

            migrationBuilder.DropTable(
                name: "StateMaster",
                schema: "Location");

            migrationBuilder.DropTable(
                name: "RoomTypes",
                schema: "RoomDetails");

            migrationBuilder.DropTable(
                name: "CountryMaster",
                schema: "Location");
        }
    }
}
