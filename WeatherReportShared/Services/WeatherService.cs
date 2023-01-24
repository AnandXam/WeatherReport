using System;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherReportShared.Interfaces;
using WeatherReportShared.Utils;
using WeatherReportShared.Helpers;
using WeatherReportShared.Model;
using WeatherReportShared.ViewModel;

namespace WeatherReportShared.Services
{
    public class WeatherService : IWeatherService
    {
        
        public async Task<OneCallAPIResponseModel> GetWeatherForLocation(double lng, double lat)
        {
            //Todo change to const
            var api = "lat=";
            var pars = $"{lat}&lon={lng}";
            var data = await GetOneCallAPIResposnse<OneCallAPIResponseModel>(api, pars);
            return data;
        }

        async Task<T> GetOneCallAPIResposnse<T>(string api, string pars)
        {
            var result = Activator.CreateInstance<T>();
            try
            {
                using (var client = new HttpClientHelper().SetupClient(timeOut: 1, isMinutes: true, acceptMediaType: true, mediaType: "application/json"))
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, $"{Constants.API_LINK}{api}{pars}&appid={Constants.API_KEY}");
                    var send = await client.SendAsync(request);

                    if (send.StatusCode == HttpStatusCode.OK)
                    {
                        var res = await send.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<T>(res);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception : {ex.Message} : {ex.InnerException?.Message}");

            }
            return result;
        }    
    }
}

