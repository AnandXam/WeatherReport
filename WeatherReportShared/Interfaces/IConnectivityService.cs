using System;
namespace WeatherReportShared.Interfaces
{
    public interface IConnectivityService
    {
        bool IsConnected { get; }
    }
}

