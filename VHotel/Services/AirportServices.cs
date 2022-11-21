using AutoMapper;
using staticclassmodel.DataAccess.Model.Masters;
using MakeMuTrip.DataAccess.DTo;
using MakeMuTrip.RepositoryPattern.Interface;
using MakeMuTrip.Services.Interface;

namespace MakeMuTrip.Services
{
    public class AirportServices : ICrudeServices<AirportDTO>
    {

        private readonly IAirportRepository _airportRepository;
        private readonly IMapper _mapper;

        public AirportServices(
            IAirportRepository airportRepository,
            IMapper mapper)
        {
            _airportRepository = airportRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync(AirportDTO modelDTO)
        {
            if (modelDTO.AirportImageUplode != null)
            {
                await using var memorystring = new MemoryStream();
                await modelDTO.AirportImageUplode.CopyToAsync(memorystring);
                modelDTO.AirportImage = memorystring.ToArray();

            }

            var airport = _mapper.Map<Airport>(modelDTO);
            await _airportRepository.CreateAsync(airport);
        }

        public async Task DeleteAsync(int id)
        {
            await _airportRepository.DeleteAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _airportRepository.Exists(id);
        }

        public async Task<List<AirportDTO>> GetAllAsync()
        {
            var citys = await _airportRepository.GetAllAsync<AirportDTO>();

            var cityMasterdtos = citys
                .Select(d => _mapper.Map<AirportDTO>(d))
                .ToList();

            return cityMasterdtos;
        }

        public async Task<AirportDTO> GetByIdAsync(int id)
        {
            var city = await _airportRepository.GetByIdAsync<AirportDTO>(id);


            var cityDTO = _mapper.Map<AirportDTO>(city);

            return cityDTO;
        }

        public async Task UpdateAsync(AirportDTO modelDTO)
        {
            try
            {

                if (await _airportRepository.Exists((int)modelDTO.ID))
                {

                    if (modelDTO.AirportImageUplode != null)
                    {
                        await using var memorystring = new MemoryStream();
                        await modelDTO.AirportImageUplode.CopyToAsync(memorystring);
                        modelDTO.AirportImage = memorystring.ToArray();

                    }

                    var cityMaster = _mapper.Map<Airport>(modelDTO);
                    await _airportRepository.UpdateAsync(cityMaster);

                }
            }
            catch (Exception)
            {

            };
        }




        public async Task IsactiveornotAsync(AirportDTO modelDTO)
        {
            try
            {

                if (await _airportRepository.Exists((int)modelDTO.ID))
                {

                   

                    if (modelDTO.AirportImageUplode != null)
                    {
                        await using var memorystring = new MemoryStream();
                        await modelDTO.AirportImageUplode.CopyToAsync(memorystring);
                        modelDTO.AirportImage = memorystring.ToArray();

                    }

                    var cityMaster = _mapper.Map<Airport>(modelDTO);
                    await _airportRepository.UpdateAsync(cityMaster);

                }
            }
            catch (Exception)
            {

            };
        }
    }
}
