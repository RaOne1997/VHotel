using AutoMapper;
using staticclassmodel.DataAccess.Model.Master;
using staticclassmodel.DataAccess.Model.TransactionData;
using VHotel.DataAccess.DTo;
using VHotel.RepositoryPattern.Interface;
using VHotel.Services.Interface;

namespace VHotel.Services
{
    public class FlightBookingServices : IFlightBookingServices
    {

        private readonly IFlightBookingReoposttory _flightBookingReoposttory;
        private readonly IMapper _mapper;

        public FlightBookingServices(
            IFlightBookingReoposttory flightBookingReoposttory,
            IMapper mapper)
        {
            _flightBookingReoposttory = flightBookingReoposttory;
            _mapper = mapper;
        }
        public async Task CreateAsync(FlightBookingInputDTO modelDTO)
        {


            var airport = _mapper.Map<FlightBooking>(modelDTO);
            await _flightBookingReoposttory.CreateAsync(airport);
        }

        public async Task DeleteAsync(int id)
        {
            await _flightBookingReoposttory.DeleteAsync(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await _flightBookingReoposttory.Exists(id);
        }

        public async Task<List<FlightBookingDTO>> GetAllAsync()
        {
            var citys = await _flightBookingReoposttory.GetAllAsync<FlightBookingDTO>();

            var cityMasterdtos = citys
                .Select(d => _mapper.Map<FlightBookingDTO>(d))
                .ToList();

            return cityMasterdtos;
        }

        public async Task<FlightBookingDTO> getALlDec()
        {
            var nowbook = await _flightBookingReoposttory.getALlDec();
            return  nowbook ;
        }

        public async Task<FlightBookingDTO> GetByIdAsync(int id)
        {
            var flightBooking = await _flightBookingReoposttory.GetByIdAsync<FlightBookingDTO>(id);


            var cityDTO = _mapper.Map<FlightBookingDTO>(flightBooking);

            return cityDTO;
        }

        public async Task<BookingFlightDTO> GetByIdSheduD(int id)
        {
            var flightBooking = await _flightBookingReoposttory.GetbyFlight(id);


          

            return flightBooking;

        }

        public async Task<FlightBookingDTO> GetByIdShedulID(int id)
        {
            var flightBooking = await _flightBookingReoposttory.GetbyFlightID(id);


            //var cityDTO = _mapper.Map<FlightBookingDTO>(flightBooking);
            return flightBooking;
        }

        public async Task UpdateAsync(FlightBookingInputDTO modelDTO)
        {
            try
            {


                if (await _flightBookingReoposttory.Exists((int)modelDTO.ID))
                {
                    var flightBooking = _mapper.Map<FlightBooking>(modelDTO);
                    await _flightBookingReoposttory.UpdateAsync(flightBooking);

                }
            }
            catch (Exception)
            {

            };
        }
    }
}
