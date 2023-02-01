using System;
using System.IO;
using SQLite;
using WeatherReport.Core.Interfaces;
using WeatherReportShared.Utils;

namespace WeatherReport.Sqlite
{
    public class SQLConnection : ISqLiteConnectionFactory
    {
        readonly string Filename = "weather.db";
        public void GetConnection()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = Path.Combine(path, Filename);
            Constants.DBConnection = new SQLiteConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        }
    }
}

