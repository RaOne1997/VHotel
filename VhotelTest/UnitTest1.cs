using AutoMapper;
using NSubstitute;
using MakeMuTrip.DataAccess.DTo;
using MakeMuTrip.RepositoryPattern.Interface;
using MakeMuTrip.Services;
using MakeMuTrip.Services.Interface;
using Xunit;

namespace VhotelTest
{
    public class UnitTest1
    {
        public readonly IFilightShedulServices _filightShedulServices;

        private readonly IFlightScheduleRepository _flightScheduleRepository = Substitute.For<IFlightScheduleRepository>();
        private readonly IMapper _mapper = Substitute.For<IMapper>();
     
    
        [Theory]
        [InlineData("BOM", "NGA", "1999 - 01 - 02")]
        [InlineData("BOM", "NGA", "1999 - 01 - 02")]

        public async Task SearchFlightAsync(string locationFrom, string locationTo, DateTime date)
        {
           
            var expectedFemaleEmployees = new List<FlightScheduleDTO>
        {
            new() {FlightRefId = 6, DepartureDate = Convert.ToDateTime("1999-01-02"), ArrivalDate = Convert.ToDateTime("1999-02-02")},
          
        };
            _flightScheduleRepository.SearchFlight(locationFrom, locationTo, date).Returns(expectedFemaleEmployees);

            var employeeFemales = await _filightShedulServices.GetAllAsync();


            for (int i = 0; i < expectedFemaleEmployees.Count; i++)
            {
                Assert.Equal(employeeFemales[i].FlightRefId, expectedFemaleEmployees[i].FlightRefId);
                Assert.Equal(employeeFemales[i].DepartureDate, expectedFemaleEmployees[i].DepartureDate);
                Assert.Equal(employeeFemales[i].ArrivalDate, expectedFemaleEmployees[i].ArrivalDate);
            }
        }

       
    }
}