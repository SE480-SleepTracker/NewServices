using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SE450_Sleep_Tracker.Models
{
    /// <summary>
    /// Log of an emotional state
    /// </summary>
    public class EmotionLogModel
    {
        /// <summary>
        /// Get or set the ID
        /// </summary>
        [Key]
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Get or set the date and time of this log
        /// </summary>
        [Required]
        public DateTime LogTime { get; set; }

        /// <summary>
        /// Get or set the user associated with this log
        /// </summary>
        [Required]
        public string UserID { get; set; }

        /// <summary>
        /// Get or set the emotion associated with this
        /// </summary>
        [Required]
        public PredefinedEmotionModel PredefinedEmotion { get; set; }

        /// <summary>
        /// Get or set the intensity of the emotion
        /// </summary>
        [Required]
        [Range(1, 10)]
        public short Intensity { get; set; }

        /// <summary>
        /// Get or set the triggering event
        /// </summary>
        [Required]
        public string Trigger { get; set; }
    }
}