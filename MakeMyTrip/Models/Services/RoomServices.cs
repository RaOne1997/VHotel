
using MakeMyTrip.VIewModel.dataviewModel;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace MakeMyTrip.Models.Services
{
    public class RoomServices : IRoomServices
    {

        private readonly HttpClient _httpClient;
        public RoomServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<FlightBookingDTO>> GetallAsync()
        {

            List<FlightBookingDTO> dpt = new List<FlightBookingDTO>();
            var uriDeparture = $"https://localhost:7024/api/RoomDTOs";
            var responseTextDeparture = await _httpClient.GetStringAsync(uriDeparture);
            dpt = JsonConvert.DeserializeObject<List<FlightBookingDTO>>(responseTextDeparture);


            return dpt;
        }


        public async Task<bool> CreatAsync(FlightBookingDTO RoomDTO)
        {
            
            var usri = new Uri($"https://localhost:7024/api/RoomDTOs");

            //Convert.ToBase64String(RoomDTO.RoomDTOImage, 0, RoomDTO.RoomDTOImage.Length);

            var dept = JsonConvert.SerializeObject(RoomDTO);
            var containt = new StringContent(dept, Encoding.UTF8, "application/json");
            //HTTP POST
            var postTask = await _httpClient.PostAsync(usri, containt);


            if (postTask.IsSuccessStatusCode)
            {
                return true;
            }
            return false;

        }
        public async Task<bool> UpdateFlightbook(FlightBookingDTO  flightBookingDTO)
        {

            var usri = new Uri($"https://localhost:7024/api/RoomDTOs");

            //Convert.ToBase64String(RoomDTO.RoomDTOImage, 0, RoomDTO.RoomDTOImage.Length);

            var flightBooking = JsonConvert.SerializeObject(flightBookingDTO);
            var containt = new StringContent(flightBooking, Encoding.UTF8, "application/json");
            //HTTP POST
            var postTask = await _httpClient.PostAsync(usri, containt);


            if (postTask.IsSuccessStatusCode)
            {
                return true;
            }
            return false;

        }


        public async Task<FlightBookingDTO> GetbyID(int? id)
        {
            var uriDeparture = $"https://localhost:7024/api/RoomDTOs/{id}";
            var responseTextDeparture = await _httpClient.GetStringAsync(uriDeparture);
            return JsonConvert.DeserializeObject<FlightBookingDTO>(responseTextDeparture);
        }



        public async Task DeleteAsync(int id)
        {
            var uri = new Uri($"https://localhost:7024/api/RoomDTOs/{id}");

            var response = await _httpClient.DeleteAsync(uri);

            if (response.StatusCode != HttpStatusCode.NoContent)
                throw new LocationApiFailedException(response.StatusCode);
        }
    }

    class LocationApiFailedException : Exception
    {
        public HttpStatusCode ResponseStatusCode { get; }

        public LocationApiFailedException(HttpStatusCode responseStatusCode)
        {
            ResponseStatusCode = responseStatusCode;
        }
    }
}
