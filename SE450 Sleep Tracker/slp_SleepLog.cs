//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SE450_Sleep_Tracker
{
    using System;
    using System.Collections.Generic;
    
    public partial class slp_SleepLog
    {
        public int slp_ID { get; set; }
        public string slp_aur_id { get; set; }
        public System.DateTime slp_date { get; set; }
        public Nullable<System.TimeSpan> slp_TimeToSleepUserLogged { get; set; }
        public System.TimeSpan slp_TimeToBed { get; set; }
        public Nullable<short> slp_SleepQuality { get; set; }
        public Nullable<short> slp_FatigueLevel { get; set; }
    
        public virtual awk_NighttimeAwakenings awk_NighttimeAwakenings { get; set; }
    }
}
