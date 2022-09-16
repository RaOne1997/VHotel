using AutoMapper;
using staticclassmodel.DataAccess.Model.Masters;
using MakeMuTrip.DataAccess.DTo;
using MakeMuTrip.RepositoryPattern.Interface;
using MakeMuTrip.Services.Interface;

namespace MakeMuTrip.Services
{
    public class AmenuitiesServices : ICrudeServices<AmenuitiesDTO>
    {
        private readonly IAmenuitiesRepository _amenuitiesRepository;
        private readonly IMapper _mapper;

        public AmenuitiesServices(
            IAmenuitiesRepository amenuitiesRepository,
            IMapper mapper)
        {
            _amenuitiesRepository = amenuitiesRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync(AmenuitiesDTO amenuitiesDTO)
        {
            var amenuities = _mapper.Map<Amenities>(amenuitiesDTO);
            await _amenuitiesRepository.CreateAsync(amenuities);
        }

        public async Task DeleteAsync(int id)
        {
            await _amenuitiesRepository.DeleteAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _amenuitiesRepository.Exists(id);

        }

        public async Task<List<AmenuitiesDTO>> GetAllAsync()
        {
            var amenuities = await _amenuitiesRepository.GetAllAsync<AmenuitiesDTO>();

            var amenuitiesDTOs = amenuities
                .Select(d => _mapper.Map<AmenuitiesDTO>(d))
                .ToList();

            return amenuitiesDTOs;
        }

        public async Task<AmenuitiesDTO?> GetByIdAsync(int id)
        {
            var amenuities = await _amenuitiesRepository.GetByIdAsync<AmenuitiesDTO>(id);


            var amenuitiesdto = _mapper.Map<AmenuitiesDTO>(amenuities);

            return amenuitiesdto;
        }

        public async Task UpdateAsync(AmenuitiesDTO amenuitiesDTO)
        {
            try
            {

              if(  await _amenuitiesRepository.Exists((int)amenuitiesDTO.ID))
                {
                    var amenuities = _mapper.Map<Amenities>(amenuitiesDTO);
                    await _amenuitiesRepository.UpdateAsync(amenuities);

                }
            }
            catch (Exception)
            {

            }
       
        }
    }
}
