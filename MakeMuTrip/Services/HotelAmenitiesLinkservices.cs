using AutoMapper;
using staticclassmodel.DataAccess.Model.Masters;
using MakeMuTrip.DataAccess.DTo;
using MakeMuTrip.RepositoryPattern.Interface;
using MakeMuTrip.Services.Interface;

namespace MakeMuTrip.Services
{
    public class HotelAmenitiesLinkservices : ICrudeServices<HotelAmenitiesLinkDTO>
    {
        private readonly IHotelAmenitiesLinkRepository _hotelAmenitiesLinkRepository;
        private readonly IMapper _mapper;

        public HotelAmenitiesLinkservices(IHotelAmenitiesLinkRepository hotelAmenitiesLinkRepository,
            IMapper mapper)
        {
            _hotelAmenitiesLinkRepository = hotelAmenitiesLinkRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync(HotelAmenitiesLinkDTO HotelAmenitiesLinkDTO)
        {
            var hotelAmenities = _mapper.Map<HotelAmenitiesLink>(HotelAmenitiesLinkDTO);

            await _hotelAmenitiesLinkRepository.CreateAsync(hotelAmenities);
        }

        public async Task DeleteAsync(int id)
        {
            await _hotelAmenitiesLinkRepository.DeleteAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _hotelAmenitiesLinkRepository.Exists(id);

        }

        public async Task<List<HotelAmenitiesLinkDTO>> GetAllAsync()
        {
            var amenuities = await _hotelAmenitiesLinkRepository.GetAllAsync<HotelAmenitiesLinkDTO>();

            var HotelAmenitiesLinkDTOs = amenuities
                .Select(d => _mapper.Map<HotelAmenitiesLinkDTO>(d))
                .ToList();

            return HotelAmenitiesLinkDTOs;
        }

        public async Task<HotelAmenitiesLinkDTO?> GetByIdAsync(int id)
        {
            var amenuities = await _hotelAmenitiesLinkRepository.GetByIdAsync<HotelAmenitiesLinkDTO>(id);


            var HotelAmenitiesLinkDTO = _mapper.Map<HotelAmenitiesLinkDTO>(amenuities);

            return HotelAmenitiesLinkDTO;
        }

        public async Task UpdateAsync(HotelAmenitiesLinkDTO HotelAmenitiesLinkDTO)
        {
            try
            {

              if(  await _hotelAmenitiesLinkRepository.Exists((int)HotelAmenitiesLinkDTO.ID))
                {
                    var amenuities = _mapper.Map<HotelAmenitiesLink>(HotelAmenitiesLinkDTO);
                    await _hotelAmenitiesLinkRepository.UpdateAsync(amenuities);

                }
            }
            catch (Exception)
            {

            }
       
        }
    }
}
