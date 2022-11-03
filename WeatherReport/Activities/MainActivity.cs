using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.Core.App;
using Com.Airbnb.Lottie;
using Google.Places;
using Newtonsoft.Json;
using WeatherReportShared.Model;
using Xamarin.Essentials;

namespace WeatherReport
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        private LottieAnimationView Windanimation, Humidanimation, Feelanimation;
        string Latitude = "51.509865";
        string Longitude = "-0.118092";
        string CityName = "London";
        TextView DateText, TempText, Cityext, SearchPlaceTextview, WeatherDescp, WindText, Humidityext, HowItFeelText;
        ImageView WeatherImage;
        CheckBox MakeDefaultCheckBox;
        CardView SearchPlaceCardview;
        LocationManager locationManager;
        string provider;
        static double lat, lng;
        OneCallAPI openWeatherMap = new OneCallAPI();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Xamarin.Essentials.Platform.CurrentActivity.Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#0F0F39"));
            this.MakeDefaultCheckBox = FindViewById<CheckBox>(Resource.Id.MakeDefaultCheckBox);
            this.Windanimation = FindViewById<LottieAnimationView>(Resource.Id.Windanimation);
            this.Humidanimation = FindViewById<LottieAnimationView>(Resource.Id.Humidanimation);
            this.Feelanimation = FindViewById<LottieAnimationView>(Resource.Id.Feelanimation);
            this.Windanimation.PlayAnimation();
            this.Humidanimation.PlayAnimation();
            this.Feelanimation.PlayAnimation();
            SearchPlaceTextview = FindViewById<TextView>(Resource.Id.SearchPlaceTextview);
            SearchPlaceCardview = FindViewById<CardView>(Resource.Id.SearchPlaceCardview);
            checkLocationExist();
            SearchPlaceCardview.Click += PlaceSearchClicked;
            if (!PlacesApi.IsInitialized)
            {
                PlacesApi.Initialize(this, WeatherReportShared.Utils.Constants.GooglePlace_API_KEY);
            }
            MakeDefaultCheckBox.Click += (s, e) =>
            {
                if (MakeDefaultCheckBox.Checked)
                {
                    Preferences.Set("LocationLatitude", Latitude);
                    Preferences.Set("LocationLongitude", Longitude);
                    Preferences.Set("PlaceName", CityName);
                }
                else
                {
                    Preferences.Clear();
                }
            };
        }

        private async void PlaceSearchClicked(object sender, System.EventArgs e)
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }
            else if (status == PermissionStatus.Granted)
            {
                List<Place.Field> fields = new List<Place.Field>();
                fields.Add(Place.Field.Id);
                fields.Add(Place.Field.Name);
                fields.Add(Place.Field.LatLng);
                fields.Add(Place.Field.Address);

                Intent intent = new Autocomplete.IntentBuilder(AutocompleteActivityMode.Overlay, fields)
                    .Build(this);

                StartActivityForResult(intent, 0);
            }
        }
        /// <summary>
        /// Check any location made default
        /// </summary>
        private void checkLocationExist()
        {
            var myValue = Preferences.Get("LocationLatitude", "default_value");
            if (myValue != "default_value")
            {
                new GetWeather(this, openWeatherMap).Execute(WeatherReportShared.Utils.Helper.APIRequest(Preferences.Get("LocationLatitude", "default_value"), Preferences.Get("LocationLongitude", "default_value")));
                this.MakeDefaultCheckBox = FindViewById<CheckBox>(Resource.Id.MakeDefaultCheckBox);
                MakeDefaultCheckBox.Checked = true;
                SearchPlaceTextview.Text = Preferences.Get("PlaceName", "default_value");
            }
            else
            {
                new GetWeather(this, openWeatherMap).Execute(WeatherReportShared.Utils.Helper.APIRequest(Latitude, Longitude));
                this.MakeDefaultCheckBox = FindViewById<CheckBox>(Resource.Id.MakeDefaultCheckBox);
                MakeDefaultCheckBox.Checked = false;
            }

        }

        /// <summary>
        /// Assigning latitude and longitude to OpenweatherAPI
        /// </summary>
        /// <param name="requestCode"></param>
        /// <param name="resultCode"></param>
        /// <param name="data"></param>
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            var place = Autocomplete.GetPlaceFromIntent(data);
            new GetWeather(this, openWeatherMap).Execute(WeatherReportShared.Utils.Helper.APIRequest(place.LatLng.Latitude.ToString(), place.LatLng.Longitude.ToString()));
            Latitude = place.LatLng.Latitude.ToString();
            Longitude = place.LatLng.Longitude.ToString();
            CityName = place.Name;
            SearchPlaceTextview.Text = place.Name;
        }

        /// <summary>
        /// Fetching weather details
        /// From Open weather API
        /// </summary>
        private class GetWeather : AsyncTask<string, Java.Lang.Void, string>
        {
            private MainActivity activity;
            OneCallAPI openWeatherMap;
            public GetWeather(MainActivity activity, OneCallAPI openWeatherMap)
            {
                this.activity = activity;
                this.openWeatherMap = openWeatherMap;
            }
            protected override string RunInBackground(params string[] @params)
            {
                string stream = null;
                string urlString = @params[0];
                WeatherReportShared.APIHandler.RestHelper http = new WeatherReportShared.APIHandler.RestHelper();
                stream = http.GetHTTPData(urlString);
                return stream;
            }
            protected override void OnPostExecute(string result)
            {
                base.OnPostExecute(result);
                if (result.Contains("Error: Not City Found"))
                {
                    return;
                }
                openWeatherMap = JsonConvert.DeserializeObject<OneCallAPI>(result);
                activity.Cityext = activity.FindViewById<TextView>(Resource.Id.Cityext);
                activity.DateText = activity.FindViewById<TextView>(Resource.Id.DateText);
                activity.TempText = activity.FindViewById<TextView>(Resource.Id.TempText);
                activity.WeatherImage = activity.FindViewById<ImageView>(Resource.Id.WeatherImage);
                activity.WeatherDescp = activity.FindViewById<TextView>(Resource.Id.WeatherDescp);
                activity.WindText = activity.FindViewById<TextView>(Resource.Id.WindText);
                activity.Humidityext = activity.FindViewById<TextView>(Resource.Id.Humidityext);
                activity.HowItFeelText = activity.FindViewById<TextView>(Resource.Id.HowItFeelText);

                activity.Cityext.Text = $"{openWeatherMap.timezone}";
                activity.WeatherDescp.Text = $"{openWeatherMap.current.weather[0].main}";
                activity.WindText.Text = $"{openWeatherMap.current.wind_speed} miles/h";
                activity.Humidityext.Text = $"{openWeatherMap.current.humidity} %";
                activity.HowItFeelText.Text = $"{openWeatherMap.current.feels_like} °F";
                activity.DateText.Text = $"{DateTime.Now.ToString("dd MMMM yyyy")}";
                activity.TempText.Text = $"{openWeatherMap.current.temp} °F";
                if (!string.IsNullOrEmpty(openWeatherMap.current.weather[0].icon_url))
                {
                    //Picasso.Get()
                    //.Load(openWeatherMap.current.weather[0].icon_url)
                    //.Fit()
                    //.CenterCrop()
                    //.NoFade()
                    //.Into(activity.WeatherImage);
                }
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
