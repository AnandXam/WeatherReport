using System;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using WeatherReportShared.Helpers;

namespace WeatherReport.Test.Helpers
{

    [TestFixture]
    public class HttpClientTests
    {   
        [Test]
        [TestCase(1, false)]
        [TestCase(1, true)]
        [TestCase(1, true)]
        [TestCase(1, true, false)]
        [TestCase(1, true, true)]
        public void HttpclientHelper_WhenCalled_ReturnsHttpClientObject(int timeout = 0, bool isminute = false, bool acceptMediaType = false)
        {
            var test = new HttpClientHelper().SetupClient();
            Assert.IsNotNull(test);
        }

        [Test]
        public void SetupClient_WithTimeoutInMinutes_ReturnsHttpClientWithTimeout()
        {
            var httpClientHelper = new HttpClientHelper();
            var client = httpClientHelper.SetupClient(timeOut: 30);
            Assert.That(client.Timeout, Is.EqualTo(TimeSpan.FromMinutes(30)));
        }

        [Test]
        public void SetupClient_WithTimeoutInSeconds_ReturnsHttpClientWithTimeout()
        {
            var httpClientHelper = new HttpClientHelper();
            var client = httpClientHelper.SetupClient(timeOut: 30, isMinutes: false);
            Assert.That(client.Timeout, Is.EqualTo(TimeSpan.FromSeconds(30)));
        }

        [Test]
        public void SetupClient_WithAcceptMediaType_ReturnsHttpClientWithAcceptMediaType()
        {
            var httpClientHelper = new HttpClientHelper();
            var client = httpClientHelper.SetupClient(acceptMediaType: true, mediaType: "application/json");
            Assert.That(client.DefaultRequestHeaders.Accept.First().MediaType, Is.EqualTo("application/json"));
        }

        [Test]
        public void SetupClient_WithoutAcceptMediaType_ReturnsHttpClientWithoutAcceptMediaType()
        {
            var httpClientHelper = new HttpClientHelper();
            var client = httpClientHelper.SetupClient();
            Assert.IsFalse(client.DefaultRequestHeaders.Accept.Any());
        }
    }
}


