using AutoMapper;
using staticclassmodel.DataAccess.Model.Master;
using VHotel.DataAccess.DTo;
using VHotel.RepositoryPattern.Interface;
using VHotel.Services.Interface;

namespace VHotel.Services
{
    public class CountryServices : ICrudeServices<CountryDTO>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryServices(
            ICountryRepository countryRepository,
            IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync(CountryDTO countryDTO)
        {
            var country = _mapper.Map<Country>(countryDTO);
            await _countryRepository.CreateAsync(country);
        }

        public async Task DeleteAsync(int id)
        {
            await _countryRepository.DeleteAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _countryRepository.Exists(id);

        }

        public async Task<List<CountryDTO>> GetAllAsync()
        {
            var citys = await _countryRepository.GetAllAsync<CountryDTO>();

            var cityMasterdtos = citys
                .Select(d => _mapper.Map<CountryDTO>(d))
                .ToList();

            return cityMasterdtos;
        }

        public async Task<CountryDTO?> GetByIdAsync(int id)
        {
            var city = await _countryRepository.GetByIdAsync<CountryDTO>(id);


            var cityDTO = _mapper.Map<CountryDTO>(city);

            return cityDTO;
        }

        public async Task UpdateAsync(CountryDTO countryDTO)
        {
            try
            {

              if(  await _countryRepository.Exists((int)countryDTO.ID))
                {
                    var country = _mapper.Map<Country>(countryDTO);
                    await _countryRepository.UpdateAsync(country);

                }
            }
            catch (Exception)
            {

            }
       
        }
    }
}
