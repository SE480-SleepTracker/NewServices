using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SE450Database;

namespace SE450_Sleep_Tracker.Models
{
    public class FatigueLogModel
    {
        public int ID { get; set; }

        public short Level { get; set; }

        public DateTime LogTime { get; set; }

        public string UserID { get; set; }

        public FatigueLogModel()
        {
        }

        public FatigueLogModel(Ftg_FatigueLevels obj)
        {
            ID = obj.Ftg_ID;
            Level = obj.Ftg_level;
            LogTime = obj.Ftg_logTime;
            UserID = obj.Ftg_aur_id;
        }
    }
}