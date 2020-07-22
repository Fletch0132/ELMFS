//Author: Fletcher Thomas Moore
//Description: Handles any URL within either type of Email message, writing to a quarantine list and returning '<URL Quarantined>'. Connected to Email.cs
//Start Date: 29/06/2020
//End Date: 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELMFS.TypeEmail
{
    class EmailQuarantine
    {
        //Quarantine List 
        private List<string> Quarantine = new List<string>();

        public List<string> GetQuarantineList()
        {
            return Quarantine;
        }

        internal void Add(string url)
        {
            Quarantine.Add()
        }

        internal static bool Contains(string url)
        {
            throw new NotImplementedException();
        }
    }
}
