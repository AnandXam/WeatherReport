using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using InteractiveAlert;
using WeatherReport.Core.Interfaces;
using WeatherReport.Core.Model;
using WeatherReportShared.Interfaces;
using WeatherReportShared.Model;
using Xamarin.Essentials;

#nullable enable
namespace WeatherReportShared.ViewModel
{
    public class WeatherViewModel : BaseViewModel
    {
        #region Private Properties
        private readonly IWeatherService weatherService;
        private readonly IConnectivityService connectivity;
        private readonly IAlertService alertService;
        private readonly IRepository repository;
        private bool canUseGeoloc;
        private Location location;
        private string placeName;
        private string geoloc;
        private string country;
        private bool showData;
        private double latitude;
        private double longitude;
        private string weatherDescp;
        private string wind;
        private string humidity;
        private string feelsLike;
        private string date;
        private string temperature;
        private string weatherImageURL;
        private bool isLocationDefaulted;
        private object alertService1;
        #endregion Private Properties

        #region Constructor
        public WeatherViewModel(IWeatherService weatherService, IConnectivityService connectivity, IAlertService alertService, IRepository repository)
        {
            this.weatherService = weatherService;
            this.connectivity = connectivity;
            this.alertService = alertService;
            this.repository = repository;
            checkForSavedLocation();
        }

        #endregion Constructor

        #region Public Properties
        public bool CanUseGeoloc
        {
            get => canUseGeoloc;
            set
            {
                SetProperty(ref canUseGeoloc, value);
            }
        }

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
        public string PlaceName
        {
            get => placeName!;
            set => SetProperty(ref placeName, value);
        }

        public string Geoloc
        {
            get => geoloc;
            set => SetProperty(ref geoloc, value);
        }
        public static OneCallAPIResponseModel? WeatherData { get; set; }

        public bool ShowData
        {
            get => showData;
            set => SetProperty(ref showData, value);
        }

        public string Country
        {
            get => country;
            set => SetProperty(ref country, value);
        }
        public double Latitude
        {
            get => latitude;
            set => SetProperty(ref latitude, value);
        }

        public double Longitude
        {
            get => longitude;
            set => SetProperty(ref longitude, value);
        }

        public string WeatherDescp
        {
            get => weatherDescp;
            set => SetProperty(ref weatherDescp, value);
        }

        public string Wind
        {
            get => wind;
            set => SetProperty(ref wind, value);
        }

        public string Humidity
        {
            get => humidity;
            set => SetProperty(ref humidity, value);
        }

        public string FeelsLike
        {
            get => feelsLike;
            set => SetProperty(ref feelsLike, value);
        }

        public string Data
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        public string Temperature
        {
            get => temperature;
            set => SetProperty(ref temperature, value);
        }

        public string WeatherImageURL
        {
            get => weatherImageURL;
            set => SetProperty(ref weatherImageURL, value);
        }

        public bool IsLocationDefaulted
        {
            get => isLocationDefaulted;
            set
            {
                SetProperty(ref isLocationDefaulted, value);
                saveLocation();
            }
        }

        SqliteUserSettingModel? SqliteUserSettingModel { get; set; }

        #endregion Public Properties


        /// <summary>
        /// Display Weather Details
        /// </summary>
        public void DisplayPlace()
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
        /// Checking wheather location already saved
        /// </summary>
        public async void checkForSavedLocation()
        {
           // var lastUsedLatitude = Preferences.Get("LocationLatitude", 0.0);
            //var lastUsedLongitude = Preferences.Get("LocationLongitude", 0.0);

            var savedUserPreference= repository.GetData<SqliteUserSettingModel>();
            if (savedUserPreference != null)
            {
                if (savedUserPreference.SavedLatitude != 0 && savedUserPreference.SavedLongitude != 0)
                {
                    Latitude = savedUserPreference.SavedLatitude;
                    Longitude = savedUserPreference.SavedLongitude;
                }
            }
            else
            {
                SqliteUserSettingModel = new SqliteUserSettingModel();
            }

            if (connectivity.IsConnected)
            {
                WeatherData = await getWeatherData();
                if (WeatherData != null)
                {
                    DisplayPlace();
                }
            }

        }
        /// <summary>
        /// Fetching weather data Froms service
        /// </summary>
        public async Task<OneCallAPIResponseModel> getWeatherData()
        {
            var data = await weatherService.GetWeatherForLocation(Longitude, Latitude);
            return data;
        }
        /// <summary>
        /// Save Location
        /// </summary>
        public void saveLocation()
        {
            if (!IsLocationDefaulted)
                return;
            //Preferences.Set("LocationLatitude", Latitude);
            //Preferences.Set("LocationLongitude", Longitude);
            //Preferences.Set("PlaceName", PlaceName);

            if (Latitude != 0 && Longitude != 0)
            {
                SqliteUserSettingModel.SavedLatitude = Latitude;
                SqliteUserSettingModel.SavedLongitude = Longitude;
                SqliteUserSettingModel.PlaceName = PlaceName;
                repository.SaveData(SqliteUserSettingModel);
            }
        }
    }
}

