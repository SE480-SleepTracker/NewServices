using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SE450_Sleep_Tracker.Models
{
    /// <summary>
    /// This is the primary model of the system - a sleep log
    /// </summary>
    public class SleepLogModel
    {
        /// <summary>
        /// Get or set the ID (primary key) of this log
        /// </summary>
        [Key]
        [Required]
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set the ID of the user that this is associated with
        /// </summary>
        [Required]
        public string UserID
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set the date of this log
        /// </summary>
        [Required]
        public DateTime Date
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set the time that the user believes they fell asleep
        /// </summary>
        /// 
        /// <remarks>
        /// Specifically NOT required because the user can start with a partial log the night before. Presumably they'd fill this out in the morning.
        /// </remarks>
        public DateTime? TimeToSleepUserLogged
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set the time that the user went to bed
        /// </summary>
        public DateTime TimeToBed
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set the user's fatigue level upon awakening
        /// </summary>
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
        [Range(1, 10)]
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