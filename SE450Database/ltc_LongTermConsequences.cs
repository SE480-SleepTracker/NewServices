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
    
    public partial class ltc_LongTermConsequences
    {
        public int ltc_order { get; set; }
        public int ltc_chn_id { get; set; }
        public string ltc_Consequence { get; set; }
    
        public virtual chn_ChainAnalysis chn_ChainAnalysis { get; set; }
    }
}
