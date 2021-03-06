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
    
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            this.AspNetUserClaims = new HashSet<AspNetUserClaim>();
            this.AspNetUserLogins = new HashSet<AspNetUserLogin>();
            this.cfn_CaffeineConsumption = new HashSet<cfn_CaffeineConsumption>();
            this.chn_ChainAnalysis = new HashSet<chn_ChainAnalysis>();
            this.ctr_ConcentrationLog = new HashSet<ctr_ConcentrationLog>();
            this.eml_EmotionLog = new HashSet<eml_EmotionLog>();
            this.exr_Exercise = new HashSet<exr_Exercise>();
            this.ftg_FatigueLevels = new HashSet<ftg_FatigueLevels>();
            this.AspNetRoles = new HashSet<AspNetRole>();
        }
    
        public string Id { get; set; }
        public string Hometown { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
    
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<cfn_CaffeineConsumption> cfn_CaffeineConsumption { get; set; }
        public virtual ICollection<chn_ChainAnalysis> chn_ChainAnalysis { get; set; }
        public virtual ICollection<ctr_ConcentrationLog> ctr_ConcentrationLog { get; set; }
        public virtual ICollection<eml_EmotionLog> eml_EmotionLog { get; set; }
        public virtual ICollection<exr_Exercise> exr_Exercise { get; set; }
        public virtual ICollection<ftg_FatigueLevels> ftg_FatigueLevels { get; set; }
        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }
    }
}
