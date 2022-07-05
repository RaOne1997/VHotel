using AutoMapper;
using staticclassmodel.DataAccess.Model.Master;
using VHotel.DataAccess.DTo;
using VHotel.RepositoryPattern;

namespace VHotel.Services
{
    public class CityServices : ICityServices
    {
        private readonly ICityRepository _CityRepository;
        private readonly IMapper _mapper;

        public CityServices(
            ICityRepository CityRepository,
            IMapper mapper)
        {
            _CityRepository = CityRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync(CityMasterdto cityMasterdto)
        {
            var cityMaster = _mapper.Map<CityMaster>(cityMasterdto);
            await _CityRepository.CreateAsync(cityMaster);
        }

        public async Task DeleteAsync(int id)
        {
            await _CityRepository.DeleteAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _CityRepository.Exists(id);

        }

        public async Task<List<CityMasterdto>> GetAllAsync()
        {
            var citys = await _CityRepository.GetAllAsync<CityMasterdto>();

            var cityMasterdtos = citys
                .Select(d => _mapper.Map<CityMasterdto>(d))
                .ToList();

            return cityMasterdtos;
        }

        public async Task<CityMasterdto?> GetByIdAsync(int id)
        {
            var city = await _CityRepository.GetByIdAsync<CityMasterdto>(id);
          

            var cityDTO = _mapper.Map<CityMasterdto>(city);

            return cityDTO;
        }

        public Task UpdateAsync(CityMasterdto cityMasterdto)
        {
            throw new NotImplementedException();
        }
    }
}
