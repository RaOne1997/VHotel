using AutoMapper;
using staticclassmodel.DataAccess.Model.Masters;
using MakeMuTrip.DataAccess.DTo;
using MakeMuTrip.RepositoryPattern.Interface;
using MakeMuTrip.Services.Interface;

namespace MakeMuTrip.Services
{
    public class CityServices : ICityServices
    {
        private readonly ICityRepository _CityRepository;
        private readonly IStateRepository _StateRepository;
        private readonly IMapper _mapper;

        public CityServices(

            ICityRepository CityRepository, IStateRepository stateRepository,
            IMapper mapper)
        {
            _CityRepository = CityRepository;
            _StateRepository = stateRepository;
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
                .Select(d => _mapper.Map<CityMasterdto>(d)).Skip(0).Take(10)
                .ToList();

         

            return cityMasterdtos;
        }

        public async Task<CityMasterdto?> GetByIdAsync(int id)
        {
            var city = await _CityRepository.GetByIdAsync<CityMasterdto>(id);


            var cityDTO = _mapper.Map<CityMasterdto>(city);

            return cityDTO;
        }

        public Task<List<DropDownViewModel>> GetCityForDropDownAsync()
        {
            return null;
        }

        public async Task<List<DropDownViewModel>> GetDepartmentsForDropDownAsync(int contid)
        {
            return await _StateRepository.GetForDropDownAsync(contid);
        }

        public async Task UpdateAsync(CityMasterdto cityMasterdto)
        {
            try
            {

              if(  await _CityRepository.Exists((int)cityMasterdto.ID))
                {
                    var cityMaster = _mapper.Map<CityMaster>(cityMasterdto);
                    await _CityRepository.UpdateAsync(cityMaster);

                }
            }
            catch (Exception)
            {

            }
       
        }
    }
}
