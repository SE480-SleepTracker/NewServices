using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SE450_Sleep_Tracker.Models
{
    /// <summary>
    /// Log of when the user
    /// </summary>
    public class NighttimeAwakeningsModel
    {
        /// <summary>
        /// Get or set the ID (primary key)
        /// </summary>
        [Key]
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Get or set the <see cref="SleepLogModel"/> (sleep log) that this is associated with. Essentially, this is to identify which night's sleep we're referring to.
        /// </summary>
        /// 
        /// <remarks>
        /// Note that this is the reason it's not important that we identify the date (the <see cref="Start"/> and <see cref="End"/> properties are mostly for time). It's also
        /// not at all important to provide the user in this model.
        /// </remarks>
        [Required]
        public SleepLogModel SleepLog { get; set; }

        /// <summary>
        /// Get or set the time that the user first woke up
        /// </summary>
        [Required]
        public DateTime Start { get; set; }

        /// <summary>
        /// Get or set the time that the user fell back to sleep
        /// </summary>
        /// 
        /// <remarks>
        /// This is explicitly NOT required. Users could start a log during the night and finish this in the morning.
        /// </remarks>
        public DateTime End { get; set; }
    }
}