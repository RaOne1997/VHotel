using AutoMapper;
using staticclassmodel.DataAccess.Model.Masters;
using MakeMuTrip.DataAccess.DTo;
using MakeMuTrip.RepositoryPattern.Interface;
using MakeMuTrip.Services.Interface;

namespace MakeMuTrip.Services
{
    public class FlightServices : ICrudeServices<FlightDTO>
    {

        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;

        public FlightServices(
            IFlightRepository flightRepository,
            IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync(FlightDTO modelDTO)
        {
      
      
            var airport = _mapper.Map<Flight>(modelDTO);
            await _flightRepository.CreateAsync(airport);
        }

        public async Task DeleteAsync(int id)
        {
            await _flightRepository.DeleteAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _flightRepository.Exists(id);
        }

        public async Task<List<FlightDTO>> GetAllAsync()
        {
            var citys = await _flightRepository.GetAllAsync<FlightDTO>();

            var cityMasterdtos = citys
                .Select(d => _mapper.Map<FlightDTO>(d))
                .ToList();

            return cityMasterdtos;
        }

        public async Task<FlightDTO> GetByIdAsync(int id)
        {
            var city = await _flightRepository.GetByIdAsync<FlightDTO>(id);


            var cityDTO = _mapper.Map<FlightDTO>(city);

            return cityDTO;
        }

     

        public async Task UpdateAsync(FlightDTO modelDTO)
        {
            try
            {
          

                if (await _flightRepository.Exists((int)modelDTO.ID))
                {
                    var airlineDetails = _mapper.Map<Flight>(modelDTO);
                    await _flightRepository.UpdateAsync(airlineDetails);

                }
            }
            catch (Exception)
            {

            };
        }
    }
}
