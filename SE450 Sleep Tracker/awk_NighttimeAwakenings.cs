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
    
    public partial class awk_NighttimeAwakenings
    {
        public int awk_ID { get; set; }
        public System.DateTime awk_start { get; set; }
        public Nullable<System.DateTime> awk_end { get; set; }
        public int awk_slp_ID { get; set; }
    
        public virtual slp_SleepLog slp_SleepLog { get; set; }
    }
}
