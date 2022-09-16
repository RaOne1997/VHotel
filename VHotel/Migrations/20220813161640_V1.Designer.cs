﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MakeMuTrip.DataAccess;

#nullable disable

namespace MakeMuTrip.Migrations
{
    [DbContext(typeof(VhotelsSQLContex))]
    [Migration("20220813161640_V1")]
    partial class V1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.Master.AirlineDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<byte[]>("AirlineLogo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("AirlineName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("HelplineNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Telephone2")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.ToTable("AirlineDetails", "Master");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.Master.Airport", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AirportCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AirportName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityRefId")
                        .HasColumnType("int");

                    b.Property<string>("Email1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email2public")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PinCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Telephone2")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("AirportCode")
                        .IsUnique()
                        .HasFilter("[AirportCode] IS NOT NULL");

                    b.HasIndex("CityRefId");

                    b.HasIndex("Email1")
                        .IsUnique()
                        .HasFilter("[Email1] IS NOT NULL");

                    b.HasIndex("Email2public")
                        .IsUnique()
                        .HasFilter("[Email2public] IS NOT NULL");

                    b.HasIndex("Telephone1")
                        .IsUnique()
                        .HasFilter("[Telephone1] IS NOT NULL");

                    b.HasIndex("Telephone2")
                        .IsUnique()
                        .HasFilter("[Telephone2] IS NOT NULL");

                    b.ToTable("Airport", "RoomDetails");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.Master.Amenities", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Description1")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description2")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description3")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description4")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description5")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("amenities");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.Master.CityMaster", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("stateRefID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("stateRefID");

                    b.ToTable("CityMaster", "MasterData");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.Master.Country", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CountryMaster", "MasterData");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.Master.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityRefId")
                        .HasColumnType("int");

                    b.Property<int>("CountryRefId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PinCode")
                        .HasColumnType("bigint");

                    b.Property<byte[]>("ProfilePhoto")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("StateRefId")
                        .HasColumnType("int");

                    b.Property<long>("Telephone1")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("CityRefId");

                    b.HasIndex("CountryRefId");

                    b.HasIndex("StateRefId");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.Master.Flight", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AirlineRefId")
                        .HasColumnType("int");

                    b.Property<string>("FlightCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FromAirportRefId")
                        .HasColumnType("int");

                    b.Property<int>("ToAirportRefId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AirlineRefId");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.Master.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryRefID")
                        .HasColumnType("int");

                    b.Property<int>("GaustNo")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<byte[]>("HotelImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("HotelRating")
                        .HasColumnType("int");

                    b.Property<string>("Landmark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pincode")
                        .HasColumnType("int");

                    b.Property<int>("StaterefID")
                        .HasColumnType("int");

                    b.Property<DateTime>("checkin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("checkout")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("CountryRefID");

                    b.HasIndex("StaterefID");

                    b.ToTable("Hotel", "Hotels");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.Master.HotelAmenitiesLink", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AmenitiesRefId")
                        .HasColumnType("int");

                    b.Property<int>("HotelRefId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AmenitiesRefId");

                    b.HasIndex("HotelRefId");

                    b.ToTable("HotelAmenitiesLink", "Hotel");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.Master.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HotelRefID")
                        .HasColumnType("int");

                    b.Property<byte[]>("RoomImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RoomLevel")
                        .HasColumnType("int");

                    b.Property<string>("RoomNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("RoomPrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("RoomTypeRefID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("HotelRefID");

                    b.HasIndex("RoomNumber")
                        .IsUnique()
                        .HasFilter("[RoomNumber] IS NOT NULL");

                    b.HasIndex("RoomTypeRefID");

                    b.ToTable("RoomDetails", "RoomDetails");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.Master.State", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CountryrefID")
                        .HasColumnType("int");

                    b.Property<string>("StateID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CountryrefID");

                    b.ToTable("StateMaster", "MasterData");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.TransactionData.FlightBooking", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<TimeSpan>("BookingTimeStamp")
                        .HasColumnType("time");

                    b.Property<string>("CustomerContactEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerContactMobile")
                        .HasColumnType("int");

                    b.Property<int>("FlightScheduleRefId")
                        .HasColumnType("int");

                    b.Property<int?>("PassengerNameRecord")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FlightScheduleRefId");

                    b.ToTable("FlightBooking", "TransactionData");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.TransactionData.FlightCustomerDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CustomerRefId")
                        .HasColumnType("int");

                    b.Property<int>("FlightBookingRefId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CustomerRefId");

                    b.HasIndex("FlightBookingRefId");

                    b.ToTable("FlightCustomerDetail", "TransactionData");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.TransactionData.FlightSchedule", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime?>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FlightRefId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FlightRefId");

                    b.ToTable("FlightSchedule", "TransactionData");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.TransactionData.HotelBooking", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("ConfirmationCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HotelRefId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("HotelRefId");

                    b.ToTable("HotelBooking", "HotelTransactionData");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.TransactionData.HotelCustomerDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CustomerRefId")
                        .HasColumnType("int");

                    b.Property<int>("HotelBookingRefId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CustomerRefId");

                    b.HasIndex("HotelBookingRefId");

                    b.ToTable("HotelCustomerDetail", "TransactionData");
                });

            modelBuilder.Entity("Type", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("RoomType")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("RoomType")
                        .IsUnique()
                        .HasFilter("[RoomType] IS NOT NULL");

                    b.ToTable("RoomTypes", "RoomDetails");
                });

            modelBuilder.Entity("VHotel.DataAccess.Model.TransactionData.Customerinformation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("PassengerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("flightBookingRefID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("flightBookingRefID");

                    b.ToTable("CustomerInformation");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.Master.Airport", b =>
                {
                    b.HasOne("staticclassmodel.DataAccess.Model.Master.CityMaster", "CityMaster")
                        .WithMany()
                        .HasForeignKey("CityRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CityMaster");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.Master.CityMaster", b =>
                {
                    b.HasOne("staticclassmodel.DataAccess.Model.Master.State", "State")
                        .WithMany()
                        .HasForeignKey("stateRefID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.Master.Customer", b =>
                {
                    b.HasOne("staticclassmodel.DataAccess.Model.Master.CityMaster", "CityMaster")
                        .WithMany()
                        .HasForeignKey("CityRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("staticclassmodel.DataAccess.Model.Master.Country", "country")
                        .WithMany()
                        .HasForeignKey("CountryRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("staticclassmodel.DataAccess.Model.Master.State", "state")
                        .WithMany()
                        .HasForeignKey("StateRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CityMaster");

                    b.Navigation("country");

                    b.Navigation("state");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.Master.Flight", b =>
                {
                    b.HasOne("staticclassmodel.DataAccess.Model.Master.AirlineDetails", "airlineDetails")
                        .WithMany()
                        .HasForeignKey("AirlineRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("airlineDetails");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.Master.Hotel", b =>
                {
                    b.HasOne("staticclassmodel.DataAccess.Model.Master.Country", "country")
                        .WithMany()
                        .HasForeignKey("CountryRefID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("staticclassmodel.DataAccess.Model.Master.State", "state")
                        .WithMany()
                        .HasForeignKey("StaterefID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("country");

                    b.Navigation("state");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.Master.HotelAmenitiesLink", b =>
                {
                    b.HasOne("staticclassmodel.DataAccess.Model.Master.Amenities", "AmenitiesRef")
                        .WithMany()
                        .HasForeignKey("AmenitiesRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("staticclassmodel.DataAccess.Model.Master.Hotel", "hotel")
                        .WithMany()
                        .HasForeignKey("HotelRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AmenitiesRef");

                    b.Navigation("hotel");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.Master.Room", b =>
                {
                    b.HasOne("staticclassmodel.DataAccess.Model.Master.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelRefID");

                    b.HasOne("Type", "type")
                        .WithMany()
                        .HasForeignKey("RoomTypeRefID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("type");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.Master.State", b =>
                {
                    b.HasOne("staticclassmodel.DataAccess.Model.Master.Country", "Countryref")
                        .WithMany()
                        .HasForeignKey("CountryrefID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Countryref");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.TransactionData.FlightBooking", b =>
                {
                    b.HasOne("staticclassmodel.DataAccess.Model.TransactionData.FlightSchedule", "flightSchedule")
                        .WithMany()
                        .HasForeignKey("FlightScheduleRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("flightSchedule");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.TransactionData.FlightCustomerDetail", b =>
                {
                    b.HasOne("staticclassmodel.DataAccess.Model.Master.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("CustomerRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("staticclassmodel.DataAccess.Model.TransactionData.FlightBooking", "flightBooking")
                        .WithMany()
                        .HasForeignKey("FlightBookingRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");

                    b.Navigation("flightBooking");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.TransactionData.FlightSchedule", b =>
                {
                    b.HasOne("staticclassmodel.DataAccess.Model.Master.Flight", "flight")
                        .WithMany()
                        .HasForeignKey("FlightRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("flight");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.TransactionData.HotelBooking", b =>
                {
                    b.HasOne("staticclassmodel.DataAccess.Model.Master.Hotel", "hotel")
                        .WithMany()
                        .HasForeignKey("HotelRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("hotel");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.TransactionData.HotelCustomerDetail", b =>
                {
                    b.HasOne("staticclassmodel.DataAccess.Model.Master.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("CustomerRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("staticclassmodel.DataAccess.Model.TransactionData.HotelBooking", "hotelBooking")
                        .WithMany()
                        .HasForeignKey("HotelBookingRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");

                    b.Navigation("hotelBooking");
                });

            modelBuilder.Entity("VHotel.DataAccess.Model.TransactionData.Customerinformation", b =>
                {
                    b.HasOne("staticclassmodel.DataAccess.Model.TransactionData.FlightBooking", "flightBooking")
                        .WithMany("FlightCustomerDetails")
                        .HasForeignKey("flightBookingRefID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("flightBooking");
                });

            modelBuilder.Entity("staticclassmodel.DataAccess.Model.TransactionData.FlightBooking", b =>
                {
                    b.Navigation("FlightCustomerDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
