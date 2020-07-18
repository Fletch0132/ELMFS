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
using System.Runtime.Serialization;

namespace ELMFS.TypeEmail
{
    [DataContract]
    class Email : Message
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
                System.Windows.MessageBox.Show("Error: Email address is invalid.");
                return false;
            }
        }
        #endregion


        #region Subject
        public static void EmailSubject(string mainSubject, bool tempNOI, string mainHeader)
        {
            if (mainHeader.Substring(0, 1).ToUpper() == "E")
            {
                //Temp Var
                DateTime date;
                //Remove whitespace
                string emailDate = mainSubject.Replace(" ", "");
                //Focus on SIR
                string emailSIR = mainSubject.Substring(0, 3).ToUpper();
                //Focus on date
                emailDate = emailDate.Substring(3, 8);

                //Validate date format
                bool dateValid = DateTime.TryParseExact(emailDate, "dd/MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

                //determine type of subject - normal or SIR
                //false = standard
                if (tempNOI == false)
                {
                    //Must not exceed 20 char
                    if (mainSubject.Length > 20)
                    {
                        System.Windows.MessageBox.Show("Error: Subject for email cannot be greater than 20 characters.");
                        return;
                    }
                }
                else if (tempNOI == true)
                {
                    if (mainSubject.Length > 20)
                    {
                        System.Windows.MessageBox.Show("Error: Subject for email cannot be greater than 20 characters.");
                        return;
                    }
                    else if (emailSIR != "SIR")
                    {
                        System.Windows.MessageBox.Show("Error: Subject for Significant Incident Report emails must start with 'SIR'.");
                        return;
                    }
                    else if (dateValid == false)
                    {
                        System.Windows.MessageBox.Show("Error: Subject for Significant Incident Report emails must contain a valid date after 'SIR' in the format 'dd/mm/yy'");
                        return;
                    }
                }
            }
        }
        #endregion


        #region Sports Centre Code
        public static void EmailSCC(string mainSCC, bool tempNOI, string mainHeader)
        {
            if (mainHeader.Substring(0, 1).ToUpper() == "E")
            {
                //Regex declared for SCC: 11-111-11
                Regex rxSCC = new Regex(@"^\d{2}-\d{3}-\d{2}$");

                //Validate
                Match matchSCC = rxSCC.Match(mainSCC);

                if ((tempNOI == false) && (!matchSCC.Success))
                {
                    System.Windows.MessageBox.Show("Sports Centre Code does not match format: '66-666-99'");
                    return;
                }
            }
        }
        #endregion


        #region SIR List
        //Add subject, Sports Centre Code, and Nature of Incident to list (Only supposed to be SCC and NOI but feel subject 
        //will help with identification if need be
        public static void EmailSIRList(string finalSubject, string finalSCC, string finalNOI)
        {
            //initialize list
            EmailSIR emailSIR = new EmailSIR();

            //add subject, SCC and NOI to list 
            //emailSIR.Add(finalSubject, finalSCC, finalNOI);
        }

        #endregion


        #region Message
        //find hyperlinks, quarantine them
        public static string EmailMessage(string mainMessage)
        {
            //Create URL Regex
            const string hyperlink = (@"^(http|http(s)?://)?([\w-]+\.)+[\w-]+[.com|.in|.org]+(\[\?%&=]*)?");

            //Quarantine List
            EmailQuarantine emailQuarantine = new EmailQuarantine();

            //Search through message for URL(s) and replace
            foreach(Match match in Regex.Matches(mainMessage, hyperlink))
            {
                var url = match.Groups[1].Value;

                //if the url isn#t in list then add it
                if (!EmailQuarantine.Contains(url))
                {
                    emailQuarantine.Add(url);
                }

                //replace url with Quarantine
                mainMessage = mainMessage.Replace(hyperlink.ToString(), "<URL Quarantined>");
            }

            //return
            return mainMessage;
        }
        #endregion

        public Email(string finalHeader, string finalSender, string finalSubject, string finalMessage) : base(finalHeader, finalSender, finalSubject, finalMessage)
        {
            msgHeader = finalHeader;
            msgSender = finalSender;
            msgSubject = finalSubject;
            msgBody = finalMessage;
        }
    }
}
