using System;
using NUnit.Framework;
using System.Threading.Tasks;
using WeatherReportShared.Interfaces;
using WeatherReportShared.Model;
using Xamarin.Essentials;
using NSubstitute;

namespace WeatherReport.Test.VIewModels
{
    [TestFixture]
    public class WeatherViewModelTests
    {
        IWeatherService webservice = Substitute.For<IWeatherService>();
        OneCallAPI oneCallAPIModel { get; set; }


        [Test]
        public async Task Test_UserSettings_NotNull_CallGetCity()
        {
            var lastUsedLatitude = Preferences.Get("LocationLatitude", 0.0);
            var lastUsedLongitude = Preferences.Get("LocationLongitude", 0.0);
            if (lastUsedLatitude != 0 && lastUsedLongitude != 0)
            {
                var latitude = lastUsedLatitude;
                var longitude = lastUsedLongitude;
                var data = await webservice.GetWeatherForLocation(latitude,longitude);
                oneCallAPIModel = data;
                Assert.IsNotNull(data);
            } 
        }

        [Test]
        public void Test_SaveSettings_NameIsUnitedStates()
        {
            if (oneCallAPIModel.timezone.Equals("America/New_York"))
            {
                Preferences.Set("LocationLatitude", oneCallAPIModel.lat);
                Preferences.Set("LocationLongitude", oneCallAPIModel.lon);
                var  lastUsedLatitude = Preferences.Get("LocationLatitude", 0.0);
                Assert.IsNotNull(lastUsedLatitude);
            }
        }

        [Test]
        public void Test_SaveSettings_NameIsNotUnitedStates()
        {
            Assert.AreNotEqual(oneCallAPIModel?.timezone, "Asia");
        }

        [Test]
        public void Test_UserSettings_Null()
        {
            var lastUsedLatitude = Preferences.Get("LocationLatitude", 0.0);
            var lastUsedLongitude = Preferences.Get("LocationLongitude", 0.0);
            if (lastUsedLatitude == 0 && lastUsedLongitude == 0)
            {
                Assert.IsNull(lastUsedLatitude);
            }
        }
    }
}

