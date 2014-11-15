using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public string UserID { get; set; }

        public ExerciseTypeModel Type { get; set; }

        public ExerciseIntensityModel Intensity { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}