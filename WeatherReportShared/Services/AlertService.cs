using System;
using InteractiveAlert;
using WeatherReportShared.Interfaces;

namespace WeatherReportShared.Services
{
    public class AlertService : IAlertService
    {
        public void Show(string message, InteractiveAlertStyle type)
        {
            var interactiveAlerts = (IInteractiveAlerts)Startup.ServiceProvider.GetService(typeof(IInteractiveAlerts));
            var alertConfig = new InteractiveAlertConfig
            {
                OkButton = new InteractiveActionButton(),
                Title = type == InteractiveAlertStyle.Warning ? "Warningng" : "Error",
                Message = message,
                Style = type == InteractiveAlertStyle.Warning ? InteractiveAlertStyle.Warning : InteractiveAlertStyle.Error,
                IsCancellable = true
            };
            interactiveAlerts.ShowAlert(alertConfig);
        }
    }
}

