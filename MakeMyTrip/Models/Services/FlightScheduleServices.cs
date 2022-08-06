using MakeMyTrip.VIewModel.dataviewModel;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace MakeMyTrip.Models.Services
{
    public class FlightScheduleServices : IFlightScheduleServices
    {
        private readonly HttpClient _httpClient;
        public FlightScheduleServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<FlightScheduleDTO>> GetallAsync()
        {

            List<FlightScheduleDTO> dpt = new List<FlightScheduleDTO>();
            var uriDeparture = $"https://localhost:7024/api/FlightScheduleDTOes";
            var responseTextDeparture = await _httpClient.GetStringAsync(uriDeparture);
            dpt = JsonConvert.DeserializeObject<List<FlightScheduleDTO>>(responseTextDeparture);


            return dpt;
        }


        public async Task<bool> CreatAsync(FlightScheduleDTO RoomDTO)
        {

            var usri = new Uri($"https://localhost:7024/api/FlightScheduleDTOes");

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
        public async Task<bool> UpdateFlightbook(FlightScheduleDTO FlightScheduleDTO)
        {

            var usri = new Uri($"https://localhost:7024/api/FlightScheduleDTOes");

            //Convert.ToBase64String(RoomDTO.RoomDTOImage, 0, RoomDTO.RoomDTOImage.Length);

            var FlightSchedule = JsonConvert.SerializeObject(FlightScheduleDTO);
            var containt = new StringContent(FlightSchedule, Encoding.UTF8, "application/json");
            //HTTP POST
            var postTask = await _httpClient.PutAsync(usri, containt);


            if (postTask.IsSuccessStatusCode)
            {
                return true;
            }
            return false;

        }


        public async Task<FlightScheduleDTO> GetbyID(int? id)
        {
            var uriDeparture = $"https://localhost:7024/api/FlightScheduleDTOes/{id}";
            var responseTextDeparture = await _httpClient.GetStringAsync(uriDeparture);
            return JsonConvert.DeserializeObject<FlightScheduleDTO>(responseTextDeparture);
        }



        public async Task DeleteAsync(int id)
        {
            var uri = new Uri($"https://localhost:7024/api/FlightScheduleDTOes/{id}");

            var response = await _httpClient.DeleteAsync(uri);

            if (response.StatusCode != HttpStatusCode.NoContent)
                throw new LocationApiFailedException(response.StatusCode);
        }

     

        public async Task<FlightSearchResultViewModel> SearchFlight(string locationFrom, string locationTo, DateTime date, DateTime? returnDate)
        {

            var url = new Uri($"https://localhost:7024/api/FlightScheduleDTOes/{locationFrom}/{locationTo}/{date}");
            var responseTextDeparture = await _httpClient.GetStringAsync(url);
            JsonConvert.DeserializeObject<List<FlightScheduleDTO>>(responseTextDeparture);
            var list = new FlightSearchResultViewModel();
            list.Flights = JsonConvert.DeserializeObject<List<FlightScheduleDTO>>(responseTextDeparture);


            if (returnDate != null)
            {
                var uriReturn =new Uri($"https://localhost:7024/api/FlightScheduleDTOes/{locationTo}/{locationFrom}/{date}");
                var responseTextReturn = await _httpClient.GetStringAsync(uriReturn);
                list.Retuen = JsonConvert.DeserializeObject<List<FlightScheduleDTO>>(responseTextReturn);
            }

            return list;

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
}
