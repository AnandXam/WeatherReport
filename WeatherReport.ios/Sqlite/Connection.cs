using System;
using System.IO;
using SQLite;
using WeatherReport.Core.Interfaces;
using WeatherReportShared.Utils;

namespace WeatherReport.ios.Sqlite
{
    public class SQLiteConnectionFactory : ISqLiteConnectionFactory
    {
        readonly string Filename = "weather.db";

        public void GetConnection()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = Path.Combine(path, Filename);

            Constants.DBConnection = new SQLiteConnection(path, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite);
        }
    }
}

