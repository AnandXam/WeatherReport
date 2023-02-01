using System;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using WeatherReport.Core.Database;
using WeatherReport.Core.Interfaces;
using WeatherReportShared.Interfaces;
using WeatherReportShared.Services;
using WeatherReportShared.ViewModel;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;

namespace WeatherReportShared.Helpers
{
    public static class InjectionContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            var i = new ServiceCollection();
            i.AddSingleton<IWeatherService, WeatherService>().AddSingleton<IConnectivityService, ConnectivityService>().AddSingleton<IAlertService, AlertService>().
                AddSingleton<IMessenger>(WeakReferenceMessenger.Default).AddSingleton<IRepository, SqLiteRepository>().
                AddSingleton<ISqLiteConnectionFactory, Connection>();
            services = i;
            return services;
        }

        public static IServiceCollection ConfigureViewModels(this IServiceCollection services)
        {
            services.AddTransient<BaseViewModel>().
                AddTransient<WeatherViewModel>().
                AddTransient<SuriseViewModel>();
            return services;
        }
    }
}

