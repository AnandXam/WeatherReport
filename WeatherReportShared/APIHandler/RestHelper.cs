using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WeatherReportShared.APIHandler
{
    public class RestHelper
    {
        private HttpRequestMessage req;
        string stringObtained;
        public RestHelper()
        {
        }
        public String GetHTTPData(String urlString)
        {
            try
            {
                Uri url = new Uri(urlString);
                var client = new HttpClient { BaseAddress = url };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                req = new HttpRequestMessage(HttpMethod.Get, url);
                Task<string> task = Task.Run(async () => await Threading(client, req));
                task.Wait();
                stringObtained = task.Result;

            }
            catch (Exception ex)
            {
            }
            return stringObtained;
        }

        async Task<string> Threading(HttpClient client, HttpRequestMessage req)
        {
            var resp = await client.SendAsync(req);
            switch (resp.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    stringObtained = await resp.Content.ReadAsStringAsync();
                    break;
                case System.Net.HttpStatusCode.NotFound:
                    stringObtained = await resp.Content.ReadAsStringAsync();
                    break;
                case System.Net.HttpStatusCode.Unauthorized:
                    stringObtained = await resp.Content.ReadAsStringAsync();
                    break;
                default:
                    stringObtained = await resp.Content.ReadAsStringAsync();
                    break;
            }
            return stringObtained;
        }
    }
}

