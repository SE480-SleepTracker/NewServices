//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SE450Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class ctr_ConcentrationLog
    {
        public int ctr_id { get; set; }
        public System.DateTime ctr_logDate { get; set; }
        public string ctr_aur_id { get; set; }
        public short ctr_concentrationLevels { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
