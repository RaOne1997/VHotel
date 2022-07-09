using AutoMapper;
using staticclassmodel.DataAccess.Model.Master;
using staticclassmodel.DataAccess.Model.TransactionData;
using VHotel.DataAccess.DTo;
using VHotel.RepositoryPattern.Interface;
using VHotel.Services.Interface;

namespace VHotel.Services
{
    public class HotelBookingsServices : ICrudeServices<HotelBookingDTO>
    {

        private readonly IHotelBookingRepository _hotelBookingRepository;
        private readonly IMapper _mapper;

        public HotelBookingsServices(
            IHotelBookingRepository hotelBookingRepository,
            IMapper mapper)
        {
            _hotelBookingRepository = hotelBookingRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync(HotelBookingDTO modelDTO)
        {
         

            var hotelBooking = _mapper.Map<HotelBooking>(modelDTO);
            await _hotelBookingRepository.CreateAsync(hotelBooking);
        }

        public async Task DeleteAsync(int id)
        {
            await _hotelBookingRepository.DeleteAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _hotelBookingRepository.Exists(id);
        }

        public async Task<List<HotelBookingDTO>> GetAllAsync()
        {
            var citys = await _hotelBookingRepository.GetAllAsync<HotelBookingDTO>();

            var cityMasterdtos = citys
                .Select(d => _mapper.Map<HotelBookingDTO>(d))
                .ToList();

            return cityMasterdtos;
        }

        public async Task<HotelBookingDTO> GetByIdAsync(int id)
        {
            var city = await _hotelBookingRepository.GetByIdAsync<HotelBookingDTO>(id);


            var cityDTO = _mapper.Map<HotelBookingDTO>(city);

            return cityDTO;
        }

        public async Task UpdateAsync(HotelBookingDTO modelDTO)
        {
            try
            {
             

                if (await _hotelBookingRepository.Exists((int)modelDTO.ID))
                {
                    var airlineDetails = _mapper.Map<HotelBooking>(modelDTO);
                    await _hotelBookingRepository.UpdateAsync(airlineDetails);

                }
            }
            catch (Exception)
            {

            };
        }
    }
}
