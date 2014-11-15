using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SE450_Sleep_Tracker.Models
{
    /// <summary>
    /// Model of emotions - e.g. anger, fear, etc. The user can select from one of them for a log.
    /// </summary>
    public class PredefinedEmotionModel
    {
        /// <summary>
        /// Get or set the ID (primary key) of this log
        /// </summary>
        [Key]
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Get or set the name of the emotion
        /// </summary>
        [Required]
        public string Emotion { get; set; }
    }
}