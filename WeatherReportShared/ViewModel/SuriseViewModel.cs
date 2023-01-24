using System;
using WeatherReport.Core.Interfaces;
using WeatherReportShared.Interfaces;
using Xamarin.Essentials;

namespace WeatherReportShared.ViewModel
{
    public class SuriseViewModel : WeatherViewModel
    {
        string? sunrise;
        public string Sunrise
        {
            get => sunrise;
            set => SetProperty(ref sunrise, value);
        }

        string? sunset;

        public SuriseViewModel(IWeatherService weatherService, IConnectivityService connectivity, IAlertService alertService, IRepository repository) : base(weatherService, connectivity, alertService, repository)
        {
        }

        public string Sunset
        {
            get => sunset;
            set => SetProperty(ref sunset, value);
        }
        public void Initialize()
        {
            Sunrise = DateTimeOffset.FromUnixTimeSeconds(WeatherData.current.sunrise).DateTime.ToString("hh:mm tt");
            Sunset = DateTimeOffset.FromUnixTimeSeconds(WeatherData.current.sunset).DateTime.ToString("hh:mm tt");
        }
        //TODO need to chnage
        // Pass data through navigation

    }
}