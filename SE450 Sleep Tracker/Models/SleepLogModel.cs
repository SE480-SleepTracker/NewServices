using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using SE450Database;

namespace SE450_Sleep_Tracker.Models
{
    public class SleepLogModel
    {
        public int ID
        {
            get;
            set;
        }

        public string UserID
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public DateTime? TimeToSleepUserLogged
        {
            get;
            set;
        }

        public DateTime TimeToBed
        {
            get;
            set;
        }

        public short? FatigueLevel
        {
            get;
            set;
        }

        private ushort? _sleepQuality;

        /// <summary>
        /// Get or set the quality of the user's sleep on a scale of 1 - 10
        /// </summary>
        /// <exception cref="System.ArgumentException">If the value is not between 1 and 10</exception>
        /// <exception cref="System.ArgumentNullException">If the value is set to <c>null</c> after having been set</exception>
        public ushort? SleepQuality
        {
            get { return _sleepQuality; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Cannot be unset once set");
                else if (value < 1 || value > 10)
                    throw new ArgumentException("Value must be between 1 and 10");
                else
                    _sleepQuality = value;
            }
        }

        public SleepLogModel()
        {
        }

        public SleepLogModel(Slp_SleepLog log)
        {
            ID = log.Slp_ID;
            SleepQuality = (ushort?)log.Slp_SleepQuality;
            Date = log.Slp_date;
            FatigueLevel = log.Slp_FatigueLevel;
            TimeToBed = new DateTime(log.Slp_TimeToBed.Ticks); // TODO Wrong
            TimeToSleepUserLogged = new DateTime(log.Slp_TimeToSleepUserLogged.Value.Ticks); // TODO Wrong
            UserID = log.Slp_aur_id;

        }

        public Slp_SleepLog ToDBObject()
        {
            return new Slp_SleepLog
            {
                Slp_aur_id = this.UserID,
                Slp_date = this.Date,
                Slp_FatigueLevel = this.FatigueLevel,
                Slp_SleepQuality = (short?)this.SleepQuality,
                Slp_ID = ID,
                Slp_TimeToBed = new TimeSpan(TimeToBed.Hour, TimeToBed.Minute, TimeToBed.Second),
                Slp_TimeToSleepUserLogged = this.TimeToSleepUserLogged == null ? null : (TimeSpan?)new TimeSpan(TimeToSleepUserLogged.Value.Hour, TimeToSleepUserLogged.Value.Minute, TimeToSleepUserLogged.Value.Second)
            };
        }
    }
}