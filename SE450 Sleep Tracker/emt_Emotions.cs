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
    
    public partial class emt_Emotions
    {
        public int emt_order { get; set; }
        public int emt_pre_id { get; set; }
        public int emt_chn_id { get; set; }
    
        public virtual chn_ChainAnalysis chn_ChainAnalysis { get; set; }
        public virtual pre_PredefinedEmotion pre_PredefinedEmotion { get; set; }
    }
}
