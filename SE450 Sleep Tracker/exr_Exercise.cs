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
    
    public partial class exr_Exercise
    {
        public int exr_ID { get; set; }
        public string exr_aur_id { get; set; }
        public int exr_exi_ID { get; set; }
        public System.DateTime exr_start { get; set; }
        public System.DateTime exr_end { get; set; }
        public int exr_ext_id { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual exi_ExerciseIntensity exi_ExerciseIntensity { get; set; }
        public virtual ext_ExerciseTypes ext_ExerciseTypes { get; set; }
    }
}