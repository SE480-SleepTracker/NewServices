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
    /// <summary>
    /// Model of a chain analysis
    /// </summary>
    public class ChainAnalysisModel
    {
        #region Chain Analysis Object
        /// <summary>
        /// Get or set the ID (primary key)
        /// </summary>
        [Key]
        [Required]
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set the ID of the user that this is associated with
        /// </summary>
        [Required]
        public string UserID
        {
            get;
            set;
        }


        public string ProblemBehavior
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