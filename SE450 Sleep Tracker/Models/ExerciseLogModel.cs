using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SE450_Sleep_Tracker.Models
{
    /// <summary>
    /// Model of an exercise log
    /// </summary>
    public class ExerciseLogModel
    {
        /// <summary>
        /// Get or set the key
        /// </summary>
        [Key]
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Get or set the ID of the user that this is associated with
        /// </summary>
        [Required]
        public string UserID { get; set; }

        /// <summary>
        /// Get or set which type of exercise this is
        /// </summary>
        [Required]
        public ExerciseTypeModel Type { get; set; }

        /// <summary>
        /// Get or set the intensity of this instance. It's possible I'll remove this.
        /// </summary>
        public ExerciseIntensityModel Intensity { get; set; }

        /// <summary>
        /// Get or set the time that the user started working out
        /// </summary>
        [Required]
        public DateTime Start { get; set; }

        /// <summary>
        /// Get or set the time that the user finished working out
        /// </summary>
        [Required]
        public DateTime End { get; set; }
    }
}