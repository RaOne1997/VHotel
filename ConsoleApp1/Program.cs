// See https://aka.ms/new-console-template for more information
using VHotel.DataAccess;

Console.WriteLine("Hello, World!");

IRoomServices roomServices = new RoomServices();

roomServices.AddRoomAsync();

roomServices.