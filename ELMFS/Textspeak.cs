using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace ELMFS
{
    class Textspeak
    {
        #region TextSpeak
        //takes the input message and determines if there is textspeak, if so, converts into meaning
        public static string TextSpeak(string mainMessage)
        {
            string message = mainMessage;

            //open textspeak file and store
            Dictionary<string, string> textwords = File.ReadLines(@"D:\University\Year 3\SoftwareEngineering\textwords.csv").Select(x => x.Split(',')).ToDictionary(x => x[0], x => x[1]);

            //Continue to loop through the textwords.csv file
            foreach (var abb in textwords)
            {
                string format = string.Format(@"\b{0}\b", Regex.Escape(abb.Key.ToLower()));
                string expandAbb = abb.Key + " <" + abb.Value + "> ";

                message = Regex.Replace(message, format, expandAbb, RegexOptions.IgnoreCase);
            }

            System.Windows.MessageBox.Show(message);
            return message;
        }
        #endregion
    }
}
