using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SE450_Sleep_Tracker.Models
{
    /// <summary>
    /// A type of caffeinated product (Coke, Pepsi, etc.)
    /// </summary>
    /// 
    /// <remarks>
    /// Architecturally, this exists to account for the fact that the same product may exist in several sizes. For example, Coke might exist in 12-oz cans, larger individual
    /// plastic bottles, etc., but all of them are still Coke. If we had a table like
    /// 
    /// id  name    size    caffeineContent
    /// 1   coke    12      100
    /// 2   coke    16      125
    /// ...
    /// this would obviously NOT be in 3rd normal form. This would lead to a lot of redundant data plus a potential maintenance/data consistency nightmare.
    /// </remarks>
    public class ProductModel
    {
        /// <summary>
        /// Get or set the ID (primary key) of this record
        /// </summary>
        [Key]
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Get or set the product name
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}