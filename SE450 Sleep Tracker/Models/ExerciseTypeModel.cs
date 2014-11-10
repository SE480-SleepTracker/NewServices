using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SE450Database;

namespace SE450_Sleep_Tracker.Models
{
    public class ExerciseTypeModel
    {
        public int ID { get; set; }

        public ExerciseIntensityModel Intensity { get; set; }

        public double CaloriesPerHour { get; set; }

        public string Name { get; set; }

        public ExerciseTypeModel() {}

        public ExerciseTypeModel(Ext_ExerciseTypes type)
        {
            CaloriesPerHour = type.Ext_calories_per_hour;
            ID = type.Ext_ID;
            Name = type.Ext_name;

            Exi_ExerciseIntensity its;
            using (var db = DataCurator.GetConnection())
            {
                its = db.Exi_ExerciseIntensity.FirstOrDefault(i => i.Exi_id == type.Ext_exi_intensity);
            }
            Intensity = new ExerciseIntensityModel(its);
        }

        public Ext_ExerciseTypes ToDbObject()
        {
            return new Ext_ExerciseTypes
            {
                Ext_calories_per_hour = CaloriesPerHour,
                Ext_exi_intensity = Intensity.ID,
                Ext_ID = ID,
                Ext_name = Name
            };
        }
    }
}