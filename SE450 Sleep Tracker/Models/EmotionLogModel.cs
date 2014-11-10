using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SE450_Sleep_Tracker.Models
{
    public class EmotionLogModel
    {
        public int ID { get; set; }

        public DateTime LogTime { get; set; }

        public string UserID { get; set; }

        public PredefinedEmotionModel PredefinedEmotion { get; set; }

        [Required]
        [Range(1, 10)]
        public short Intensity { get; set; }

        public string Trigger { get; set; }
    }
}