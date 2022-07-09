using AutoMapper;
using staticclassmodel.DataAccess.Model.Master;
using staticclassmodel.DataAccess.Model.TransactionData;
using VHotel.DataAccess.DTo;
using VHotel.RepositoryPattern.Interface;
using VHotel.Services.Interface;

namespace VHotel.Services
{
    public class HotelCustomerDetailServices : ICrudeServices<HotelCustomerDetailDTO>
    {

        private readonly IHotelCustomerDetailRepository _hotelCustomerDetailRepository;
        private readonly IMapper _mapper;

        public HotelCustomerDetailServices(
            IHotelCustomerDetailRepository hotelCustomerDetailRepository,
            IMapper mapper)
        {
            _hotelCustomerDetailRepository = hotelCustomerDetailRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync(HotelCustomerDetailDTO modelDTO)
        {
            var hotelCustomerDetail = _mapper.Map<HotelCustomerDetail>(modelDTO);
            await _hotelCustomerDetailRepository.CreateAsync(hotelCustomerDetail);
        }

        public async Task DeleteAsync(int id)
        {
            await _hotelCustomerDetailRepository.DeleteAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _hotelCustomerDetailRepository.Exists(id);
        }

        public async Task<List<HotelCustomerDetailDTO>> GetAllAsync()
        {
            var citys = await _hotelCustomerDetailRepository.GetAllAsync<HotelCustomerDetailDTO>();

            var cityMasterdtos = citys
                .Select(d => _mapper.Map<HotelCustomerDetailDTO>(d))
                .ToList();

            return cityMasterdtos;
        }

        public async Task<HotelCustomerDetailDTO> GetByIdAsync(int id)
        {
            var city = await _hotelCustomerDetailRepository.GetByIdAsync<HotelCustomerDetailDTO>(id);


            var cityDTO = _mapper.Map<HotelCustomerDetailDTO>(city);

            return cityDTO;
        }

        public async Task UpdateAsync(HotelCustomerDetailDTO modelDTO)
        {
            try
            {


                if (await _hotelCustomerDetailRepository.Exists((int)modelDTO.ID))
                {
                    var hotelCustomerDetail = _mapper.Map<HotelCustomerDetail>(modelDTO);
                    await _hotelCustomerDetailRepository.UpdateAsync(hotelCustomerDetail);

                }
            }
            catch (Exception)
            {

            };
        }
    }
}
