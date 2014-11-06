using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SE450Database;

namespace SE450_Sleep_Tracker.Models
{
    public class ChainAnalysisModel
    {
        public ChainAnalysisModel(Chn_ChainAnalysis analysis)
        {
            this.ID = analysis.Chn_ID;
            // TODO: finish
        }

        public Chn_ChainAnalysis ToDBObject()
        {
            Chn_ChainAnalysis analysis = new Chn_ChainAnalysis();
            //analysis.Tht_Thought.AddRange(this.Thoughts.Select(new Tht_Thought() { Tht_Thought1 = );
            //analysis.Usr_User = this.AssociatedUser;
            //analysis.Vul_Vulnerability.AddRange(this.)

            int order = 0;
            foreach (string vulnerability in Vulnerabilities)
            {
                Vul_Vulnerability vul = new Vul_Vulnerability()
                {
                    Vul_chn_id = this.ID,
                    Vul_Vulnerability1 = vulnerability,
                    Vul_order = order
                };

                analysis.Vul_Vulnerability.Add(vul);

                order++;
            }
            // TODO: writed
            return analysis;
        }

        #region Chain Analysis Object
        public int ID
        {
            get;
            set;
        }

        public UserModel AssociatedUser
        {
            get;
            set;
        }

        public String ProblemBehavior
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