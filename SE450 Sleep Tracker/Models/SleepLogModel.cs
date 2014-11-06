using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE450_Sleep_Tracker.Models
{
    public class SleepLogModel
    {
        public int ID
        {
            get;
            set;
        }

        public UserModel AssociatedUser
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
    }
}