using Foundation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using UIKit;
using WeatherReportShared.Model;
using WeatherReportShared.ViewModel;
using Xamarin.Essentials;

namespace WeatherReport.ios
{
    public partial class ViewController : UIViewController
    {
        WeatherViewModel ViewModel { get; set; }
        OneCallAPI openWeatherMap = new OneCallAPI();

        public ViewController (IntPtr handle) : base (handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ViewModel = AppDelegate.Service.GetService<WeatherViewModel>();

            GetLocation();

            Cityext.ValueChanged += (o, e) => ViewModel.PlaceName = ((UITextView)o).Text;
            DateText.ValueChanged += (o, e) => ViewModel.Data = ((UITextView)o).Text;
            TempText.ValueChanged += (o, e) => ViewModel.Temperature = ((UITextView)o).Text;
            WeatherDescp.ValueChanged += (o, e) => ViewModel.WeatherDescp = ((UITextView)o).Text;
            ViewModel.Setup();
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Cityext.Text = ViewModel.PlaceName;
            DateText.Text = ViewModel.Data;
            TempText.Text = ViewModel.Temperature;
            WeatherDescp.Text = ViewModel.WeatherDescp;
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }
        void GetLocation()
        {
            Task.Run(() =>
                BeginInvokeOnMainThread(async () =>
                {
                    try
                    {
                        var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
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
                                ViewModel.CanUseGeoloc = true;
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
                                    ViewModel.CanUseGeoloc = true;
                                }
                            }
                            else
                            {
                                ViewModel.CanUseGeoloc = false;
                            }
                        }
                    }
                    catch(Exception ex) { }

                }));
        }
    }
}
