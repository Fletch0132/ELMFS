//Author: Fletcher Thomas Moore
//Description: Handles the Email type Messages and connects to the MainWindow.xaml.cs, EmailQuarantine.cs and EmailSIR.cs
//Start Date: 29/06/2020
//End Date: 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace ELMFS.TypeEmail
{
    class Email
    {
        #region Sender
        public static bool EmailSender(string mainSender)
        {
            //validate email using Regex
            //Regular Expression Defined - Email Address layout
            Regex rxEmail = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            //Validate
            Match matchEmail = rxEmail.Match(mainSender);

            //Handle email - correct or incorrect
            if (matchEmail.Success)
            {
                return true;
            }
            //Handle duplicates -- else if ((matchEmail.Success) && ()
            else
            {
                return false;
                
            }
        }
        #endregion


        #region Subject
        public static bool EmailSubject(string mainSubject, bool tempNOI)
        {
            //Temp Var
            DateTime date;
            //Remove whitespace
            string emailDate = mainSubject.Replace(" ", "");
            //Focus on SIR
            string emailSIR = mainSubject.Substring(0, 3).ToUpper();
            //Focus on date
            emailDate = emailDate.Substring(3,8);

            //Validate date format
            bool dateValid = DateTime.TryParseExact(emailDate, "dd/MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

            //determine type of subject - normal or SIR
            //false = standard
            if (tempNOI == false)
            {
                //Must not exceed 20 char
                if(mainSubject.Length > 20)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if(tempNOI == true)
            {
                if(mainSubject.Length > 20)
                {
                    return false;
                }
                else if (emailSIR != "SIR")
                {
                    return false;
                }
                else if (dateValid == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion


        #region Sports Centre Code
        public static bool EmailSCC(string mainSCC, bool tempNOI)
        {
            //Regex declared for SCC: 11-111-11
            Regex rxSCC = new Regex(@"^\d{2}-\d{3}-\d{2}$");

            //Validate
            Match matchSCC = rxSCC.Match(mainSCC);

            if (tempNOI == false)
            {
                return false;
            }
            else if(matchSCC.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
