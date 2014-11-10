using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE450_Sleep_Tracker.Models
{
    public class NighttimeAwakeningsModel
    {
        public int ID { get; set; }
        public SleepLogModel SleepLog { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}