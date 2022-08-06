using AutoMapper;
using EmployeeCrud.RepositoryPattern.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using staticclassmodel.DataAccess.Model.Master;
using staticclassmodel.DataAccess.Model.TransactionData;
using VHotel.DataAccess;
using VHotel.DataAccess.DTo;
using VHotel.RepositoryPattern.Interface;

namespace VHotel.RepositoryPattern
{
    public class FlightScheduleRepository : Repository<FlightSchedule>, IFlightScheduleRepository
    {
        private readonly VhotelsSQLContex _db;
        private readonly IMapper _mapper;

        public FlightScheduleRepository(VhotelsSQLContex db, IMapper mapper) : base(db, mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<FlightScheduleDTO>> SearchFlight(string locationFrom, string locationTo, DateTime date)
        {
            if (!(await _db.airports.AnyAsync(f => f.AirportCode == locationFrom) &&
                await _db.airports.AnyAsync(f => f.AirportCode == locationTo)))
                return null;

            var locationFromRefId = await _db.airports
                .Where(l => l.AirportCode == locationFrom)
                .Select(l => l.ID)
                .FirstOrDefaultAsync();

            var locationToRefId = await _db.airports
                .Where(l => l.AirportCode == locationTo)
                .Select(l => l.ID)
                .FirstOrDefaultAsync();

            var filterDateFrom = date;                              //25-Jun-2022 00:00:00
            var filterDateTo = date.AddHours(24).AddSeconds(-1);    //25-Jun-2022 23:59:59

            var flightsQuery = _db.flightSchedules.Include("flight")
                .Where(f =>
                    f.flight.FromAirportRefId == locationFromRefId &&
                    f.flight.ToAirportRefId == locationToRefId &&
                    f.DepartureDate >= filterDateFrom && f.DepartureDate <= filterDateTo);







             var flightsDto=    await _mapper.ProjectTo<FlightScheduleDTO>(flightsQuery).ToListAsync();
            if (!flightsDto.Any())
                return null;


            return flightsDto;
            }
        }
}
