using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SE450Database;
using System.Configuration;

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

        public CaffeineLogModel(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LinqConnection"].ConnectionString;
            using (var db = new SleepMonitor(connectionString))
            {
                var log = db.Cfn_CaffeineConsumption.FirstOrDefault(lg => lg.Cfn_ID == id);

                // TODO finish
            }

        }

        public CaffeineLogModel(Cfn_CaffeineConsumption cfn)
        {
            ID = cfn.Cfn_ID;
            LogDateTime = cfn.Cfn_DateTime;
            UserID = cfn.Cfn_aur_id;
            NumberConsumed = cfn.Cfn_number;
            CaffeineType = new CaffeineTypeModel(cfn.Cfn_cft_ID);
        }

        public Cfn_CaffeineConsumption ToDbObject()
        {
            return new Cfn_CaffeineConsumption()
            {
                Cfn_aur_id =  UserID,
                Cfn_DateTime = LogDateTime,
                Cfn_ID = ID,
                Cfn_cft_ID = CaffeineType.ID,
                Cfn_number = NumberConsumed
            };
        }
    }
}