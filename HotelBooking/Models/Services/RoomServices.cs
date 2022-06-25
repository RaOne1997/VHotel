using HotelBooking.Models.DTO;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace HotelBooking.Models.Services
{
    public class RoomServices : IRoomServices
    {

        private readonly HttpClient _httpClient;
        public RoomServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<Room>> GetallAsync()
        {

            List<Room> dpt = new List<Room>();
            var uriDeparture = $"https://localhost:7024/api/Rooms";
            var responseTextDeparture = await _httpClient.GetStringAsync(uriDeparture);
            dpt = JsonConvert.DeserializeObject<List<Room>>(responseTextDeparture);


            return dpt;
        }


        public async Task<bool> CreatAsync(Room room)
        {
            
            var usri = new Uri($"https://localhost:7024/api/Rooms");

            var dept = JsonConvert.SerializeObject(room);
            var containt = new StringContent(dept, Encoding.UTF8, "application/json");
            //HTTP POST
            var postTask = await _httpClient.PostAsync(usri, containt);


            if (postTask.IsSuccessStatusCode)
            {
                return true;
            }
            return false;

        }



        public async Task<Room> GetbyID(int? id)
        {
            var uriDeparture = $"https://localhost:7024/api/Rooms/{id}";
            var responseTextDeparture = await _httpClient.GetStringAsync(uriDeparture);
            return JsonConvert.DeserializeObject<Room>(responseTextDeparture);
        }



        public async Task DeleteAsync(int id)
        {
            var uri = new Uri($"https://localhost:7024/api/Rooms/{id}");

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
