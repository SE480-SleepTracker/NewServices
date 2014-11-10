using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SE450_Sleep_Tracker.Models;

namespace SE450_Sleep_Tracker
{
    public class ManualContext : DbContext
    {
        public ManualContext() : base("name=ContextConnection") { }

        public DbSet<EmotionLogModel> EmotionLogs { get; set; }

        public DbSet<ExerciseLogModel> ExerciseLogs { get; set; }
    }
}