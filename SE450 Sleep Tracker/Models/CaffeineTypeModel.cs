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
        /// <summary>
        /// Get or set the ID (primary key)
        /// </summary>
        [Key]
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Get or set the amount of caffeine, in milligrams, per serving. A serving might be, for example, a single 12-oz cans of Coke.
        /// </summary>
        [Required]
        public double CaffeineAmount { get; set; }

        /// <summary>
        /// Get the product type (e.g. Coke, Pepsi, etc.)
        /// </summary>
        [Required]
        public ProductModel Product { get; set; }

        /// <summary>
        /// Get or set the size of this product. Each caffeine product may come in several sizes. For example, Coke can come in 12-oz cans, larger individual plastic bottles, etc.
        /// </summary>
        [Required]
        public double Size { get; set; }
    }
}