using Microsoft.EntityFrameworkCore;
using MakeMuTrip.DataAccess;
using staticclassmodel.Modelss;
using Vhotels.DataAccess.Model;
using Microsoft.AspNetCore.Identity;
using VHotel.DataAccess.Model.Master;

namespace staticclassmodel.Models
{
    public class StaticInsert : IStaticInsert
    {
        private readonly VhotelsSQLContex _vhotelsSQLContex;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        public StaticInsert(VhotelsSQLContex vhotelsSQLContex,
                RoleManager<IdentityRole> roleManager,
                UserManager<User> userManager)
        {
            _vhotelsSQLContex = vhotelsSQLContex;
            _roleManager = roleManager;
            _userManager = userManager;
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

                //foreach (var lists in Utility.InsertFlightBooking())
                //{
                //    _vhotelsSQLContex.flightBookings.Add(lists);
                //    _vhotelsSQLContex.SaveChanges();
                //}
            }

            if (_vhotelsSQLContex.Roles.ToList().Count == 0)
            {
                foreach (var lists in Utility.InsertRoles())
                {
                    _roleManager.CreateAsync(lists).GetAwaiter().GetResult();


                }
            }

            if (_vhotelsSQLContex.Users.ToList().Count == 0)
            {
                insertAdminUser();
            }
        }

        public void insertAdminUser()
        {
            _userManager.CreateAsync(new User
            {
                UserName = "super@super.com",
                Email = "super@super.com",
                FirstName = "super",
                LastName = " super",
                PhoneNumber = "7057445611",
            }, password: "Abhi@123").GetAwaiter().GetResult();

            User user1 = _vhotelsSQLContex.Users.FirstOrDefault(u => u.Email == "super@super.com");

            _userManager.AddToRoleAsync(user1, StaticValue.Roles[1]).GetAwaiter().GetResult();



            _userManager.CreateAsync(new User
            {
                UserName = "Admin@Admin.com",
                Email = "Admin@Admin.com",
                FirstName = "Abhijeet",
                LastName = " warade",
                PhoneNumber = "7057445611",
            }, password: "Abhi@123").GetAwaiter().GetResult();

            User user2 = _vhotelsSQLContex.Users.FirstOrDefault(u => u.Email == "Admin@Admin.com");

            _userManager.AddToRoleAsync(user2, StaticValue.Roles[0]).GetAwaiter().GetResult();



            _userManager.CreateAsync(new User
            {
                UserName = "User@user.com",
                Email = "user@user.com",
                FirstName = "user",
                LastName = " user",
                PhoneNumber = "7057445611",
            }, password: "Abhi@123").GetAwaiter().GetResult();

            User user3 = _vhotelsSQLContex.Users.FirstOrDefault(u => u.Email == "user@user.com");

            _userManager.AddToRoleAsync(user3, StaticValue.Roles[2]).GetAwaiter().GetResult();



            _userManager.CreateAsync(new User
            {
                UserName = "Airline@airline.com",
                Email = "Airline@airline.com",
                FirstName = "airine",
                LastName = " airine",
                PhoneNumber = "7057445611",
            }, password: "Abhi@123").GetAwaiter().GetResult();

            User user4 = _vhotelsSQLContex.Users.FirstOrDefault(u => u.Email == "Airline@airline.com");

            _userManager.AddToRoleAsync(user4, StaticValue.Roles[3]).GetAwaiter().GetResult();



            _userManager.CreateAsync(new User
            {
                UserName = "Hotel@Hotel.com",
                Email = "Hotel@Hotel.com",
                FirstName = "Hotel",
                LastName = " Hotel",
                PhoneNumber = "7057445611",
            }, password: "Abhi@123").GetAwaiter().GetResult();

            User user5 = _vhotelsSQLContex.Users.FirstOrDefault(u => u.Email == "Hotel@Hotel.com");

            _userManager.AddToRoleAsync(user5, StaticValue.Roles[4]).GetAwaiter().GetResult();



        }
    }
}

