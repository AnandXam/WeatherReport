using System;
using InteractiveAlert;

namespace WeatherReportShared.Interfaces
{
    public interface IAlertService
    {
        void Show(string message, InteractiveAlertStyle type);
    }
}

