using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using SE450Database;

namespace SE450_Sleep_Tracker.Models
{
    public class ExerciseIntensityModel
    {
        public int ID { get; set; }

        public string Intensity { get; set; }

        public ExerciseIntensityModel() { }

        /*public ExerciseIntensityModel(Exi_ExerciseIntensity log)
        {
            ID = log.Exi_id;
            Intensity = log.Exi_intensity;
        }

        public Exi_ExerciseIntensity ToDbObject()
        {
            return new Exi_ExerciseIntensity
            {
                Exi_id = ID,
                Exi_intensity = Intensity
            };
        }*/
    }
}