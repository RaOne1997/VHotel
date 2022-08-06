    
using MakeMyTrip.Data;
using MakeMyTrip.VIewModel.Static_data;
using Newtonsoft.Json;
using System.Text.Json;
namespace MakeMyTrip.Models.Services
{
    public class TextSercides : ITextSercides
    {
        private readonly HttpClient _httpClient;

      
        public TextSercides(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<API_Obj> GetallAsync(string s = "INR")
        {
            {
                try
                {

                    var uriDeparture = $"https://open.er-api.com/v6/latest/{s}";
                    var responseTextDeparture = await _httpClient.GetStringAsync(uriDeparture);
                    API_Obj Test = JsonConvert.DeserializeObject<API_Obj>(responseTextDeparture);
                    
                    return Test;


                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public List<Dropdown> dropdown()
        {
            var dropdowns = new List<Dropdown>();

            foreach (KeyValuePair<string,string> lie in Static_value.My_dict2)
            {
                var drop = new Dropdown
                {

                    key = lie.Key,
                    value = lie.Value
                };
                dropdowns.Add(drop);

            }
            return dropdowns;

        }



      
    }
    public class Dropdown
    {
        public string key { get; set; }
        public string value { get; set; }
    }

}

