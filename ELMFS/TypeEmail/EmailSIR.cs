//Author: Fletcher Thomas Moore
//Description: Handles the Significant Incident Reports (SIR), writes the Centre Code and Nature of Incident to a list. Connected to Email.cs
//Start Date: 29/06/2020
//End Date: 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELMFS.TypeEmail
{
    class EmailSIR
    {
        //SIR List 
        private List<string> SIR = new List<string>();

        public List<string> GetSIRList()
        {
            return SIR;
        }

        internal void Add(string finalSubject, string finalSCC, string finalNOI)
        {
            SIR.Add(finalSubject);
            SIR.Add(finalSCC);
            SIR.Add(finalNOI);
        }
    }
}
