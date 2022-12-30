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
using WeatherReport.Test.Models;
using WeatherReport.Test.Interfaces;
using Moq;
using Moq.Protected;
namespace WeatherReport.Test.Services
{
    [TestFixture]
    public class WeatherServiceTest
    {
        IConnection Connection;
        HttpMessageHandler httpMessageHandler;

        [SetUp]
        public void Setup_WeatherServiceTest()
        {
            Connection = Substitute.For<IConnection>();
            Connection.NetworkConnected().Returns(true);
            httpMessageHandler = Substitute.For<HttpMessageHandler>();
        }

        [Test]
        [Combinatorial]
        public void Test_GetWeatherForLocation(double lng, double lat)
        {
            var api = "lat=";
            var pars = $"{lat}&lon={lng}";
            var data = new MockWeatherDataSetup().Setup_WeatherData();
            Assert.IsNotNull(data);
            Assert.NotNull(pars);
            Assert.NotNull(api);
            Assert.AreEqual(37.39, data.lat);
        }

        [Test]
        [Combinatorial]
        public void Test_HttpMessageHandler_IsNull(HttpMessageHandler httpMessageHandler)
        {
            Assert.IsNull(httpMessageHandler);
        }

        [Test]
        [Combinatorial]
        public void Test_HttpMessageHandler_IsNotNull(HttpMessageHandler httpMessageHandler)
        {
            Assert.IsNotNull(httpMessageHandler);
        }

        [Test]
        [Combinatorial]
        public void Test_ClientTestIsNotNull(HttpMessageHandler httpMessageHandler)
        {
            var client = new HttpClient(httpMessageHandler)
            {
                BaseAddress = new Uri(WeatherReportShared.Utils.Constants.API_LINK)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Assert.NotNull(client);
            Assert.NotNull(client.BaseAddress);
            Assert.AreEqual(1, client.DefaultRequestHeaders.Accept.Count);
        }

        [Test]
        [Combinatorial]
        public void CreateInstance_OfT<T>(T objectType)
        {
            var result = Activator.CreateInstance<T>();
            Assert.IsNotNull(result);
        }

        [Test]
        [Combinatorial]
        public void Test_GetRequestAsync<T>(string apiUrl, string pars)
        {
            var result = new MockWeatherData();

            var request = new Mock<HttpMessageHandler>(HttpMethod.Get, $"{WeatherReportShared.Utils.Constants.API_LINK}{apiUrl}{pars}&appid={WeatherReportShared.Utils.Constants.API_KEY}");
            request.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(new MockWeatherData().ToString())
                });

            var httpClient = new HttpClient(request.Object);
            var send = httpClient.GetAsync($"{WeatherReportShared.Utils.Constants.API_LINK}{apiUrl}{pars}&appid={WeatherReportShared.Utils.Constants.API_KEY}").Result;

            if (send.StatusCode == HttpStatusCode.OK)
            {
                var res = send.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<MockWeatherData>(res);
            }

            Assert.IsNotNull(result);
        }

        [Test]
        [Combinatorial]
        public void Test_GetRequestAsync_Returns401<T>(string apiUrl, string pars)
        {
            var request = new Mock<HttpMessageHandler>(HttpMethod.Get, $"1{WeatherReportShared.Utils.Constants.API_LINK}{apiUrl}{pars}&appid={WeatherReportShared.Utils.Constants.API_KEY}");
            request.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Content = new StringContent(new MockWeatherData().ToString())
            });

            var httpClient = new HttpClient(request.Object);
            var send = httpClient.GetAsync($"{WeatherReportShared.Utils.Constants.API_LINK}{apiUrl}{pars}&appid={WeatherReportShared.Utils.Constants.API_KEY}").Result;

            Assert.Equals(401, send.StatusCode);
        }

        [Test]
        [Combinatorial]
        public void Test_GetRequestAsync_Returns404<T>(string apiUrl, string pars)
        {
            var request = new Mock<HttpMessageHandler>(HttpMethod.Get, $"1{WeatherReportShared.Utils.Constants.API_LINK}");
            request.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent(new MockWeatherData().ToString())
                });

            var httpClient = new HttpClient(request.Object);
            var send = httpClient.GetAsync($"1{WeatherReportShared.Utils.Constants.API_LINK}{apiUrl}{pars}&appid={WeatherReportShared.Utils.Constants.API_KEY}").Result;

            Assert.Equals(404, send.StatusCode);
        }

        [Test]
        [Combinatorial]
        public void Test_GetRequestAsync_Exception<T>(string apiUrl, string pars)
        {
            var result = Activator.CreateInstance<T>();

            var request = new Mock<HttpMessageHandler>(HttpMethod.Get, $"{WeatherReportShared.Utils.Constants.API_LINK}");
            request.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(new MockWeatherData().ToString())
            });

            var httpClient = new HttpClient(request.Object);
            var send = httpClient.GetAsync($"{WeatherReportShared.Utils.Constants.API_LINK}{apiUrl}{pars}&appid={WeatherReportShared.Utils.Constants.API_KEY}").Result;

            if (send.StatusCode == HttpStatusCode.OK)
            {
                var res = send.Content.ReadAsStringAsync().Result;
                var r = JsonConvert.DeserializeObject(res);
                result = (T)r;
            }
        }
    }
}

