using System;
using SQLite;

namespace WeatherReport.Core.Model
{
	public class SqliteUserSettingModel
	{
        [PrimaryKey]
        public int Id { get; set; }
        public bool IsDefault { get; set; }
        public double SavedLatitude { get; set; }
        public double SavedLongitude { get; set; }
        public string PlaceName { get; set; }
    }
}

