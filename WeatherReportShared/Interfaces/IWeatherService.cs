using System;
using WeatherReportShared.Model;
using System.Threading.Tasks;

namespace WeatherReportShared.Interfaces
{
    public interface IWeatherService
    {
        Task<OneCallAPIResponseModel> GetWeatherForLocation(double lng, double lat);
    }
}

