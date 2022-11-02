using System;
using System.Text;

namespace WeatherReportShared.Utils
{
    public class Helper
    {
        public static string APIRequest(string lat, string lng)
        {
            StringBuilder sb = new StringBuilder(Constants.API_LINK);
            sb.AppendFormat("?lat={0}&lon={1}&APPID={2}&units=imperial", lat, lng, Constants.API_KEY);
            return sb.ToString();
        }
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            dt = dt.AddSeconds(unixTimeStamp).ToLocalTime();
            return dt;
        }
        public static string GetImage(string icon)
        {
            return $"http://openweathermap.org/img/w/{icon}.png";
        }
    }
}

