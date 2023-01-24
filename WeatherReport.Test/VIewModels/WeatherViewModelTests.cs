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
        public void checkForSavedLocation_ValidSavedLocation_SetsLatitudeAndLongitude()
        {
            // Arrange
            double expectedLatitude = 40.730610;
            double expectedLongitude = -73.935242;
            repositoryMock.Setup(r => r.GetData<SqliteUserSettingModel>()).Returns(new SqliteUserSettingModel { SavedLatitude = expectedLatitude, SavedLongitude = expectedLongitude });
            var viewModel = new WeatherViewModel(weatherMock.Object, connectivityMock.Object, alertMock.Object, repositoryMock.Object);

            // Act
            viewModel.checkForSavedLocation();

            // Assert
            Assert.That(expectedLatitude, Is.EqualTo(viewModel.Latitude));
            Assert.That(expectedLongitude, Is.EqualTo(viewModel.Longitude));
        }

        [Test]
        public void saveLocation_ValidLocation_SavesLocationToRepository()
        {
            // Arrange
            double expectedLatitude = 40.730610;
            double expectedLongitude = -73.935242;
            var viewModel = new WeatherViewModel(weatherMock.Object, connectivityMock.Object, alertMock.Object, repositoryMock.Object);
            viewModel.Latitude = expectedLatitude;
            viewModel.Longitude = expectedLongitude;

            // Act
            viewModel.saveLocation();

            // Assert
            repositoryMock.Verify(r => r.SaveData(It.Is<SqliteUserSettingModel>(s => s.SavedLatitude == expectedLatitude && s.SavedLongitude == expectedLongitude)));
        }

        [Test]
        public async Task getWeatherData_ValidCoordinates_ReturnsWeatherData()
        {
            // Arrange
            double expectedLatitude = 40.730610;
            double expectedLongitude = -73.935242;
            weatherMock.Setup(w => w.GetWeatherForLocation(expectedLongitude, expectedLatitude)).ReturnsAsync(new OneCallAPIResponseModel());
            var viewModel = new WeatherViewModel(weatherMock.Object, connectivityMock.Object, alertMock.Object, repositoryMock.Object);
            viewModel.Latitude = expectedLatitude;
            viewModel.Longitude = expectedLongitude;

            // Act
            var result = await viewModel.getWeatherData();

            // Assert
            Assert.IsNotNull(result);
        }


    }
}

