using Foundation;
using Google.Places;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using UIKit;
using WeatherReportShared.Model;
using WeatherReportShared.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeatherReport.ios
{
    public partial class ViewController : UIViewController, IAutocompleteViewControllerDelegate
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
            ViewModel.Setup();
            DateLabel.Text = ViewModel.Data;
            TempLabel.Text = ViewModel.Temperature;
            WeatherDesLabel.Text = ViewModel.WeatherDescp;
            LocationLabel.Text = ViewModel.PlaceName;
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            IsDefaultSwitch.ValueChanged += (o, e) =>
            {
                if (IsDefaultSwitch.On)
                {
                    ViewModel.IsLocationDefaulted = ((UISwitch)o).On;

                }
            };
            UITapGestureRecognizer tapGesture = new UITapGestureRecognizer(Tap);
            tapGesture.NumberOfTapsRequired = 1;
            LocationSearchView.AddGestureRecognizer(tapGesture);
        }

        void Tap(UITapGestureRecognizer tap1)
        {
            var autocompleteViewController = new AutocompleteViewController { Delegate = this };
            PresentViewController(autocompleteViewController, true, null);
        }

        void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            DateLabel.Text = ViewModel.Data;
            TempLabel.Text = ViewModel.Temperature;
            WeatherDesLabel.Text = ViewModel.WeatherDescp;
            LocationLabel.Text = ViewModel.PlaceName;
            if (!string.IsNullOrEmpty(ViewModel.WeatherImageURL))
            { WeatherImage.Image = FromUrl(ViewModel.WeatherImageURL); }              
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
                    catch(Exception ex)
                    { }

                }));
        }
        static UIImage FromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);
        }

        #region AutocompleteViewController Delegate

        public void DidAutocomplete(AutocompleteViewController viewController, Place place)
        {
            // Handle the user's selection.
            DismissViewController(true, null);
            LocationSearchView.Text = place.Name;
            Console.WriteLine($"Place name: {place.Name}");
            ViewModel.Latitude = place.Coordinate.Latitude;
            ViewModel.Longitude = place.Coordinate.Longitude;
        }

        public void DidFailAutocomplete(AutocompleteViewController viewController, NSError error)
        {
            // TODO: handle the error.
            DismissViewController(true, null);
        }

        // User canceled the operation.
        public void WasCancelled(AutocompleteViewController viewController)
        {
            DismissViewController(true, null);
        }

        // Turn the network activity indicator on and off again.
        [Export("didRequestAutocompletePredictions:")]
        public void DidRequestAutocompletePredictions(AutocompleteViewController viewController)
        {
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;
        }

        [Export("didUpdateAutocompletePredictions:")]
        public void DidUpdateAutocompletePredictions(AutocompleteViewController viewController)
        {
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
        }

        #endregion
    }
}
 