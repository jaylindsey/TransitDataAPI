using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransitDataAPI.Models;

namespace TransitDataAPI.Models
{
    public class LoginAuthenticator
    {
        private metrotransit_dbEntities db = new metrotransit_dbEntities();
        private string queryParameter1 = String.Empty;
        private bool parameterFound = false;
        private bool userFound = false;

        private void GetPassKey (IEnumerable<KeyValuePair<string,string>> kvpCollection)
        {
            //iterate over the kvpCollection but we are only interested in the first one
            //if there is at least one entry in the query collection, then read the the first one
            if (kvpCollection.Count() > 0)
            {
                foreach (KeyValuePair<string, string> kvp in kvpCollection)
                {
                    queryParameter1 = kvp.Value;
                    parameterFound = true;
                    break;
                }
            }
        }

        public bool AuthenticateRequest (IEnumerable<KeyValuePair<string, string>> kvpCollection)
        {
            //read the query parameters
            this.GetPassKey(kvpCollection);
            //if parameter is found, then 
            if (parameterFound)
            {
                var queryablePasskey = db.authenticated_users.Where(password => password.user_password.Equals(queryParameter1)).Count();
                if (queryablePasskey > 0)
                {
                    userFound = true;
                }
            }

            return userFound;
        }

    }
}