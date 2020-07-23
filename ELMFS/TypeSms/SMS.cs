//Author: Fletcher Thomas Moore
//Description: Handles the SMS type messages, including the Textspeak Abbreviations. Connected to MainWindow.xaml.cs 
//Start Date: 29/06/2020
//End Date: 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ELMFS.TypeSms
{
    [DataContract]
    class SMS:Message
    {
        #region Sender
        public static string SmsSender(string mainSender)
        {
            //Validate input is numeric
            int count = 0;
            foreach (char c in mainSender)
            {
                count++;
                if (c < '0' || c > '9')
                {
                    System.Windows.MessageBox.Show("Error: SMS Sender must be numeric.");
                    mainSender = null;
                    return mainSender;
                }
            }

            //validate size - Max 11 digits
            if ((count >= 12) || (count <= 10))
            {
                System.Windows.MessageBox.Show("Error: SMS Sender needs to be 11 digits long.");
                mainSender = null;
                return mainSender;
            }
            else
            {
                return mainSender;
            }
        }
        #endregion

        public SMS(string finalHeader, string finalSender, string finalSubject, string finalMessage) : base(finalHeader, finalSender, finalSubject, finalMessage)
        {
            msgHeader = finalHeader;
            msgSender = finalSender;
            msgSubject = finalSubject;
            msgBody = finalMessage;
        }
    }
}
