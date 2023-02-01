using System;
using NUnit.Framework;
using System.Threading.Tasks;
using NSubstitute;
using WeatherReportShared.Interfaces;
using WeatherReportShared.Model;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using WeatherReport.Core.Database;
using WeatherReport.Core.Model;
using Moq;
using WeatherReport.Test.TestData;
using WeatherReportShared.ViewModel;
using WeatherReport.Core.Interfaces;
using AutoMapper;
using Xamarin.Essentials;

namespace WeatherReport.Test.VIewModels
{
    [TestFixture]
    public class WeatherViewModelTests
    {
        IWeatherService weatherService = Substitute.For<IWeatherService>();

        private Mock<IMapper> mapperMock;
        private Mock<IWeatherService> weatherMock;
        private Mock<IAlertService> alertMock;
        private Mock<IConnectivityService> connectivityMock;
        private Mock<IRepository> repositoryMock;

        [SetUp]
        public void Setup()
        {
            weatherMock = new Mock<IWeatherService>();
            connectivityMock = new Mock<IConnectivityService>();
            alertMock = new Mock<IAlertService>();
            repositoryMock = new Mock<IRepository>();
        }


        [Test]
        [TestCase(40.730610, -73.935242)]
        public void checkForSavedLocation_SetsLatitudeAndLongitude_getWeatherData(double expectedLatitude, double expectedLongitude)
        {
            repositoryMock.Setup(r => r.GetData<SqliteUserSettingModel>()).Returns(new SqliteUserSettingModel { SavedLatitude = expectedLatitude, SavedLongitude = expectedLongitude });
            var viewModel = new WeatherViewModel(weatherMock.Object, connectivityMock.Object, alertMock.Object, repositoryMock.Object);

            viewModel.checkForSavedLocation();

            Assert.That(expectedLatitude, Is.EqualTo(viewModel.Latitude));
            Assert.That(expectedLongitude, Is.EqualTo(viewModel.Longitude));
        }

        [Test]
        [TestCase(40.730610, -73.93524)]
        public void SaveLocation_WhenCalled_SaveTheLocationToSqliteDatabase(double expectedLatitude, double expectedLongitude)
        {
            var viewModel = new WeatherViewModel(weatherMock.Object, connectivityMock.Object, alertMock.Object, repositoryMock.Object);
            viewModel.Latitude = expectedLatitude;
            viewModel.Longitude = expectedLongitude;
            viewModel.IsLocationDefaulted = true;

            viewModel.saveLocation();

            repositoryMock.Verify(r => r.SaveData(It.Is<SqliteUserSettingModel>(s => s.SavedLatitude == expectedLatitude && s.SavedLongitude == expectedLongitude)));
        }

        [Test]
        [TestCase(40.730610, -73.935242)]
        public async Task getWeatherData_ForValidCoordinates_ReturnsCorrectWeatherData(double expectedLatitude, double expectedLongitude)
        {
            weatherMock.Setup(w => w.GetWeatherForLocation(expectedLongitude, expectedLatitude)).ReturnsAsync(new OneCallAPIResponseModel());
            var viewModel = new WeatherViewModel(weatherMock.Object, connectivityMock.Object, alertMock.Object, repositoryMock.Object);
            viewModel.Latitude = expectedLatitude;
            viewModel.Longitude = expectedLongitude;

            var result = await viewModel.getWeatherData();

            Assert.IsNotNull(result);
        }

        [Test]
        [TestCase(40730610001,56236598659)]
        public async Task getWeatherData_ForInValidCoordinates_ReturnsInCorrectWeatherData(double latitude,double longitude)
        {
            weatherMock.Setup(w => w.GetWeatherForLocation(longitude, latitude)).ReturnsAsync(new OneCallAPIResponseModel());
            var viewModel = new WeatherViewModel(weatherMock.Object, connectivityMock.Object, alertMock.Object, repositoryMock.Object);
            viewModel.Latitude = latitude;
            viewModel.Longitude = longitude;

            var result = await viewModel.getWeatherData();

            Assert.IsNull(result.message);
        }
    }
}

