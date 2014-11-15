using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SE450Database;

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

        /*public CaffeineTypeModel(int id)
        {
            Cft_CaffeineType item;

            // I'm cheating on product because I'm lazy
            Prd_Product product;

            using (var db = DataCurator.GetConnection())
            {
                item = db.Cft_CaffeineType.FirstOrDefault(lg => lg.Cft_id == id);

                product = db.Prd_Product.FirstOrDefault(prd => prd.Prd_ID == item.Prd_Product);
                // TODO finish
            }

            ID = item.Cft_id;
            CaffeineAmount = item.Cft_amount;
            Size = item.Cft_size;
            Product = new ProductModel
            {
                ID = product.Prd_ID,
                Name = product.Prd_Name
            };
        }*/
    }
}