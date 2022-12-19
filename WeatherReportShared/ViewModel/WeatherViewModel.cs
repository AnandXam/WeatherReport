using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using WeatherReportShared.Interfaces;
using WeatherReportShared.Model;
using Xamarin.Essentials;

namespace WeatherReportShared.ViewModel
{
    public class WeatherViewModel : BaseViewModel
    {
        IWeatherService webservice => (IWeatherService)Startup.ServiceProvider.GetService(typeof(IWeatherService));
        IMessenger messenger => (IMessenger)Startup.ServiceProvider.GetService(typeof(IMessenger));

        public void Setup()
        {
            var lastUsedLatitude = Preferences.Get("LocationLatitude", 0.0);
            var lastUsedLongitude = Preferences.Get("LocationLongitude", 0.0);
            if (lastUsedLatitude != 0 && lastUsedLongitude != 0)
            {
                Latitude = lastUsedLatitude;
                Longitude = lastUsedLongitude;
            }
            getWeatherData();
        }

        bool canUseGeoloc;
        public bool CanUseGeoloc
        {
            get => canUseGeoloc;
            set
            {
                SetProperty(ref canUseGeoloc, value);
            }
        }

        Location? location;
        public Location Location
        {
            get => location;
            set
            {
                SetProperty(ref location, value);
                Latitude = value.Latitude;
                Longitude = value.Longitude;
            }
        }
        string? placeName;
        public string PlaceName
        {
            get => placeName;
            set => SetProperty(ref placeName, value);
        }

        string? geoloc;
        public string Geoloc
        {
            get => geoloc;
            set => SetProperty(ref geoloc, value);
        }
        public OneCallAPI? WeatherData { get; set; }

        bool showData;
        public bool ShowData
        {
            get => showData;
            set => SetProperty(ref showData, value);
        }

        string? country;
        public string Country
        {
            get => country;
            set => SetProperty(ref country, value);
        }
        double latitude;
        public double Latitude
        {
            get => latitude;
            set => SetProperty(ref latitude, value);
        }

        double longitude;
        public double Longitude
        {
            get => longitude;
            set => SetProperty(ref longitude, value);
        }

        string? weatherDescp;
        public string WeatherDescp
        {
            get => weatherDescp;
            set => SetProperty(ref weatherDescp, value);
        }

        string? wind;
        public string Wind
        {
            get => wind;
            set => SetProperty(ref wind, value);
        }

        string? humidity;
        public string Humidity
        {
            get => humidity;
            set => SetProperty(ref humidity, value);
        }

        string? feelsLike;
        public string FeelsLike
        {
            get => feelsLike;
            set => SetProperty(ref feelsLike, value);
        }

        string? date;
        public string Data
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        string? temperature;
        public string Temperature
        {
            get => temperature;
            set => SetProperty(ref temperature, value);
        }

        string? weatherImageURL;
        public string WeatherImageURL
        {
            get => weatherImageURL;
            set => SetProperty(ref weatherImageURL, value);
        }

        bool isLocationDefaulted;
        public bool IsLocationDefaulted
        {
            get => isLocationDefaulted;
            set
            {
                SetProperty(ref isLocationDefaulted, value);
                saveLocation();
            }
        }

        void DisplayPlace()
        {
            WeatherDescp = $"{WeatherData.current.weather[0].main}";
            PlaceName = $"{WeatherData.timezone}";
            Wind = $"{WeatherData.current.wind_speed} miles/h";
            Humidity = $"{WeatherData.current.humidity} %";
            FeelsLike = $"{WeatherData.current.feels_like} °F";
            Data = $"{DateTime.Now.ToString("dd MMMM yyyy")}";
            Temperature = $"{WeatherData.current.temp} °F";
            WeatherImageURL = $"{WeatherData.current.weather[0].icon_url}";
        }

        /// <summary>
        /// Saving Data to preference
        /// </summary>
        void SaveSettings()
        {
            Preferences.Set("LocationLatitude", Latitude);
            Preferences.Set("LocationLongitude", Longitude);
            Preferences.Set("PlaceName", PlaceName);
        }
        /// <summary>
        /// Fetching weather data Froms service
        /// </summary>
        public async void getWeatherData()
        {
            var data = await webservice.GetWeatherForLocation(Longitude, Latitude);
            if (data != null)
            {
                WeatherData = data;
                DisplayPlace();
            }
        }
        /// <summary>
        /// Save Location
        /// </summary>
        public void saveLocation()
        {
            if (!IsLocationDefaulted)
                return;
            Preferences.Set("LocationLatitude", Latitude);
            Preferences.Set("LocationLongitude", Longitude);
            Preferences.Set("PlaceName", PlaceName);

        }
    }
}

 