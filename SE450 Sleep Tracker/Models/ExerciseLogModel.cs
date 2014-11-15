using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SE450Database;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SE450_Sleep_Tracker.Models
{
    [Table("Exr_Exercise")]
    public class ExerciseLogModel
    {
        [Key]
        public int ID { get; set; }

        //[System.ComponentModel.DataAnnotations.Schema.ForeignKey()]
        public string UserID { get; set; }

        public ExerciseTypeModel Type { get; set; }

        public ExerciseIntensityModel Intensity { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public ExerciseLogModel() { }

        public ExerciseLogModel(Exr_Exercise exercise)
        {
            ID = exercise.Exr_ID;
            UserID = exercise.Exr_aur_id;
            
            string connectionString = ConfigurationManager.ConnectionStrings["LinqConnection"].ConnectionString;
            using (var db = new SleepMonitor(connectionString))
            {
                var its = db.Exi_ExerciseIntensity.FirstOrDefault(it => it.Exi_id == exercise.Exr_exi_ID);
                Intensity = new ExerciseIntensityModel(its);

                var tp = db.Ext_ExerciseTypes.FirstOrDefault(ty => ty.Ext_ID == exercise.Exr_ext_id);

                Type = new ExerciseTypeModel
                {
                    CaloriesPerHour = tp.Ext_calories_per_hour,
                    ID = tp.Ext_ID,
                    Intensity = this.Intensity,
                    Name = tp.Ext_name
                };
            }
        }

        /*public Exr_Exercise ToDbObject() 
        {
            return new Exr_Exercise
            {
                Exr_aur_id = UserID,
                Exr_end = End,
                Exr_exi_ID = Intensity.ID,
                Exr_ext_id = Type.ID,
                Exr_ID = ID,
                Exr_start = Start,
                Ext_ExerciseTypes = Type.ToDbObject(),
                Exi_ExerciseIntensity = Intensity.ToDbObject()
            };
        }*/
    }
}