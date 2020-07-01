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
        public static bool SmsSender(string mainSender)
        {
            //Validate input is numeric
            int count = 0;
            foreach (char c in mainSender)
            {
                count++;
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            //validate size - Max 11 digits
            if ((count >= 12) || (count<=10))
            {

                return false;
            }
            else
            {
                return true;
            }


        }
    }
}
