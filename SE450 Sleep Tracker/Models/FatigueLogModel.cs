using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SE450_Sleep_Tracker.Models
{
    public class FatigueLogModel
    {
        public int ID { get; set; }

        [Range(1, 10)]
        [Required]
        public short Level { get; set; }

        [Required]
        public DateTime LogTime { get; set; }

        // TODO: foreign key
        public string UserID { get; set; }
    }
}