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

namespace ELMFS.TypeEmail
{
    class Email
    {
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

        
    }
}
