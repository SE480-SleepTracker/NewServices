using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SE450Database;
using System.Configuration;

namespace SE450_Sleep_Tracker.Models
{
    public class DataCurator
    {
        private static readonly string connectionString;

        static DataCurator()
        {
            connectionString = ConfigurationManager.ConnectionStrings["LinqConnection"].ConnectionString;
        }

        public static SleepMonitor GetConnection()
        {
            return new SleepMonitor(connectionString);
        }
    }
}