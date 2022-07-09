using AutoMapper;
using staticclassmodel.DataAccess.Model.Master;
using VHotel.DataAccess.DTo;
using VHotel.RepositoryPattern.Interface;
using VHotel.Services.Interface;

namespace VHotel.Services
{
    public class AirlineServices : ICrudeServices<AirlineDetailsDTO>
    {

        private readonly IAirlineRepository _airlineRepository;
        private readonly IMapper _mapper;

        public AirlineServices(
            IAirlineRepository airlineRepository,
            IMapper mapper)
        {
            _airlineRepository = airlineRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync(AirlineDetailsDTO modelDTO)
        {
            await using var memorystring = new MemoryStream();
            await modelDTO.AirlineLogotoUplode.CopyToAsync(memorystring);
            modelDTO.AirlineLogo = memorystring.ToArray();

            var airport = _mapper.Map<AirlineDetails>(modelDTO);
            await _airlineRepository.CreateAsync(airport);
        }

        public async Task DeleteAsync(int id)
        {
            await _airlineRepository.DeleteAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _airlineRepository.Exists(id);
        }

        public async Task<List<AirlineDetailsDTO>> GetAllAsync()
        {
            var citys = await _airlineRepository.GetAllAsync<AirlineDetailsDTO>();

            var cityMasterdtos = citys
                .Select(d => _mapper.Map<AirlineDetailsDTO>(d))
                .ToList();

            return cityMasterdtos;
        }

        public async Task<AirlineDetailsDTO> GetByIdAsync(int id)
        {
            var city = await _airlineRepository.GetByIdAsync<AirlineDetailsDTO>(id);


            var cityDTO = _mapper.Map<AirlineDetailsDTO>(city);

            return cityDTO;
        }

        public async Task UpdateAsync(AirlineDetailsDTO modelDTO)
        {
            try
            {
                await using var memorystring = new MemoryStream();
                await modelDTO.AirlineLogotoUplode.CopyToAsync(memorystring);
                modelDTO.AirlineLogo = memorystring.ToArray();

                if (await _airlineRepository.Exists((int)modelDTO.ID))
                {
                    var airlineDetails = _mapper.Map<AirlineDetails>(modelDTO);
                    await _airlineRepository.UpdateAsync(airlineDetails);

                }
            }
            catch (Exception)
            {

            };
        }
    }
}
