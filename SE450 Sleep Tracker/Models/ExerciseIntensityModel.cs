using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SE450_Sleep_Tracker.Models
{
    /// <summary>
    /// Exercise intensity
    /// </summary>
    public class ExerciseIntensityModel
    {
        /// <summary>
        /// Get or set the ID (primary key)
        /// </summary>
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Get or set the intensity of the exercise
        /// </summary>
        [Required]
        [Range(1, 10)]
        public string Intensity { get; set; }
    }
}