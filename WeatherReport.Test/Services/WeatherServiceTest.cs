using System;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using WeatherReport.Test.Helpers;
using WeatherReport.Test.Interfaces;
using Moq;
using Moq.Protected;
using WeatherReportShared.Services;
using WeatherReport.Test.TestData;

namespace WeatherReport.Test.Services
{
    [TestFixture]
    public class WeatherServiceTest
    {
        IConnection Connection;
        HttpMessageHandler httpMessageHandler;
        WeatherService weatherServiceTestObject;


        [SetUp]
        public void Setup_WeatherServiceTest()
        {
            weatherServiceTestObject = new WeatherService();
            Connection = Substitute.For<IConnection>();
            Connection.NetworkConnected().Returns(true);
            httpMessageHandler = Substitute.For<HttpMessageHandler>();

        }
        [Test]
        [TestCase(51.509865, -0.118092)]
        public void GetWeatherDetails_ForValidLatitudeAndLongitude(double latitude,double longitude)
        {
            //Act
            var currentWeather = weatherServiceTestObject.GetWeatherForLocation(longitude, latitude);
            //Assert
            Assert.That(WeatherDetailsTestData.FakeCurrentWeather.timezone, Is.EqualTo(currentWeather.Result.timezone));
        }
        [Test]
        [TestCase(56265898, 56236589)]
        public void GetWeatherDetails_ForInValidLatitudeAndLongitude(double latitude, double longitude)
        {
            //Act
            var currentWeather = weatherServiceTestObject.GetWeatherForLocation(longitude, latitude);
            //Assert
            Assert.That(WeatherDetailsTestData.FakeCurrentWeather.timezone, Is.Not.EqualTo(currentWeather.Result.timezone));
        }
    }
}

