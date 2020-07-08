//Author: Fletcher Thomas Moore
//Description: Handles the SMS type messages, including the Textspeak Abbreviations. Connected to MainWindow.xaml.cs 
//Start Date: 29/06/2020
//End Date: 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELMFS.TypeSms
{
    class SMS
    {
        #region Sender
        public static bool SmsSender(string mainSender)
        {
            //Validate input is numeric
            int count = 0;
            foreach (char c in mainSender)
            {
                count++;
                if (c < '0' || c > '9')
                {
                    System.Windows.MessageBox.Show("Error: SMS Sender must be numeric.");
                    return false;
                }
            }

            //validate size - Max 11 digits
            if ((count >= 12) || (count<=10))
            {
                System.Windows.MessageBox.Show("Error: SMS Sender needs to be 11 digits long.");
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion


        #region Message
        public static bool SMSMessage(string mainMessage)
        {

        }

        #endregion
    }
}
