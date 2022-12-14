using System;
using Xamarin.CommunityToolkit.ObjectModel;

namespace WeatherReportShared.ViewModel
{
    public class BaseViewModel : ObservableObject
    {
        static bool isBusy = false;
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        static bool isConnected;
        public bool IsConnected
        {
            get => isConnected;
            set => SetProperty(ref isConnected, value);
        }
    }
}

