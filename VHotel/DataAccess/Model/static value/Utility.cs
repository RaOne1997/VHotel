using Microsoft.AspNetCore.Identity;
using staticclassmodel.DataAccess.Model.Masters;
using staticclassmodel.DataAccess.Model.TransactionData;
using Vhotel.DataAccess.Model.Master;
using Vhotel.DataAccess.Model.TransactionData;
using VHotel.DataAccess.Model.Master;
using Vhotels.DataAccess.Model;

namespace MakeMuTrip.DataAccess
{
    public class Utility
    {

        public static List<Room> Fakerroomdaya()
        {
            List<Room> roomlist = new();

            for (int i = 0; i < 10; i++)
            {
                var room = new Room
                {
                    RoomNumber = (100 + i).ToString(),
                    RoomTypeRefID = (int)Faker.Enum.Random<RoomTYpe>(),
                    RoomLevel = Faker.RandomNumber.Next(1, 4),
                    RoomPrice = Faker.RandomNumber.Next(100, 3000),
                    Description = Faker.Lorem.Paragraph(10)
                };
                roomlist.Add(room);
            }

            return roomlist;
        }



        public static Customer FakerUserCustomer()
        {
            var room = new Customer
            {

                FirstName = Faker.Name.First(),
                LastName = Faker.Name.Last(),
                DateOfBirth = Faker.Identification.DateOfBirth(),
                Address1 = Faker.Address.StreetSuffix(),
                Address2 = Faker.Address.StreetAddress(true),
                Address3 = Faker.Address.SecondaryAddress(),
                CityRefId = 1,
                StateRefId = (int)Faker.Enum.Random<statename>(),
                CountryRefId = 240,
                PinCode = 522410,
                Telephone1 = 44572,
                Email1 = Faker.Internet.FreeEmail()

            };



            return room;
        }
        public static List<Type> RoomTYpes()
        {
            var list = new List<string> { "Single", "Double", "Triple", "Quad", "King", "Doubledouble", "SuiteExecutiveSuite" };
            List<Type> roomlist = new();

            foreach (var tyo in list)
            {
                var room = new Type
                {
                    RoomType = tyo
                };
                roomlist.Add(room);
            }
            return roomlist;
        }


        public static List<Country> InsertCountery()
        {
            var country = new List<Country>();
            var countryName = StaticValue.Countery;
            var countrycode = StaticValue.CounteryCode;
            var Mobilecode = StaticValue.mobileCode;
            for (int i = 0; i < countryName.Count - 1; i++)
            {
                var cont = new Country
                {
                    CountryName = countryName[i],
                    CountryCode = countrycode[i],
                    CountryID = Mobilecode[i]
                };
                country.Add(cont);

            }
            return country;
        }


        public static List<State> InsertState()
        {
            var states = new List<State>();
            var stateNAme = StaticValue.StateName;
            var StateCode = StaticValue.StateCode;
            for (int i = 0; i < stateNAme.Count - 1; i++)
            {
                if (i <= 36)
                {
                    var cont = new State
                    {
                        StateName = stateNAme[i],
                        CountryrefID = 103,
                        StateID = StateCode[i]
                    };
                    states.Add(cont);
                    continue;
                }
                else
                {
                    var cont = new State
                    {
                        StateName = stateNAme[i],
                        CountryrefID = (int)Faker.Enum.Random<statename>(),
                        StateID = StateCode[i]
                    };
                    states.Add(cont);
                }
            }
            return states;

        }

        public static List<CityMaster> InsertCity()
        {
            var city = new List<CityMaster>();
            var CityName = StaticValue.City;

            for (int i = 0; i < CityName.Count - 1; i++)
            {
                if (i <= 35)
                {
                    var cont = new CityMaster
                    {
                        CityName = CityName[i],
                        stateRefID = 15,
                    };
                    city.Add(cont);
                    continue;
                }
                else if (i >= 36 && i <= 68)
                {
                    var cont = new CityMaster
                    {
                        CityName = CityName[i],
                        stateRefID = 22,
                    };
                    city.Add(cont);
                    continue;
                }
                else if (i >= 69 && i <= 81)
                {
                    var cont = new CityMaster
                    {
                        CityName = CityName[i],
                        stateRefID = 28,
                    };
                    city.Add(cont);
                    continue;
                }
                else if (i >= 81 && i <= 90)
                {
                    var cont = new CityMaster
                    {
                        CityName = CityName[i],
                        stateRefID = 35,
                    };
                    city.Add(cont);
                    continue;
                }
                else if (i > 91 && i <= 117)
                {
                    var cont = new CityMaster
                    {
                        CityName = CityName[i],
                        stateRefID = 8,
                    };
                    city.Add(cont);
                    continue;

                }
                else
                {
                    var cont = new CityMaster
                    {
                        CityName = CityName[i],
                        stateRefID = 25,
                    };
                    city.Add(cont);
                    continue;

                }
            }
            return city;
        }

        //public static Account InsertAccount()
        //{
        //    var account = new Account
        //    {
        //        Email = "varadeabhijeet@gmail.com",
        //        UserName = "Abhijeet",
        //        Phone = "7057445611",
        //        Password = "Abhi@123"

        //    };

        //    return account;
        //}


        public static List<Airport> InsertAirport()
        {
            var list = new List<Airport>();

            var airportname = StaticValue.AirportNAme;
            var airportCode = StaticValue.AirportCode;
            var airportCity = StaticValue.AirportCity;
            for (int i = 0; i < airportname.Count - 1; i++)
            {
                var airpot = new Airport
                {
                    AirportName = airportname[i],
                    AirportCode = airportCode[i],
                    Address1 = Faker.Address.StreetAddress(true),
                    Address2 = Faker.Address.StreetAddress(true),
                    Address3 = Faker.Address.StreetAddress(true),
                    CityRefId = airportCity[i],
                    PinCode = Faker.Address.ZipCode(),
                    Telephone1 = Faker.Phone.Number(),
                    Telephone2 = Faker.Phone.Number(),
                    Email1 = Faker.Internet.Email("Airport"),
                    Email2public = Faker.Internet.FreeEmail()



                };
                list.Add(airpot);
            }



            return list;
        }


        //public static List<FlightBooking> InsertFlightBooking()
        //{
        //    var list = new List<FlightBooking>();

        //    for (int i = 0; i < 2; i++)
        //    {
               
        //        var airpot = new FlightBooking
        //        {
        //            PassengerNameRecord = 2,
        //            FlightScheduleRefId = 1,
        //            CustomerContactMobile = 1,
        //            CustomerContactEmail = Faker.Internet.Email(),
                    
        //            FlightCustomerDetails = new List<Customerinformation>
        //            {

        //            new Customerinformation { PassengerName = Faker.Name.First(),
        //                Age = 25,
        //                Gender = 'M' },
        //             new Customerinformation { PassengerName = Faker.Name.First(),
        //                Age = 25,
        //                Gender = 'F' }

        //            }



        //        };
        //        list.Add(airpot);
        //    }



        //    return list;
        //}

        public static List<AirlineDetails> InsertAirline()
        {
            var list = new List<AirlineDetails>();

            for (int i = 0; i < 2; i++)
            {
                var airpot = new AirlineDetails
                {
                    AirlineName = "AirIndia",
                    ShortName = "AirIndia",
                    HelplineNumber = 88732097423,
                    Email1 = Faker.Internet.Email(),

                };
                list.Add(airpot);
            }



            return list;
        }

        public static List<Flight> InsertFlight()
        {
            var list = new List<Flight>();

            for (int i = 0; i < 2; i++)
            {
                var airpot = new Flight
                {
                    FlightCode = "AirIndia",
                    AirlineRefId = 1,
                    FromAirportRefId = 1,
                    ToAirportRefId = 2

                };
                list.Add(airpot);
            }



            return list;
        }

        public static FlightSchedule InsertSchedule()
        {

            var Flightshedul = new FlightSchedule
            {
                FlightRefId = 1,
                DepartureDate = DateTime.Parse("2022-07-22"),
                ArrivalDate = DateTime.Parse("2022-07-24"),


            };

            return Flightshedul;
        }



        public static List<IdentityRole> InsertRoles()
        {
            var roles = new List<IdentityRole>();
            foreach (var rol in StaticValue.Roles)
            {
                var role = new IdentityRole
                {
                    Name = rol,
                };

                roles.Add(role);
            }

            return roles;
        }

      
        enum statename
        {
            Canada = 40,
            SintMaarten = 204,
            UnitedStates = 239,
            UnitedStatesMinorOutlyingIslands = 240
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
