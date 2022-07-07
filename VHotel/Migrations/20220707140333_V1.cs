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
                name: "Master");

            migrationBuilder.EnsureSchema(
                name: "RoomDetails");

            migrationBuilder.EnsureSchema(
                name: "MasterData");

            migrationBuilder.EnsureSchema(
                name: "TransactionData");

            migrationBuilder.EnsureSchema(
                name: "Hotels");

            migrationBuilder.EnsureSchema(
                name: "Hotel");

            migrationBuilder.EnsureSchema(
                name: "HotelTransactionData");

            migrationBuilder.CreateTable(
                name: "AirlineDetails",
                schema: "Master",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirlineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirlineLogo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HelplineNumber = table.Column<long>(type: "bigint", nullable: false),
                    Telephone2 = table.Column<long>(type: "bigint", nullable: false),
                    Email1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "amenities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amenities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CountryMaster",
                schema: "MasterData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirlineRefId = table.Column<int>(type: "int", nullable: false),
                    FromAirportRefId = table.Column<int>(type: "int", nullable: false),
                    ToAirportRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                schema: "RoomDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomType = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StateMaster",
                schema: "MasterData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryrefID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateMaster", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StateMaster_CountryMaster_CountryrefID",
                        column: x => x.CountryrefID,
                        principalSchema: "MasterData",
                        principalTable: "CountryMaster",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FlightSchedule",
                schema: "TransactionData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightRefId = table.Column<int>(type: "int", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightSchedule_Flight_FlightRefId",
                        column: x => x.FlightRefId,
                        principalTable: "Flight",
                        principalColumn: "ID",
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
                    RoomImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CityMaster",
                schema: "MasterData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stateRefID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityMaster", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CityMaster_StateMaster_stateRefID",
                        column: x => x.stateRefID,
                        principalSchema: "MasterData",
                        principalTable: "StateMaster",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                schema: "Hotels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    HotelImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HotelRating = table.Column<int>(type: "int", nullable: false),
                    checkout = table.Column<DateTime>(type: "datetime2", nullable: false),
                    checkin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GaustNo = table.Column<int>(type: "int", nullable: false),
                    RoomRefID = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaterefID = table.Column<int>(type: "int", nullable: false),
                    CountryRefID = table.Column<int>(type: "int", nullable: false),
                    Landmark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Hotel_CountryMaster_CountryRefID",
                        column: x => x.CountryRefID,
                        principalSchema: "MasterData",
                        principalTable: "CountryMaster",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Hotel_RoomDetails_RoomRefID",
                        column: x => x.RoomRefID,
                        principalSchema: "RoomDetails",
                        principalTable: "RoomDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Hotel_StateMaster_StaterefID",
                        column: x => x.StaterefID,
                        principalSchema: "MasterData",
                        principalTable: "StateMaster",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Airport",
                schema: "RoomDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirportCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityRefId = table.Column<int>(type: "int", nullable: false),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Telephone2 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email2public = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Airport_CityMaster_CityRefId",
                        column: x => x.CityRefId,
                        principalSchema: "MasterData",
                        principalTable: "CityMaster",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityRefId = table.Column<int>(type: "int", nullable: false),
                    StateRefId = table.Column<int>(type: "int", nullable: false),
                    CountryRefId = table.Column<int>(type: "int", nullable: false),
                    PinCode = table.Column<long>(type: "bigint", nullable: false),
                    Telephone1 = table.Column<long>(type: "bigint", nullable: false),
                    Email1 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_customers_CityMaster_CityRefId",
                        column: x => x.CityRefId,
                        principalSchema: "MasterData",
                        principalTable: "CityMaster",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_customers_CountryMaster_CountryRefId",
                        column: x => x.CountryRefId,
                        principalSchema: "MasterData",
                        principalTable: "CountryMaster",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_customers_StateMaster_StateRefId",
                        column: x => x.StateRefId,
                        principalSchema: "MasterData",
                        principalTable: "StateMaster",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HotelAmenitiesLink",
                schema: "Hotel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelRefId = table.Column<int>(type: "int", nullable: false),
                    AmenitiesRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelAmenitiesLink", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HotelAmenitiesLink_amenities_AmenitiesRefId",
                        column: x => x.AmenitiesRefId,
                        principalTable: "amenities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HotelAmenitiesLink_Hotel_HotelRefId",
                        column: x => x.HotelRefId,
                        principalSchema: "Hotels",
                        principalTable: "Hotel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HotelBooking",
                schema: "HotelTransactionData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelRefId = table.Column<int>(type: "int", nullable: false),
                    ConfirmationCode = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelBooking_Hotel_HotelRefId",
                        column: x => x.HotelRefId,
                        principalSchema: "Hotels",
                        principalTable: "Hotel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FlightBooking",
                schema: "TransactionData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassengerNameRecord = table.Column<int>(type: "int", nullable: false),
                    BookingTimeStamp = table.Column<TimeSpan>(type: "time", nullable: false),
                    CustomerRefId = table.Column<int>(type: "int", nullable: false),
                    FlightScheduleRefId = table.Column<int>(type: "int", nullable: false),
                    CustomerContactMobile = table.Column<int>(type: "int", nullable: false),
                    CustomerContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightBooking_customers_CustomerRefId",
                        column: x => x.CustomerRefId,
                        principalTable: "customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FlightBooking_FlightSchedule_FlightScheduleRefId",
                        column: x => x.FlightScheduleRefId,
                        principalSchema: "TransactionData",
                        principalTable: "FlightSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HotelCustomerDetail",
                schema: "TransactionData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelBookingRefId = table.Column<int>(type: "int", nullable: false),
                    CustomerRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelCustomerDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelCustomerDetail_customers_CustomerRefId",
                        column: x => x.CustomerRefId,
                        principalTable: "customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FlightCustomerDetail",
                schema: "TransactionData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightBookingRefId = table.Column<int>(type: "int", nullable: false),
                    CustomerRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightCustomerDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightCustomerDetail_customers_CustomerRefId",
                        column: x => x.CustomerRefId,
                        principalTable: "customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FlightCustomerDetail_FlightBooking_FlightBookingRefId",
                        column: x => x.FlightBookingRefId,
                        principalSchema: "TransactionData",
                        principalTable: "FlightBooking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airport_AirportCode",
                schema: "RoomDetails",
                table: "Airport",
                column: "AirportCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Airport_CityRefId",
                schema: "RoomDetails",
                table: "Airport",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Airport_Email1",
                schema: "RoomDetails",
                table: "Airport",
                column: "Email1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Airport_Email2public",
                schema: "RoomDetails",
                table: "Airport",
                column: "Email2public",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Airport_Telephone1",
                schema: "RoomDetails",
                table: "Airport",
                column: "Telephone1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Airport_Telephone2",
                schema: "RoomDetails",
                table: "Airport",
                column: "Telephone2",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CityMaster_stateRefID",
                schema: "MasterData",
                table: "CityMaster",
                column: "stateRefID");

            migrationBuilder.CreateIndex(
                name: "IX_customers_CityRefId",
                table: "customers",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_customers_CountryRefId",
                table: "customers",
                column: "CountryRefId");

            migrationBuilder.CreateIndex(
                name: "IX_customers_StateRefId",
                table: "customers",
                column: "StateRefId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightBooking_CustomerRefId",
                schema: "TransactionData",
                table: "FlightBooking",
                column: "CustomerRefId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightBooking_FlightScheduleRefId",
                schema: "TransactionData",
                table: "FlightBooking",
                column: "FlightScheduleRefId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightCustomerDetail_CustomerRefId",
                schema: "TransactionData",
                table: "FlightCustomerDetail",
                column: "CustomerRefId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightCustomerDetail_FlightBookingRefId",
                schema: "TransactionData",
                table: "FlightCustomerDetail",
                column: "FlightBookingRefId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSchedule_FlightRefId",
                schema: "TransactionData",
                table: "FlightSchedule",
                column: "FlightRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_CountryRefID",
                schema: "Hotels",
                table: "Hotel",
                column: "CountryRefID");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_RoomRefID",
                schema: "Hotels",
                table: "Hotel",
                column: "RoomRefID");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_StaterefID",
                schema: "Hotels",
                table: "Hotel",
                column: "StaterefID");

            migrationBuilder.CreateIndex(
                name: "IX_HotelAmenitiesLink_AmenitiesRefId",
                schema: "Hotel",
                table: "HotelAmenitiesLink",
                column: "AmenitiesRefId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelAmenitiesLink_HotelRefId",
                schema: "Hotel",
                table: "HotelAmenitiesLink",
                column: "HotelRefId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelBooking_HotelRefId",
                schema: "HotelTransactionData",
                table: "HotelBooking",
                column: "HotelRefId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelCustomerDetail_CustomerRefId",
                schema: "TransactionData",
                table: "HotelCustomerDetail",
                column: "CustomerRefId");

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
                schema: "MasterData",
                table: "StateMaster",
                column: "CountryrefID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirlineDetails",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Airport",
                schema: "RoomDetails");

            migrationBuilder.DropTable(
                name: "FlightCustomerDetail",
                schema: "TransactionData");

            migrationBuilder.DropTable(
                name: "HotelAmenitiesLink",
                schema: "Hotel");

            migrationBuilder.DropTable(
                name: "HotelBooking",
                schema: "HotelTransactionData");

            migrationBuilder.DropTable(
                name: "HotelCustomerDetail",
                schema: "TransactionData");

            migrationBuilder.DropTable(
                name: "FlightBooking",
                schema: "TransactionData");

            migrationBuilder.DropTable(
                name: "amenities");

            migrationBuilder.DropTable(
                name: "Hotel",
                schema: "Hotels");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "FlightSchedule",
                schema: "TransactionData");

            migrationBuilder.DropTable(
                name: "RoomDetails",
                schema: "RoomDetails");

            migrationBuilder.DropTable(
                name: "CityMaster",
                schema: "MasterData");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "RoomTypes",
                schema: "RoomDetails");

            migrationBuilder.DropTable(
                name: "StateMaster",
                schema: "MasterData");

            migrationBuilder.DropTable(
                name: "CountryMaster",
                schema: "MasterData");
        }
    }
}
