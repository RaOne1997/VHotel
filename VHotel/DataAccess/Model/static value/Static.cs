using VHotel.DataAccess;

namespace staticclassmodel.Models
{
    public static class StaticInsert
    {
        public static void start(VhotelsSQLContex _vhotelsSQLContex)
        {
            var count = _vhotelsSQLContex.countries.ToList();
            if (count.Count == 0)
            {
                foreach (var lists in Utility.InsertCountery())
                {
                    _vhotelsSQLContex.countries.Add(lists);
                    _vhotelsSQLContex.SaveChanges();
                }
            }
            var count2 = _vhotelsSQLContex.states.ToList();
            if (count2.Count == 0)
            {
                foreach (var lists in Utility.InsertState())
                {
                    _vhotelsSQLContex.states.Add(lists);
                    _vhotelsSQLContex.SaveChanges();
                }
            }
            var count3 = _vhotelsSQLContex.types.ToList();
            if (count3.Count == 0)
            {
                foreach (var lists in Utility.RoomTYpes())
                {
                    _vhotelsSQLContex.types.Add(lists);
                    _vhotelsSQLContex.SaveChanges();
                }
            }
            var count4 = _vhotelsSQLContex.rooms.ToList();
            if (count4.Count == 0)
            {
                foreach (var lists in Utility.Fakerroomdaya())
                {
                    _vhotelsSQLContex.rooms.Add(lists);
                    _vhotelsSQLContex.SaveChanges();
                }
            }

            var count5 = _vhotelsSQLContex.cityMasters.ToList();
            if (count5.Count == 0)
            {
                foreach (var lists in Utility.InsertCity())
                {
                    _vhotelsSQLContex.cityMasters.Add(lists);
                    _vhotelsSQLContex.SaveChanges();
                }
            }

            var count6 = _vhotelsSQLContex.airports.ToList();
            if (count6.Count == 0)
            {
                foreach (var lists in Utility.InsertAirport())
                {
                    _vhotelsSQLContex.airports.Add(lists);
                    _vhotelsSQLContex.SaveChanges();
                }
            }
        }
    }
}

