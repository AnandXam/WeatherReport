using System;
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

    }
}