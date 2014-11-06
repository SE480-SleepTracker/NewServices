using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SE450Database;

namespace SE450_Sleep_Tracker.Models
{
    public class UserModel
    {
        #region Properties
        public int ID
        {
            get;
            set;
        }

        public String FirstName
        {
            get;
            set;
        }

        public String LastName
        {
            get;
            set;
        }

        public String FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }

        public String EmailAddress
        {
            get;
            set;
        }

        public String CellPhone
        {
            get;
            set;
        }

        public String HomePhone
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public UserModel() { }

        public UserModel(Usr_User user)
        {
            this.CellPhone = user.Usr_CellPhone;
            this.EmailAddress = user.Usr_EmailAddress;
            this.FirstName = user.Usr_FirstName;
            this.LastName = user.Usr_LastName;
            this.HomePhone = user.Usr_HomePhone;
            this.ID = user.Usr_ID;
        }
        #endregion

        #region Public Methods
        public static bool TryParse(string s, out UserModel result)
        {
            result = null;

            var parts = s.Split(',');

            if (parts.Length != 6) return false;

            int id;
            if (int.TryParse(parts[0], out id))
            {
                result = new UserModel()
                {
                    FirstName = parts[1],
                    LastName = parts[2],
                    EmailAddress = parts[3],
                    CellPhone = parts[4],
                    HomePhone = parts[5]
                };

                return true;
            }
            else return false;
        }
        #endregion
    }
}