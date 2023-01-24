using System;
using SQLite;

namespace WeatherReportShared.Utils
{
    public class Constants
    {
        public static string API_KEY = "020e90ec580b8e4b8c2a4498c055bb91";
        public static string GooglePlace_API_KEY = "AIzaSyAtNFvX5msUFhuZDvc-s0Ki3x_mArovwak";
        public static string API_LINK = "https://api.openweathermap.org/data/2.5/onecall?";
        public static SQLiteConnection? DBConnection { get; set; }
    }
}

