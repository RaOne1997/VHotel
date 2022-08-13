using staticclassmodel.DataAccess.Model.Master;

namespace VHotel.DataAccess
{
    public interface IUtility
    {
        List<Room> Fakerroomdaya();
        Customer FakerUserCustomer();
        List<Airport> InsertAirport();
        List<CityMaster> InsertCity();
        List<Country> InsertCountery();
        List<State> InsertState();
        List<Type> RoomTYpes();
    }
}