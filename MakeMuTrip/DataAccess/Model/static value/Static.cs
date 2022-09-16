using Microsoft.EntityFrameworkCore;
using MakeMuTrip.DataAccess;

namespace staticclassmodel.Models
{
    public class StaticInsert : IStaticInsert
    {
        private readonly VhotelsSQLContex _vhotelsSQLContex;
        public StaticInsert(VhotelsSQLContex vhotelsSQLContex)
        {
            _vhotelsSQLContex = vhotelsSQLContex;
        }

        public void start()
        {
            try
            {
                if (_vhotelsSQLContex.Database.GetPendingMigrations().Count() > 0)
                {
                    _vhotelsSQLContex.Database.Migrate();
                }

            }
            catch (Exception ex)
            {

            }
            var count11 = _vhotelsSQLContex.accounts.ToList();
            if (count11.Count == 0)
            {
                
                    _vhotelsSQLContex.accounts.Add(Utility.InsertAccount());
                    _vhotelsSQLContex.SaveChanges();
                
            }
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


            var count10 = _vhotelsSQLContex.airlineDetails.ToList();
            if (count6.Count == 0)
            {
                foreach (var lists in Utility.InsertAirline())
                {
                    _vhotelsSQLContex.airlineDetails.Add(lists);
                    _vhotelsSQLContex.SaveChanges();
                }
            }
            var count9 = _vhotelsSQLContex.Flights.ToList();
            if (count6.Count == 0)
            {
                foreach (var lists in Utility.InsertFlight())
                {
                    _vhotelsSQLContex.Flights.Add(lists);
                    _vhotelsSQLContex.SaveChanges();
                }
            }



            var count7 = _vhotelsSQLContex.flightBookings.ToList();
            if (count7.Count == 0)
            {
                _vhotelsSQLContex.flightSchedules.Add(Utility.InsertSchedule());
                _vhotelsSQLContex.SaveChanges();

                foreach (var lists in Utility.InsertFlightBooking())
                {
                    _vhotelsSQLContex.flightBookings.Add(lists);
                    _vhotelsSQLContex.SaveChanges();
                }
            }
        }
    }
}

