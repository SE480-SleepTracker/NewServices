using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SE450_Sleep_Tracker.Models
{
    /// <summary>
    /// The corresponding database is a list of types of exercise (e.g. weights, tennis, etc.)
    /// </summary>
    public class ExerciseTypeModel
    {
        /// <summary>
        /// Get or set the ID (primary key)
        /// </summary>
        [Key]
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Get or set the intensity of this. Example: tennis might be moderate (for doubles) or intense (for singles).
        /// </summary>
        [Required]
        public ExerciseIntensityModel Intensity { get; set; }

        /// <summary>
        /// Get or set the average number of calories per hour
        /// </summary>
        [Required]
        public double CaloriesPerHour { get; set; }

        /// <summary>
        /// Get or set the name of the exercise type
        /// </summary>
        public string Name { get; set; }
    }
}