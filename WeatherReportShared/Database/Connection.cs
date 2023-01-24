using System;
using WeatherReport.Core.Interfaces;

namespace WeatherReport.Core.Database
{
    public class Connection : ISqLiteConnectionFactory
    {
        public virtual void GetConnection()
        {
        }
    }
}

