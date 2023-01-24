using System;
using WeatherReportShared.Interfaces;
using Xamarin.Essentials;

namespace WeatherReportShared.Services
{
    public class ConnectivityService : IConnectivityService
    {
        public bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
    }
}

