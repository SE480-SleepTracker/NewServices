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
    
    public partial class gft_GoalsForTomorrow
    {
        public int gft_order { get; set; }
        public int gft_chn_id { get; set; }
        public string gft_Goal { get; set; }
    
        public virtual chn_ChainAnalysis chn_ChainAnalysis { get; set; }
    }
}
