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
        public static void SmsSender(string mainSender)
        {
            //Validate input is numeric
            foreach (char c in mainSender)
            {
                if(c<'0' || c >'9')
                {
                    System.Windows.MessageBox.Show("Error: Sender for an SMS message must be numeric.");
                    return;
                }
            }
            
            //validate size - Max 11 digits
            if(Int32.Parse(mainSender) >= 11)
            {
                System.Windows.MessageBox.Show("Error: Sender for SMS message can't be more than 11 digits.");
                return;
            }
        }
    }
}
