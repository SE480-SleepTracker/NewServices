using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE450_Sleep_Tracker.Models
{
    public class ExerciseTypeModel
    {
        public int ID { get; set; }

        public ExerciseIntensityModel Intensity { get; set; }

        public double CaloriesPerHour { get; set; }

        /// <summary>
        /// Get or set the name of the exercise type
        /// </summary>
        public string Name { get; set; }
    }
}