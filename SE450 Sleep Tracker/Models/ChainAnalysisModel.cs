using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SE450_Sleep_Tracker.Models
{
    public class ChainAnalysisModel
    {
        #region Chain Analysis Object
        [Key]
        public int ID
        {
            get;
            set;
        }

        public string UserID
        {
            get;
            set;
        }

        public String ProblemBehavior
        {
            get;
            set;
        }

        public string Location
        {
            get;
            set;
        }

        public DateTime Time
        {
            get;
            set;
        }
        #endregion

        #region Children
        public List<String> Vulnerabilities
        {
            get;
            set;
        }

        public String BehaviorChain
        {
            get;
            set;
        }


        public List<String> Thoughts
        {
            get;
            set;
        }

        List<String> Behaviors
        {
            get;
            set;
        }

        public List<String> Emotions
        {
            get;
            set;
        }

        public List<String> LongTermConsequences
        {
            get;
            set;
        }

        public List<String> ImmediateConsequences
        {
            get;
            set;
        }


        public List<String> WaysToPrevent
        {
            get;
            set;
        }


        public List<String> LongTermGoals
        {
            get;
            set;
        }


        public List<String> ShortTermGoals
        {
            get;
            set;
        }


        public List<String> GoalsForTomorrow
        {
            get;
            set;
        }
        #endregion
    }
}