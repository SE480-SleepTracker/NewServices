using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SE450Database;

namespace SE450_Sleep_Tracker.Models
{
    public class CaffeineLogModel
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public DateTime LogDateTime { get; set; }

        //[ForeignKey]
        public string UserID { get; set; }

        /// <summary>
        /// Caffeine-containing product consumed
        /// </summary>
        public CaffeineTypeModel CaffeineType { get; set; }

        /// <summary>
        /// Get or set the number of items consumed that are being logged
        /// </summary>
        public int NumberConsumed { get; set; }
    }
}