using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SE450_Sleep_Tracker.Models
{
    /// <summary>
    /// Caffeinated products model.
    /// 
    /// Note that there is no controller for this as client apps can't modify it.
    /// </summary>
    public class CaffeineTypeModel
    {
        public int ID { get; set; }

        /// <summary>
        /// Get or set the amount of caffeine, in milligrams, per serving
        /// </summary>
        public double CaffeineAmount { get; set; }

        public ProductModel Product { get; set; }

        /// <summary>
        /// Get or set the size of this product
        /// </summary>
        public double Size { get; set; }
    }
}