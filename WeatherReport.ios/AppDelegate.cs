using System;
using Foundation;
using Microsoft.Extensions.DependencyInjection;
using UIKit;
using WeatherReportShared.ViewModel;
using Xamarin.Essentials;

namespace WeatherReport.ios
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register ("AppDelegate")]
    public class AppDelegate : UIResponder, IUIApplicationDelegate {
    
        [Export("window")]
        public UIWindow Window { get; set; }
        public static IServiceProvider Service { get; set; }
        WeatherViewModel weatherViewModel { get; set; }
        public static AppDelegate Self { get; private set; }

        [Export ("application:didFinishLaunchingWithOptions:")]
        public bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
        {
            AppDelegate.Self = this;
            Service = WeatherReportShared.Startup.Init();
            weatherViewModel = Service.GetService<WeatherViewModel>();
            var connnect = (Connectivity.NetworkAccess == NetworkAccess.Internet) || (Connectivity.NetworkAccess == NetworkAccess.Local);
            weatherViewModel.IsConnected = connnect;
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method
            return true;
        }

        void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            weatherViewModel.IsConnected = Convert.ToBoolean(e.NetworkAccess);
        }

        // UISceneSession Lifecycle

        [Export ("application:configurationForConnectingSceneSession:options:")]
        public UISceneConfiguration GetConfiguration (UIApplication application, UISceneSession connectingSceneSession, UISceneConnectionOptions options)
        {
            // Called when a new scene session is being created.
            // Use this method to select a configuration to create the new scene with.
            return UISceneConfiguration.Create ("Default Configuration", connectingSceneSession.Role);
        }

        [Export ("application:didDiscardSceneSessions:")]
        public void DidDiscardSceneSessions (UIApplication application, NSSet<UISceneSession> sceneSessions)
        {
            // Called when the user discards a scene session.
            // If any sessions were discarded while the application was not running, this will be called shortly after `FinishedLaunching`.
            // Use this method to release any resources that were specific to the discarded scenes, as they will not return.
        }
    }
}


