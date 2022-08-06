using AutoMapper;
using staticclassmodel.DataAccess.Model.Master;
using staticclassmodel.DataAccess.Model.TransactionData;
using VHotel.DataAccess.DTo;
using VHotel.RepositoryPattern.Interface;
using VHotel.Services.Interface;

namespace VHotel.Services
{
    public class FlightScheduleServices : IFilightShedulServices
        //ICrudeServices<FlightScheduleDTO>
    {

        private readonly IFlightScheduleRepository _flightScheduleRepository;
        private readonly IMapper _mapper;

        public FlightScheduleServices(
            IFlightScheduleRepository flightScheduleRepository,
            IMapper mapper)
        {
            _flightScheduleRepository = flightScheduleRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync(FlightScheduleDTO modelDTO)
        {
           

            var flightSchedule = _mapper.Map<FlightSchedule>(modelDTO);
            await _flightScheduleRepository.CreateAsync(flightSchedule);
        }

        public async Task DeleteAsync(int id)
        {
            await _flightScheduleRepository.DeleteAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _flightScheduleRepository.Exists(id);
        }

        public async Task<List<FlightScheduleDTO>> SearchFlight(string locationFrom, string locationTo, DateTime date)
        {
            var plain = await _flightScheduleRepository.SearchFlight(locationFrom, locationTo, date);
            return plain;
        }
        public async Task<List<FlightScheduleDTO>> GetAllAsync()
          {
            var citys = await _flightScheduleRepository.GetAllAsync<FlightScheduleDTO>();

            var cityMasterdtos = citys
                .Select(d => _mapper.Map<FlightScheduleDTO>(d))
                .ToList();

            return cityMasterdtos;
        }

        public async Task<FlightScheduleDTO> GetByIdAsync(int id)
        {
            var city = await _flightScheduleRepository.GetByIdAsync<FlightScheduleDTO>(id);


            var cityDTO = _mapper.Map<FlightScheduleDTO>(city);

            return cityDTO;
        }

        public async Task UpdateAsync(FlightScheduleDTO modelDTO)
        {
            try
            {
              

                if (await _flightScheduleRepository.Exists((int)modelDTO.ID))
                {
                    var flightSchedule = _mapper.Map<FlightSchedule>(modelDTO);
                    await _flightScheduleRepository.UpdateAsync(flightSchedule);

                }
            }
            catch (Exception)
            {

            };
        }
    }
}
