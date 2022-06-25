using VHotel.DataAccess.Model;

namespace VHotel.DataAccess
{
    public class Utility
    {

        public List<Room> Fakerroomdaya()
        {
            List<Room> roomlist = new List<Room>();

            for (int i = 0; i < 10; i++)
            {
                var room = new Room
                {
                    RoomNumber = Faker.RandomNumber.Next(100, 110).ToString(),
                    RoomTypeRefID = (int)Faker.Enum.Random<RoomTYpe>(),
                    RoomLevel = Faker.RandomNumber.Next(1, 4),
                    RoomPrice = Faker.RandomNumber.Next(100, 3000),
                    Description = Faker.Lorem.Paragraph(10)
                };
                roomlist.Add(room);
            }
            return roomlist;
        }

        enum RoomTYpe
        {

            Single = 1,
            Double,
            Triple,
            Quad,
            King,
            Doubledouble,
            SuiteExecutiveSuite,
        }
    }
}
