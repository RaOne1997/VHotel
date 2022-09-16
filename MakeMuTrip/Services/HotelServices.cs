using AutoMapper;
using staticclassmodel.DataAccess.Model.Masters;
using MakeMuTrip.DataAccess.DTo;
using MakeMuTrip.RepositoryPattern.Interface;
using MakeMuTrip.Services.Interface;

namespace MakeMuTrip.Services
{
    public class HotelServices : IHotelServices
    {
        private readonly IHotelRepository _hotelRepositery;
        private readonly IMapper _mapper;

        public HotelServices(
            IHotelRepository hotelRepositery,
            IMapper mapper)
        {
            _hotelRepositery = hotelRepositery;
            _mapper = mapper;
        }
        public async Task CreateAsync(HotelDTO hotelDTO)
        {
            await using var memorystring = new MemoryStream();
            await hotelDTO.HotelUplodeImage.CopyToAsync(memorystring);
            hotelDTO.HotelImage = memorystring.ToArray();
            var hotel = _mapper.Map<Hotel>(hotelDTO);
            await _hotelRepositery.CreateAsync(hotel);
        }

        public async Task DeleteAsync(int id)
        {
            await _hotelRepositery.DeleteAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _hotelRepositery.Exists(id);

        }

        public async Task<List<HotelDTO>> GetAllAsync()
        {
            var citys = await _hotelRepositery.GetAllAsync<HotelDTO>();

            var HotelDTOs = citys
                .Select(d => _mapper.Map<HotelDTO>(d))
                .ToList();

            return HotelDTOs;
        }

        public async Task<HotelDTO?> GetByIdAsync(int id)
        {
            var city = await _hotelRepositery.GetByIdAsync<HotelDTO>(id);


            var cityDTO = _mapper.Map<HotelDTO>(city);

            return cityDTO;
        }

        public async Task UpdateAsync(HotelDTO hotelDTO)
        {
            try
            {

                if (await _hotelRepositery.Exists((int)hotelDTO.ID))
                {
                    await using var memorystring = new MemoryStream();
                    await hotelDTO.HotelUplodeImage.CopyToAsync(memorystring);
                    hotelDTO.HotelImage = memorystring.ToArray();
                    var hotel = _mapper.Map<Hotel>(hotelDTO);
                    await _hotelRepositery.UpdateAsync(hotel);

                }
            }
            catch (Exception)
            {

            }

        }
    }
}
