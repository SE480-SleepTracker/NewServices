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
    
    public partial class gsr_GlobalSuggestions
    {
        public gsr_GlobalSuggestions()
        {
            this.rwd_Rewards = new HashSet<rwd_Rewards>();
        }
    
        public int gsr_id { get; set; }
        public string gsr_RewardName { get; set; }
        public int gsr_CheckMarksNeeded { get; set; }
    
        public virtual ICollection<rwd_Rewards> rwd_Rewards { get; set; }
    }
}
