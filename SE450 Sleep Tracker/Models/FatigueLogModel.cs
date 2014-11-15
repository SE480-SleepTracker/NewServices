using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SE450_Sleep_Tracker.Models
{
    /// <summary>
    /// Record of fatigue throughout the day
    /// </summary>
    public class FatigueLogModel
    {
        /// <summary>
        /// Get or set the ID (primary key)
        /// </summary>
        [Key]
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Get or set the fatigue level for this log. Scale of 1 - 10 with 1 being "not tired" and 10 being "utterly exhausted."
        /// </summary>
        [Range(1, 10)]
        [Required]
        public short Level { get; set; }

        /// <summary>
        /// Get or set the time we are logging
        /// </summary>
        [Required]
        public DateTime LogTime { get; set; }

        // TODO: foreign key
        /// <summary>
        /// Get or set the ID of the user whose log this is
        /// </summary>
        [Required]
        public string UserID { get; set; }
    }
}