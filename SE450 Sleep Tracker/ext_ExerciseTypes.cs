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
    
    public partial class ext_ExerciseTypes
    {
        public ext_ExerciseTypes()
        {
            this.exr_Exercise = new HashSet<exr_Exercise>();
        }
    
        public int ext_ID { get; set; }
        public int ext_exi_intensity { get; set; }
        public double ext_calories_per_hour { get; set; }
        public string ext_name { get; set; }
    
        public virtual ICollection<exr_Exercise> exr_Exercise { get; set; }
    }
}
