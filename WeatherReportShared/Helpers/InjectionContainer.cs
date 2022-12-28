using System;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using WeatherReportShared.Interfaces;
using WeatherReportShared.Services;
using WeatherReportShared.ViewModel;

namespace WeatherReportShared.Helpers
{
    public static class InjectionContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            var i = new ServiceCollection();

            i.AddSingleton<IWeatherService, WeatherService>().
                AddSingleton<IMessenger>(WeakReferenceMessenger.Default);

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

