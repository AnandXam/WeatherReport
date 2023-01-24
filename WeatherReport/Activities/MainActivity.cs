using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
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
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Square.Picasso;
using WeatherReport.Activities;
using WeatherReport.Sqlite;
using WeatherReportShared.Model;
using WeatherReportShared.ViewModel;
using Xamarin.Essentials;
using static Android.Service.Voice.VoiceInteractionSession;
using AlertDialog = Android.App.AlertDialog;

namespace WeatherReport
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        public static IServiceProvider Service { get; set; }
        private LottieAnimationView Windanimation, Humidanimation, Feelanimation;
        TextView DateText, TempText, Cityext, SearchPlaceTextview, WeatherDescp, WindText, Humidityext, HowItFeelText, ViewSunriseLabel;
        ImageView WeatherImage;
        CheckBox MakeDefaultCheckBox;
        CardView SearchPlaceCardview;
        LocationManager locationManager;
        WeatherViewModel ViewModel { get; set; }
        BaseViewModel BaseViewModel { get; set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);     
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            new SQLConnection().GetConnection();
            Xamarin.Essentials.Platform.CurrentActivity.Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#0F0F39"));
            this.MakeDefaultCheckBox = FindViewById<CheckBox>(Resource.Id.MakeDefaultCheckBox);
            this.Windanimation = FindViewById<LottieAnimationView>(Resource.Id.Windanimation);
            this.Humidanimation = FindViewById<LottieAnimationView>(Resource.Id.Humidanimation);
            this.Feelanimation = FindViewById<LottieAnimationView>(Resource.Id.Feelanimation);
            this.ViewSunriseLabel = FindViewById<TextView>(Resource.Id.ViewSunriseLabel);        
            this.Windanimation.PlayAnimation();
            this.Humidanimation.PlayAnimation();
            this.Feelanimation.PlayAnimation();
            SearchPlaceTextview = FindViewById<TextView>(Resource.Id.SearchPlaceTextview);
            SearchPlaceCardview = FindViewById<CardView>(Resource.Id.SearchPlaceCardview);
            Service = WeatherReportShared.Startup.Init();
            BaseViewModel = Service.GetService<BaseViewModel>();
            ViewModel = Service.GetService<WeatherViewModel>();
            requestLocationPermission();
            SearchPlaceCardview.Click += PlaceSearchClicked;
            if (!PlacesApi.IsInitialized)
            {
                PlacesApi.Initialize(this, WeatherReportShared.Utils.Constants.GooglePlace_API_KEY);
            }
            MakeDefaultCheckBox.CheckedChange += (s, e) =>
            {
                if (MakeDefaultCheckBox.Checked)
                {
                    ViewModel.IsLocationDefaulted = e.IsChecked;
                }
            };
            BindResources();
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            ViewSunriseLabel.Click += NavigateToSunriseScreen;
        }


        private void BindResources()
        {
            this.Cityext = this.FindViewById<TextView>(Resource.Id.Cityext);
            this.DateText = this.FindViewById<TextView>(Resource.Id.DateText);
            this.TempText = this.FindViewById<TextView>(Resource.Id.TempText);
            this.WeatherImage = this.FindViewById<ImageView>(Resource.Id.WeatherImage);
            this.WeatherDescp = this.FindViewById<TextView>(Resource.Id.WeatherDescp);
            this.WindText = this.FindViewById<TextView>(Resource.Id.WindText);
            this.Humidityext = this.FindViewById<TextView>(Resource.Id.Humidityext);
            this.HowItFeelText = this.FindViewById<TextView>(Resource.Id.HowItFeelText);
            Cityext.TextChanged += (o, e) => ViewModel.PlaceName = e.Text.ToString();
            DateText.TextChanged += (o, e) => ViewModel.Data = e.Text.ToString();
            TempText.TextChanged += (o, e) => ViewModel.Temperature = e.Text.ToString();
            WeatherDescp.TextChanged += (o, e) => ViewModel.WeatherDescp = e.Text.ToString();
            WindText.TextChanged += (o, e) => ViewModel.Wind = e.Text.ToString();
            Humidityext.TextChanged += (o, e) => ViewModel.Humidity = e.Text.ToString();
            HowItFeelText.TextChanged += (o, e) => ViewModel.FeelsLike = e.Text.ToString();
            if (!string.IsNullOrEmpty(ViewModel.WeatherImageURL))
            {
                Picasso.Get()
               .Load(ViewModel.WeatherImageURL)
               .Fit()
                .CenterCrop()
               .NoFade()
               .Into(this.WeatherImage);
            }
        }


        void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Cityext.Text = ViewModel.PlaceName;
            DateText.Text = ViewModel.Data;
            TempText.Text = ViewModel.Temperature;
            WeatherDescp.Text = ViewModel.WeatherDescp;
            WindText.Text = ViewModel.Wind;
            Humidityext.Text = ViewModel.Humidity;
            HowItFeelText.Text = ViewModel.FeelsLike;
            if (!string.IsNullOrEmpty(ViewModel.WeatherImageURL))
            {
                Picasso.Get()
               .Load(ViewModel.WeatherImageURL)
               .Fit()
                .CenterCrop()
               .NoFade()
               .Into(this.WeatherImage);
            }
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

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            var place = Autocomplete.GetPlaceFromIntent(data);
            ViewModel.Latitude = place.LatLng.Latitude;
            ViewModel.Longitude = place.LatLng.Longitude;
            ViewModel.PlaceName = place.Name;
            SearchPlaceTextview.Text = place.Name;
            ViewModel.getWeatherData();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        /// <summary>
        /// Requesting location permission
        /// </summary>
        public void requestLocationPermission()
        {

            Task.Run(async () => {
                try
                {
                    var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                    if (status == PermissionStatus.Granted)
                    {
                        ViewModel.Location = await Geolocation.GetLastKnownLocationAsync();
                        if (ViewModel.Latitude == 0 && ViewModel.Longitude == 0)
                        {
                            ViewModel.Location = await Geolocation.GetLocationAsync(new GeolocationRequest
                            {
                                DesiredAccuracy = GeolocationAccuracy.Medium,
                                Timeout = TimeSpan.FromSeconds(15)
                            });
                        }
                    }
                    else
                    {
                        status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                        if (status == PermissionStatus.Granted)
                        {
                            ViewModel.Location = await Geolocation.GetLastKnownLocationAsync();
                            if (ViewModel.Location == null)
                            {
                                ViewModel.Location = await Geolocation.GetLocationAsync(new GeolocationRequest
                                {
                                    DesiredAccuracy = GeolocationAccuracy.Medium,
                                    Timeout = TimeSpan.FromSeconds(15)
                                });
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }
            });
        }
        //TODO Navigation using viewmodel
        void NavigateToSunriseScreen(object sender, EventArgs e)
        {
            Intent navigate = new Intent(this, typeof(SunRiseActivity));
            StartActivity(navigate);
        }
    }
}
