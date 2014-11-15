using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using SE450Database;

namespace SE450_Sleep_Tracker.Models
{
    public class ExerciseTypeModel
    {
        public int ID { get; set; }

        public ExerciseIntensityModel Intensity { get; set; }

        public double CaloriesPerHour { get; set; }

        public string Name { get; set; }
    }
}