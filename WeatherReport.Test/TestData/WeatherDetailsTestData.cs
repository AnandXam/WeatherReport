using System;
using WeatherReportShared.Model;

namespace WeatherReport.Test.TestData
{
	public class WeatherDetailsTestData
	{
        public static OneCallAPIResponseModel FakeCurrentWeather => new OneCallAPIResponseModel
        {
            lat= 51.509865,
            lon = -0.118092,
            timezone= "Europe/London"
        };
    }
}

