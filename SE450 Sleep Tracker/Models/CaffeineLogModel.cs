using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SE450_Sleep_Tracker.Models
{
    /// <summary>
    /// Logs of when the user consumed caffeine
    /// </summary>
    public class CaffeineLogModel
    {
        /// <summary>
        /// Get or set the ID (primary key)
        /// </summary>
        [Key]
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Get or set the date or time
        /// </summary>
        [Required]
        public DateTime LogDateTime { get; set; }

        //[ForeignKey]
        /// <summary>
        /// Get or set the user that this is associated with
        /// </summary>
        [Required]
        public string UserID { get; set; }

        /// <summary>
        /// Get or set the caffeine-containing product consumed
        /// </summary>
        [Required]
        public CaffeineTypeModel CaffeineType { get; set; }

        /// <summary>
        /// Get or set the number of items consumed in this "sitting"
        /// </summary>
        /// 
        /// <remarks>
        /// Right now I set 50 as a high upper value limit. This is somewhat arbitrary; it's also probably too high. If they claim to have drank that much it's probably a typo.
        /// </remarks>
        [Required]
        [Range(1, 50)]
        public int NumberConsumed { get; set; }
    }
}