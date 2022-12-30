using System;
using Newtonsoft.Json;
using NUnit.Framework;
using WeatherReport.Test.Database;

namespace WeatherReport.Test.Models
{
    [TestFixture]
    public class MockWeatherData : SerializationTestBase
    {
        [Test]
        public void ValidLocationTest()
        {
            var text = @"{
    ""lat"": 40.7306,
    ""lon"": -73.9352,
    ""timezone"": ""America/New_York"",
    ""timezone_offset"": -18000,
    ""current"": {
        ""dt"": 1672400694,
        ""sunrise"": 1672402768,
        ""sunset"": 1672436207,
        ""temp"": 277.09,
        ""feels_like"": 275.83,
        ""pressure"": 1026,
        ""humidity"": 73,
        ""dew_point"": 272.75,
        ""uvi"": 0,
        ""clouds"": 20,
        ""visibility"": 10000,
        ""wind_speed"": 1.54,
        ""wind_deg"": 210,
        ""weather"": [
            {
                ""id"": 801,
                ""main"": ""Clouds"",
                ""description"": ""few clouds"",
                ""icon"": ""02n""
            }
        ]
    },
    ""minutely"": [
        {
            ""dt"": 1672400700,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672400760,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672400820,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672400880,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672400940,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672401000,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672401060,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672401120,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672401180,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672401240,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672401300,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672401360,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672401420,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672401480,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672401540,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672401600,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672401660,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672401720,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672401780,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672401840,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672401900,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672401960,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672402020,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672402080,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672402140,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672402200,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672402260,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672402320,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672402380,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672402440,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672402500,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672402560,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672402620,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672402680,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672402740,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672402800,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672402860,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672402920,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672402980,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672403040,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672403100,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672403160,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672403220,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672403280,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672403340,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672403400,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672403460,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672403520,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672403580,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672403640,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672403700,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672403760,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672403820,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672403880,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672403940,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672404000,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672404060,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672404120,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672404180,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672404240,
            ""precipitation"": 0
        },
        {
            ""dt"": 1672404300,
            ""precipitation"": 0
        }
    ],
    ""hourly"": [
        {
            ""dt"": 1672398000,
            ""temp"": 277.17,
            ""feels_like"": 274.6,
            ""pressure"": 1026,
            ""humidity"": 74,
            ""dew_point"": 272.98,
            ""uvi"": 0,
            ""clouds"": 16,
            ""visibility"": 10000,
            ""wind_speed"": 2.84,
            ""wind_deg"": 228,
            ""wind_gust"": 6.39,
            ""weather"": [
                {
                    ""id"": 801,
                    ""main"": ""Clouds"",
                    ""description"": ""few clouds"",
                    ""icon"": ""02n""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672401600,
            ""temp"": 277.09,
            ""feels_like"": 274.48,
            ""pressure"": 1026,
            ""humidity"": 73,
            ""dew_point"": 272.75,
            ""uvi"": 0,
            ""clouds"": 20,
            ""visibility"": 10000,
            ""wind_speed"": 2.88,
            ""wind_deg"": 219,
            ""wind_gust"": 6.17,
            ""weather"": [
                {
                    ""id"": 801,
                    ""main"": ""Clouds"",
                    ""description"": ""few clouds"",
                    ""icon"": ""02n""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672405200,
            ""temp"": 277.17,
            ""feels_like"": 274.52,
            ""pressure"": 1026,
            ""humidity"": 75,
            ""dew_point"": 273.15,
            ""uvi"": 0.13,
            ""clouds"": 16,
            ""visibility"": 10000,
            ""wind_speed"": 2.94,
            ""wind_deg"": 214,
            ""wind_gust"": 6.87,
            ""weather"": [
                {
                    ""id"": 801,
                    ""main"": ""Clouds"",
                    ""description"": ""few clouds"",
                    ""icon"": ""02d""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672408800,
            ""temp"": 277.61,
            ""feels_like"": 275.27,
            ""pressure"": 1026,
            ""humidity"": 75,
            ""dew_point"": 273.57,
            ""uvi"": 0.51,
            ""clouds"": 12,
            ""visibility"": 10000,
            ""wind_speed"": 2.66,
            ""wind_deg"": 218,
            ""wind_gust"": 6.98,
            ""weather"": [
                {
                    ""id"": 801,
                    ""main"": ""Clouds"",
                    ""description"": ""few clouds"",
                    ""icon"": ""02d""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672412400,
            ""temp"": 278.63,
            ""feels_like"": 276.59,
            ""pressure"": 1026,
            ""humidity"": 73,
            ""dew_point"": 274.18,
            ""uvi"": 1.06,
            ""clouds"": 8,
            ""visibility"": 10000,
            ""wind_speed"": 2.54,
            ""wind_deg"": 229,
            ""wind_gust"": 6.67,
            ""weather"": [
                {
                    ""id"": 800,
                    ""main"": ""Clear"",
                    ""description"": ""clear sky"",
                    ""icon"": ""01d""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672416000,
            ""temp"": 280.25,
            ""feels_like"": 278.21,
            ""pressure"": 1026,
            ""humidity"": 70,
            ""dew_point"": 275.16,
            ""uvi"": 1.56,
            ""clouds"": 4,
            ""visibility"": 10000,
            ""wind_speed"": 2.95,
            ""wind_deg"": 220,
            ""wind_gust"": 5.96,
            ""weather"": [
                {
                    ""id"": 800,
                    ""main"": ""Clear"",
                    ""description"": ""clear sky"",
                    ""icon"": ""01d""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672419600,
            ""temp"": 282.13,
            ""feels_like"": 280.17,
            ""pressure"": 1025,
            ""humidity"": 70,
            ""dew_point"": 276.82,
            ""uvi"": 1.75,
            ""clouds"": 1,
            ""visibility"": 10000,
            ""wind_speed"": 3.46,
            ""wind_deg"": 208,
            ""wind_gust"": 6.44,
            ""weather"": [
                {
                    ""id"": 800,
                    ""main"": ""Clear"",
                    ""description"": ""clear sky"",
                    ""icon"": ""01d""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672423200,
            ""temp"": 283.1,
            ""feels_like"": 281.36,
            ""pressure"": 1024,
            ""humidity"": 70,
            ""dew_point"": 277.75,
            ""uvi"": 1.51,
            ""clouds"": 2,
            ""visibility"": 10000,
            ""wind_speed"": 3.44,
            ""wind_deg"": 212,
            ""wind_gust"": 6.89,
            ""weather"": [
                {
                    ""id"": 800,
                    ""main"": ""Clear"",
                    ""description"": ""clear sky"",
                    ""icon"": ""01d""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672426800,
            ""temp"": 283.81,
            ""feels_like"": 282.76,
            ""pressure"": 1024,
            ""humidity"": 70,
            ""dew_point"": 278.45,
            ""uvi"": 0.96,
            ""clouds"": 14,
            ""visibility"": 10000,
            ""wind_speed"": 3.04,
            ""wind_deg"": 210,
            ""wind_gust"": 7.11,
            ""weather"": [
                {
                    ""id"": 801,
                    ""main"": ""Clouds"",
                    ""description"": ""few clouds"",
                    ""icon"": ""02d""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672430400,
            ""temp"": 283.82,
            ""feels_like"": 282.82,
            ""pressure"": 1024,
            ""humidity"": 72,
            ""dew_point"": 278.9,
            ""uvi"": 0.44,
            ""clouds"": 18,
            ""visibility"": 10000,
            ""wind_speed"": 2.62,
            ""wind_deg"": 203,
            ""wind_gust"": 6.88,
            ""weather"": [
                {
                    ""id"": 801,
                    ""main"": ""Clouds"",
                    ""description"": ""few clouds"",
                    ""icon"": ""02d""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672434000,
            ""temp"": 283.02,
            ""feels_like"": 281.89,
            ""pressure"": 1023,
            ""humidity"": 77,
            ""dew_point"": 279.17,
            ""uvi"": 0,
            ""clouds"": 27,
            ""visibility"": 10000,
            ""wind_speed"": 2.4,
            ""wind_deg"": 196,
            ""wind_gust"": 4.7,
            ""weather"": [
                {
                    ""id"": 802,
                    ""main"": ""Clouds"",
                    ""description"": ""scattered clouds"",
                    ""icon"": ""03d""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672437600,
            ""temp"": 282.2,
            ""feels_like"": 280.8,
            ""pressure"": 1023,
            ""humidity"": 83,
            ""dew_point"": 279.43,
            ""uvi"": 0,
            ""clouds"": 41,
            ""visibility"": 10000,
            ""wind_speed"": 2.57,
            ""wind_deg"": 193,
            ""wind_gust"": 4.42,
            ""weather"": [
                {
                    ""id"": 802,
                    ""main"": ""Clouds"",
                    ""description"": ""scattered clouds"",
                    ""icon"": ""03n""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672441200,
            ""temp"": 281.72,
            ""feels_like"": 280.13,
            ""pressure"": 1023,
            ""humidity"": 87,
            ""dew_point"": 279.66,
            ""uvi"": 0,
            ""clouds"": 53,
            ""visibility"": 10000,
            ""wind_speed"": 2.71,
            ""wind_deg"": 191,
            ""wind_gust"": 5.17,
            ""weather"": [
                {
                    ""id"": 803,
                    ""main"": ""Clouds"",
                    ""description"": ""broken clouds"",
                    ""icon"": ""04n""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672444800,
            ""temp"": 281.37,
            ""feels_like"": 279.69,
            ""pressure"": 1023,
            ""humidity"": 90,
            ""dew_point"": 279.76,
            ""uvi"": 0,
            ""clouds"": 60,
            ""visibility"": 10000,
            ""wind_speed"": 2.75,
            ""wind_deg"": 204,
            ""wind_gust"": 6.29,
            ""weather"": [
                {
                    ""id"": 803,
                    ""main"": ""Clouds"",
                    ""description"": ""broken clouds"",
                    ""icon"": ""04n""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672448400,
            ""temp"": 281.07,
            ""feels_like"": 279.32,
            ""pressure"": 1023,
            ""humidity"": 92,
            ""dew_point"": 279.75,
            ""uvi"": 0,
            ""clouds"": 100,
            ""visibility"": 10000,
            ""wind_speed"": 2.77,
            ""wind_deg"": 201,
            ""wind_gust"": 7.66,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04n""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672452000,
            ""temp"": 280.71,
            ""feels_like"": 278.88,
            ""pressure"": 1023,
            ""humidity"": 93,
            ""dew_point"": 279.69,
            ""uvi"": 0,
            ""clouds"": 100,
            ""visibility"": 10000,
            ""wind_speed"": 2.78,
            ""wind_deg"": 216,
            ""wind_gust"": 8.84,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04n""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672455600,
            ""temp"": 280.4,
            ""feels_like"": 278.62,
            ""pressure"": 1023,
            ""humidity"": 95,
            ""dew_point"": 279.54,
            ""uvi"": 0,
            ""clouds"": 100,
            ""visibility"": 10000,
            ""wind_speed"": 2.62,
            ""wind_deg"": 208,
            ""wind_gust"": 8.37,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04n""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672459200,
            ""temp"": 280.15,
            ""feels_like"": 278.54,
            ""pressure"": 1023,
            ""humidity"": 95,
            ""dew_point"": 279.35,
            ""uvi"": 0,
            ""clouds"": 90,
            ""visibility"": 10000,
            ""wind_speed"": 2.35,
            ""wind_deg"": 212,
            ""wind_gust"": 3.84,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04n""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672462800,
            ""temp"": 280.13,
            ""feels_like"": 278.43,
            ""pressure"": 1023,
            ""humidity"": 95,
            ""dew_point"": 279.37,
            ""uvi"": 0,
            ""clouds"": 92,
            ""visibility"": 10000,
            ""wind_speed"": 2.46,
            ""wind_deg"": 202,
            ""wind_gust"": 4.79,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04n""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672466400,
            ""temp"": 280.03,
            ""feels_like"": 278.33,
            ""pressure"": 1022,
            ""humidity"": 96,
            ""dew_point"": 279.3,
            ""uvi"": 0,
            ""clouds"": 93,
            ""visibility"": 10000,
            ""wind_speed"": 2.43,
            ""wind_deg"": 199,
            ""wind_gust"": 4.32,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04n""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672470000,
            ""temp"": 279.88,
            ""feels_like"": 278.24,
            ""pressure"": 1022,
            ""humidity"": 96,
            ""dew_point"": 279.24,
            ""uvi"": 0,
            ""clouds"": 97,
            ""visibility"": 10000,
            ""wind_speed"": 2.33,
            ""wind_deg"": 213,
            ""wind_gust"": 3.92,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04n""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672473600,
            ""temp"": 279.93,
            ""feels_like"": 278.32,
            ""pressure"": 1022,
            ""humidity"": 96,
            ""dew_point"": 279.33,
            ""uvi"": 0,
            ""clouds"": 97,
            ""visibility"": 10000,
            ""wind_speed"": 2.3,
            ""wind_deg"": 204,
            ""wind_gust"": 4.5,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04n""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672477200,
            ""temp"": 279.75,
            ""feels_like"": 278.31,
            ""pressure"": 1021,
            ""humidity"": 97,
            ""dew_point"": 279.25,
            ""uvi"": 0,
            ""clouds"": 94,
            ""visibility"": 10000,
            ""wind_speed"": 2.08,
            ""wind_deg"": 204,
            ""wind_gust"": 2.9,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04n""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672480800,
            ""temp"": 279.8,
            ""feels_like"": 278.5,
            ""pressure"": 1021,
            ""humidity"": 97,
            ""dew_point"": 279.37,
            ""uvi"": 0,
            ""clouds"": 96,
            ""visibility"": 10000,
            ""wind_speed"": 1.94,
            ""wind_deg"": 204,
            ""wind_gust"": 2,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04n""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672484400,
            ""temp"": 279.87,
            ""feels_like"": 278.35,
            ""pressure"": 1020,
            ""humidity"": 97,
            ""dew_point"": 279.32,
            ""uvi"": 0,
            ""clouds"": 97,
            ""visibility"": 10000,
            ""wind_speed"": 2.19,
            ""wind_deg"": 198,
            ""wind_gust"": 2.36,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04n""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672488000,
            ""temp"": 280.04,
            ""feels_like"": 278.68,
            ""pressure"": 1020,
            ""humidity"": 96,
            ""dew_point"": 279.45,
            ""uvi"": 0,
            ""clouds"": 97,
            ""visibility"": 10000,
            ""wind_speed"": 2.04,
            ""wind_deg"": 204,
            ""wind_gust"": 2.31,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04n""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672491600,
            ""temp"": 280.48,
            ""feels_like"": 278.91,
            ""pressure"": 1020,
            ""humidity"": 97,
            ""dew_point"": 279.91,
            ""uvi"": 0.09,
            ""clouds"": 100,
            ""visibility"": 10000,
            ""wind_speed"": 2.37,
            ""wind_deg"": 205,
            ""wind_gust"": 3.63,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04d""
                }
            ],
            ""pop"": 0.16
        },
        {
            ""dt"": 1672495200,
            ""temp"": 281.13,
            ""feels_like"": 279.8,
            ""pressure"": 1019,
            ""humidity"": 97,
            ""dew_point"": 280.57,
            ""uvi"": 0.35,
            ""clouds"": 100,
            ""visibility"": 10000,
            ""wind_speed"": 2.22,
            ""wind_deg"": 175,
            ""wind_gust"": 4.13,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04d""
                }
            ],
            ""pop"": 0.23
        },
        {
            ""dt"": 1672498800,
            ""temp"": 281.76,
            ""feels_like"": 280.65,
            ""pressure"": 1019,
            ""humidity"": 96,
            ""dew_point"": 281.15,
            ""uvi"": 0.73,
            ""clouds"": 100,
            ""visibility"": 10000,
            ""wind_speed"": 2.09,
            ""wind_deg"": 205,
            ""wind_gust"": 6.1,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04d""
                }
            ],
            ""pop"": 0.15
        },
        {
            ""dt"": 1672502400,
            ""temp"": 282.23,
            ""feels_like"": 281.77,
            ""pressure"": 1019,
            ""humidity"": 95,
            ""dew_point"": 281.37,
            ""uvi"": 1.17,
            ""clouds"": 100,
            ""visibility"": 10000,
            ""wind_speed"": 1.48,
            ""wind_deg"": 217,
            ""wind_gust"": 4.16,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04d""
                }
            ],
            ""pop"": 0.1
        },
        {
            ""dt"": 1672506000,
            ""temp"": 282.72,
            ""feels_like"": 282.24,
            ""pressure"": 1017,
            ""humidity"": 94,
            ""dew_point"": 281.71,
            ""uvi"": 1.32,
            ""clouds"": 100,
            ""visibility"": 10000,
            ""wind_speed"": 1.57,
            ""wind_deg"": 154,
            ""wind_gust"": 2.66,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04d""
                }
            ],
            ""pop"": 0.07
        },
        {
            ""dt"": 1672509600,
            ""temp"": 282.67,
            ""feels_like"": 282.02,
            ""pressure"": 1016,
            ""humidity"": 96,
            ""dew_point"": 281.97,
            ""uvi"": 1.14,
            ""clouds"": 100,
            ""visibility"": 10000,
            ""wind_speed"": 1.73,
            ""wind_deg"": 161,
            ""wind_gust"": 3.04,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04d""
                }
            ],
            ""pop"": 0.06
        },
        {
            ""dt"": 1672513200,
            ""temp"": 282.69,
            ""feels_like"": 282.04,
            ""pressure"": 1014,
            ""humidity"": 97,
            ""dew_point"": 282.2,
            ""uvi"": 0.61,
            ""clouds"": 100,
            ""visibility"": 8015,
            ""wind_speed"": 1.73,
            ""wind_deg"": 130,
            ""wind_gust"": 2.32,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04d""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672516800,
            ""temp"": 282.62,
            ""feels_like"": 282.62,
            ""pressure"": 1014,
            ""humidity"": 98,
            ""dew_point"": 282.3,
            ""uvi"": 0.28,
            ""clouds"": 100,
            ""visibility"": 3943,
            ""wind_speed"": 1.2,
            ""wind_deg"": 146,
            ""wind_gust"": 1.55,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04d""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672520400,
            ""temp"": 282.47,
            ""feels_like"": 282.47,
            ""pressure"": 1014,
            ""humidity"": 99,
            ""dew_point"": 282.28,
            ""uvi"": 0,
            ""clouds"": 100,
            ""visibility"": 3283,
            ""wind_speed"": 1.05,
            ""wind_deg"": 148,
            ""wind_gust"": 1.42,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04d""
                }
            ],
            ""pop"": 0
        },
        {
            ""dt"": 1672524000,
            ""temp"": 282.38,
            ""feels_like"": 282.38,
            ""pressure"": 1013,
            ""humidity"": 99,
            ""dew_point"": 282.18,
            ""uvi"": 0,
            ""clouds"": 100,
            ""visibility"": 398,
            ""wind_speed"": 0.92,
            ""wind_deg"": 104,
            ""wind_gust"": 1.21,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04n""
                }
            ],
            ""pop"": 0.05
        },
        {
            ""dt"": 1672527600,
            ""temp"": 282.55,
            ""feels_like"": 282.16,
            ""pressure"": 1012,
            ""humidity"": 99,
            ""dew_point"": 282.42,
            ""uvi"": 0,
            ""clouds"": 100,
            ""visibility"": 223,
            ""wind_speed"": 1.46,
            ""wind_deg"": 145,
            ""wind_gust"": 1.95,
            ""weather"": [
                {
                    ""id"": 500,
                    ""main"": ""Rain"",
                    ""description"": ""light rain"",
                    ""icon"": ""10n""
                }
            ],
            ""pop"": 0.28,
            ""rain"": {
                ""1h"": 0.15
            }
        },
        {
            ""dt"": 1672531200,
            ""temp"": 282.42,
            ""feels_like"": 282.15,
            ""pressure"": 1011,
            ""humidity"": 99,
            ""dew_point"": 282.29,
            ""uvi"": 0,
            ""clouds"": 100,
            ""visibility"": 129,
            ""wind_speed"": 1.34,
            ""wind_deg"": 159,
            ""wind_gust"": 1.81,
            ""weather"": [
                {
                    ""id"": 500,
                    ""main"": ""Rain"",
                    ""description"": ""light rain"",
                    ""icon"": ""10n""
                }
            ],
            ""pop"": 0.81,
            ""rain"": {
                ""1h"": 0.53
            }
        },
        {
            ""dt"": 1672534800,
            ""temp"": 282.72,
            ""feels_like"": 281.71,
            ""pressure"": 1010,
            ""humidity"": 100,
            ""dew_point"": 282.63,
            ""uvi"": 0,
            ""clouds"": 100,
            ""visibility"": 111,
            ""wind_speed"": 2.16,
            ""wind_deg"": 162,
            ""wind_gust"": 3.21,
            ""weather"": [
                {
                    ""id"": 500,
                    ""main"": ""Rain"",
                    ""description"": ""light rain"",
                    ""icon"": ""10n""
                }
            ],
            ""pop"": 0.99,
            ""rain"": {
                ""1h"": 0.5
            }
        },
        {
            ""dt"": 1672538400,
            ""temp"": 282.89,
            ""feels_like"": 281.36,
            ""pressure"": 1009,
            ""humidity"": 99,
            ""dew_point"": 282.73,
            ""uvi"": 0,
            ""clouds"": 100,
            ""visibility"": 102,
            ""wind_speed"": 2.98,
            ""wind_deg"": 181,
            ""wind_gust"": 7.77,
            ""weather"": [
                {
                    ""id"": 500,
                    ""main"": ""Rain"",
                    ""description"": ""light rain"",
                    ""icon"": ""10n""
                }
            ],
            ""pop"": 1,
            ""rain"": {
                ""1h"": 0.59
            }
        },
        {
            ""dt"": 1672542000,
            ""temp"": 283.03,
            ""feels_like"": 281.14,
            ""pressure"": 1008,
            ""humidity"": 99,
            ""dew_point"": 282.89,
            ""uvi"": 0,
            ""clouds"": 100,
            ""visibility"": 89,
            ""wind_speed"": 3.72,
            ""wind_deg"": 172,
            ""wind_gust"": 10.24,
            ""weather"": [
                {
                    ""id"": 500,
                    ""main"": ""Rain"",
                    ""description"": ""light rain"",
                    ""icon"": ""10n""
                }
            ],
            ""pop"": 1,
            ""rain"": {
                ""1h"": 0.12
            }
        },
        {
            ""dt"": 1672545600,
            ""temp"": 283.28,
            ""feels_like"": 282.93,
            ""pressure"": 1007,
            ""humidity"": 99,
            ""dew_point"": 283.05,
            ""uvi"": 0,
            ""clouds"": 100,
            ""visibility"": 90,
            ""wind_speed"": 4.66,
            ""wind_deg"": 184,
            ""wind_gust"": 13.39,
            ""weather"": [
                {
                    ""id"": 500,
                    ""main"": ""Rain"",
                    ""description"": ""light rain"",
                    ""icon"": ""10n""
                }
            ],
            ""pop"": 1,
            ""rain"": {
                ""1h"": 0.33
            }
        },
        {
            ""dt"": 1672549200,
            ""temp"": 283.84,
            ""feels_like"": 283.55,
            ""pressure"": 1005,
            ""humidity"": 99,
            ""dew_point"": 283.61,
            ""uvi"": 0,
            ""clouds"": 100,
            ""visibility"": 191,
            ""wind_speed"": 4.32,
            ""wind_deg"": 194,
            ""wind_gust"": 12.76,
            ""weather"": [
                {
                    ""id"": 500,
                    ""main"": ""Rain"",
                    ""description"": ""light rain"",
                    ""icon"": ""10n""
                }
            ],
            ""pop"": 1,
            ""rain"": {
                ""1h"": 0.25
            }
        },
        {
            ""dt"": 1672552800,
            ""temp"": 284.68,
            ""feels_like"": 284.45,
            ""pressure"": 1004,
            ""humidity"": 98,
            ""dew_point"": 284.26,
            ""uvi"": 0,
            ""clouds"": 100,
            ""visibility"": 3264,
            ""wind_speed"": 5.12,
            ""wind_deg"": 214,
            ""wind_gust"": 14.79,
            ""weather"": [
                {
                    ""id"": 500,
                    ""main"": ""Rain"",
                    ""description"": ""light rain"",
                    ""icon"": ""10n""
                }
            ],
            ""pop"": 1,
            ""rain"": {
                ""1h"": 0.13
            }
        },
        {
            ""dt"": 1672556400,
            ""temp"": 285.71,
            ""feels_like"": 285.5,
            ""pressure"": 1004,
            ""humidity"": 95,
            ""dew_point"": 284.79,
            ""uvi"": 0,
            ""clouds"": 100,
            ""visibility"": 7531,
            ""wind_speed"": 5.93,
            ""wind_deg"": 226,
            ""wind_gust"": 14.18,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04n""
                }
            ],
            ""pop"": 0.36
        },
        {
            ""dt"": 1672560000,
            ""temp"": 286.17,
            ""feels_like"": 285.85,
            ""pressure"": 1003,
            ""humidity"": 89,
            ""dew_point"": 284.37,
            ""uvi"": 0,
            ""clouds"": 100,
            ""visibility"": 10000,
            ""wind_speed"": 6.45,
            ""wind_deg"": 236,
            ""wind_gust"": 13.85,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04n""
                }
            ],
            ""pop"": 0.53
        },
        {
            ""dt"": 1672563600,
            ""temp"": 286.19,
            ""feels_like"": 285.8,
            ""pressure"": 1003,
            ""humidity"": 86,
            ""dew_point"": 283.81,
            ""uvi"": 0,
            ""clouds"": 100,
            ""visibility"": 10000,
            ""wind_speed"": 6.4,
            ""wind_deg"": 250,
            ""wind_gust"": 13.46,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04n""
                }
            ],
            ""pop"": 0.53
        },
        {
            ""dt"": 1672567200,
            ""temp"": 285.81,
            ""feels_like"": 285.27,
            ""pressure"": 1004,
            ""humidity"": 82,
            ""dew_point"": 282.84,
            ""uvi"": 0,
            ""clouds"": 89,
            ""visibility"": 10000,
            ""wind_speed"": 7,
            ""wind_deg"": 261,
            ""wind_gust"": 13.71,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04n""
                }
            ],
            ""pop"": 0.43
        }
    ],
    ""daily"": [
        {
            ""dt"": 1672416000,
            ""sunrise"": 1672402768,
            ""sunset"": 1672436207,
            ""moonrise"": 1672420200,
            ""moonset"": 1672376940,
            ""moon_phase"": 0.27,
            ""temp"": {
                ""day"": 280.25,
                ""min"": 277.09,
                ""max"": 283.82,
                ""night"": 280.15,
                ""eve"": 282.2,
                ""morn"": 277.31
            },
            ""feels_like"": {
                ""day"": 278.21,
                ""night"": 278.54,
                ""eve"": 280.8,
                ""morn"": 274.74
            },
            ""pressure"": 1026,
            ""humidity"": 70,
            ""dew_point"": 275.16,
            ""wind_speed"": 3.46,
            ""wind_deg"": 208,
            ""wind_gust"": 8.84,
            ""weather"": [
                {
                    ""id"": 800,
                    ""main"": ""Clear"",
                    ""description"": ""clear sky"",
                    ""icon"": ""01d""
                }
            ],
            ""clouds"": 4,
            ""pop"": 0,
            ""uvi"": 1.75
        },
        {
            ""dt"": 1672502400,
            ""sunrise"": 1672489178,
            ""sunset"": 1672522653,
            ""moonrise"": 1672507980,
            ""moonset"": 1672467360,
            ""moon_phase"": 0.3,
            ""temp"": {
                ""day"": 282.23,
                ""min"": 279.75,
                ""max"": 283.28,
                ""night"": 283.28,
                ""eve"": 282.38,
                ""morn"": 279.8
            },
            ""feels_like"": {
                ""day"": 281.77,
                ""night"": 282.93,
                ""eve"": 282.38,
                ""morn"": 278.5
            },
            ""pressure"": 1019,
            ""humidity"": 95,
            ""dew_point"": 281.37,
            ""wind_speed"": 4.66,
            ""wind_deg"": 184,
            ""wind_gust"": 13.39,
            ""weather"": [
                {
                    ""id"": 500,
                    ""main"": ""Rain"",
                    ""description"": ""light rain"",
                    ""icon"": ""10d""
                }
            ],
            ""clouds"": 100,
            ""pop"": 1,
            ""rain"": 2.22,
            ""uvi"": 1.32
        },
        {
            ""dt"": 1672588800,
            ""sunrise"": 1672575586,
            ""sunset"": 1672609101,
            ""moonrise"": 1672595880,
            ""moonset"": 1672557720,
            ""moon_phase"": 0.34,
            ""temp"": {
                ""day"": 283.69,
                ""min"": 280.72,
                ""max"": 286.19,
                ""night"": 280.72,
                ""eve"": 283.34,
                ""morn"": 285.81
            },
            ""feels_like"": {
                ""day"": 282.42,
                ""night"": 279.27,
                ""eve"": 281.8,
                ""morn"": 285.27
            },
            ""pressure"": 1011,
            ""humidity"": 62,
            ""dew_point"": 276.75,
            ""wind_speed"": 7.67,
            ""wind_deg"": 296,
            ""wind_gust"": 14.79,
            ""weather"": [
                {
                    ""id"": 500,
                    ""main"": ""Rain"",
                    ""description"": ""light rain"",
                    ""icon"": ""10d""
                }
            ],
            ""clouds"": 66,
            ""pop"": 1,
            ""rain"": 0.38,
            ""uvi"": 1.25
        },
        {
            ""dt"": 1672675200,
            ""sunrise"": 1672661991,
            ""sunset"": 1672695551,
            ""moonrise"": 1672683960,
            ""moonset"": 1672648080,
            ""moon_phase"": 0.37,
            ""temp"": {
                ""day"": 282.9,
                ""min"": 279.67,
                ""max"": 285.28,
                ""night"": 282.07,
                ""eve"": 283.99,
                ""morn"": 279.95
            },
            ""feels_like"": {
                ""day"": 281.83,
                ""night"": 281.57,
                ""eve"": 282.91,
                ""morn"": 278.41
            },
            ""pressure"": 1022,
            ""humidity"": 66,
            ""dew_point"": 276.79,
            ""wind_speed"": 2.81,
            ""wind_deg"": 244,
            ""wind_gust"": 6.96,
            ""weather"": [
                {
                    ""id"": 802,
                    ""main"": ""Clouds"",
                    ""description"": ""scattered clouds"",
                    ""icon"": ""03d""
                }
            ],
            ""clouds"": 27,
            ""pop"": 0,
            ""uvi"": 1.71
        },
        {
            ""dt"": 1672761600,
            ""sunrise"": 1672748394,
            ""sunset"": 1672782002,
            ""moonrise"": 1672772340,
            ""moonset"": 1672738320,
            ""moon_phase"": 0.4,
            ""temp"": {
                ""day"": 284.15,
                ""min"": 281.55,
                ""max"": 286.32,
                ""night"": 285.97,
                ""eve"": 286.32,
                ""morn"": 281.58
            },
            ""feels_like"": {
                ""day"": 283.32,
                ""night"": 285.45,
                ""eve"": 285.7,
                ""morn"": 280.25
            },
            ""pressure"": 1019,
            ""humidity"": 77,
            ""dew_point"": 280.17,
            ""wind_speed"": 5.67,
            ""wind_deg"": 203,
            ""wind_gust"": 15.72,
            ""weather"": [
                {
                    ""id"": 803,
                    ""main"": ""Clouds"",
                    ""description"": ""broken clouds"",
                    ""icon"": ""04d""
                }
            ],
            ""clouds"": 74,
            ""pop"": 0.13,
            ""uvi"": 2
        },
        {
            ""dt"": 1672851600,
            ""sunrise"": 1672834795,
            ""sunset"": 1672868454,
            ""moonrise"": 1672861020,
            ""moonset"": 1672828560,
            ""moon_phase"": 0.43,
            ""temp"": {
                ""day"": 289.28,
                ""min"": 285.84,
                ""max"": 289.28,
                ""night"": 286.56,
                ""eve"": 287.54,
                ""morn"": 286.72
            },
            ""feels_like"": {
                ""day"": 288.99,
                ""night"": 286.44,
                ""eve"": 287.38,
                ""morn"": 286.67
            },
            ""pressure"": 1010,
            ""humidity"": 78,
            ""dew_point"": 285.28,
            ""wind_speed"": 5.33,
            ""wind_deg"": 225,
            ""wind_gust"": 14.81,
            ""weather"": [
                {
                    ""id"": 500,
                    ""main"": ""Rain"",
                    ""description"": ""light rain"",
                    ""icon"": ""10d""
                }
            ],
            ""clouds"": 100,
            ""pop"": 0.53,
            ""rain"": 1.16,
            ""uvi"": 2
        },
        {
            ""dt"": 1672938000,
            ""sunrise"": 1672921194,
            ""sunset"": 1672954909,
            ""moonrise"": 1672950240,
            ""moonset"": 1672918440,
            ""moon_phase"": 0.46,
            ""temp"": {
                ""day"": 279.2,
                ""min"": 274.16,
                ""max"": 286.83,
                ""night"": 274.16,
                ""eve"": 274.73,
                ""morn"": 281.96
            },
            ""feels_like"": {
                ""day"": 275.35,
                ""night"": 269.1,
                ""eve"": 269.59,
                ""morn"": 279.19
            },
            ""pressure"": 1025,
            ""humidity"": 50,
            ""dew_point"": 269.55,
            ""wind_speed"": 6.49,
            ""wind_deg"": 17,
            ""wind_gust"": 9.86,
            ""weather"": [
                {
                    ""id"": 500,
                    ""main"": ""Rain"",
                    ""description"": ""light rain"",
                    ""icon"": ""10d""
                }
            ],
            ""clouds"": 90,
            ""pop"": 0.77,
            ""rain"": 0.8,
            ""uvi"": 2
        },
        {
            ""dt"": 1673024400,
            ""sunrise"": 1673007591,
            ""sunset"": 1673041364,
            ""moonrise"": 1673039760,
            ""moonset"": 1673008020,
            ""moon_phase"": 0.5,
            ""temp"": {
                ""day"": 275.22,
                ""min"": 272.58,
                ""max"": 275.61,
                ""night"": 275.12,
                ""eve"": 275.61,
                ""morn"": 272.65
            },
            ""feels_like"": {
                ""day"": 270.71,
                ""night"": 269.96,
                ""eve"": 270.77,
                ""morn"": 267.82
            },
            ""pressure"": 1039,
            ""humidity"": 48,
            ""dew_point"": 265.3,
            ""wind_speed"": 6.54,
            ""wind_deg"": 60,
            ""wind_gust"": 10.6,
            ""weather"": [
                {
                    ""id"": 804,
                    ""main"": ""Clouds"",
                    ""description"": ""overcast clouds"",
                    ""icon"": ""04d""
                }
            ],
            ""clouds"": 100,
            ""pop"": 0.04,
            ""uvi"": 2
        }
    ]
}";

            var result = JsonConvert.DeserializeObject<WeatherReportShared.Model.OneCallAPI>(text);
            Assert.AreEqual("America/New_York", result.timezone);
        }

        [Test]
        public void InvalidLocationTest()
        {
            var text = @"{
    ""cod"": ""400"",
    ""message"": ""wrong latitude""
}";

            var result = JsonConvert.DeserializeObject<WeatherReportShared.Model.OneCallAPI>(text);
            Assert.AreEqual("inaccurate", result.message);
        }
    }
}

