//Author: Fletcher Thomas Moore
//Description: Deals with the user input, validation and other functions/operations involving the user interface
//Start Date: 29/06/2020
//End Date: 
using System;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using ELMFS.TypeEmail;
using ELMFS.TypeSms;
using ELMFS.TypeTweet;

namespace ELMFS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Disable Email Related Inputs
            txtSCC.IsEnabled = false;
            txtNOI.IsEnabled = false;
        }

        //Determines the message type from the header and what should be displayed
        private void txtHeader_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                //select character and select type from character
                //if the first character is "S" or "s" then email components remain disabled
                if ((txtHeader.Text.Substring(0, 1) == "S") || (txtHeader.Text.Substring(0, 1) == "s"))
                {
                    txtSCC.IsEnabled = false;
                    txtNOI.IsEnabled = false;
                }
                //if the first character is "E" or "e" then email components enabled
                else if ((txtHeader.Text.Substring(0, 1) == "E") || (txtHeader.Text.Substring(0, 1) == "e"))
                {
                    txtSCC.IsEnabled = true;
                    txtNOI.IsEnabled = true;
                }
                //if the first character is "T" or "t" then email components remain disabled
                else if ((txtHeader.Text.Substring(0, 1) == "T") || (txtHeader.Text.Substring(0, 1) == "t"))
                {
                    txtSCC.IsEnabled = false;
                    txtNOI.IsEnabled = false;
                }
                //if the textbox or first character empty then email components remain disabled
                else if ((txtHeader.Text == "") || (txtHeader.Text.Substring(0, 1) == ""))
                {
                    txtSCC.IsEnabled = false;
                    txtNOI.IsEnabled = false;
                }
                //email components remain disabled
                else
                {
                    txtSCC.IsEnabled = false;
                    txtNOI.IsEnabled = false;
                }
            }
            //catch errors
            catch(ArgumentOutOfRangeException)
            {
                return;
            }
        }

        //When ADD button clicked by user
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Variables from input
            string mainHeader;
            string mainSender;
            string mainSubject;
            string mainSCC;
            string mainNOI;
            string mainMessage;
            string mainType;

            //Variables after validation
            string finalHeader;
            string finalSender;
            string finalSubject;
            string finalSCC;
            string finalNOI;
            string finalMessage;


            #region Header
            //Regular Expression Defined - First character is a letter followed by 9 digits
            Regex rxHeader = new Regex(@"^[a-zA-Z][0-9]{9}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            
            //Store value in temp variable
            mainHeader = txtHeader.Text;
            
            //Validate
            Match matchHeader = rxHeader.Match(mainHeader);
            
            //Validate and store Header - match input to regex, if matches store, if not then display error
            if (txtHeader.Text == " ")
            {
                MessageBox.Show("Error: Header can not be empty.");
                return;
            }
            else if (matchHeader.Success)
            {
                finalHeader = txtHeader.Text.ToUpper();
            }
            else
            {
                MessageBox.Show("Error: Message Header must start with 'S', 'E', or 'T' followed by 9 digits.");
                return;
            }
            #endregion


            #region Sender
            //store message type
            mainType = txtHeader.Text.Substring(0, 1).ToUpper();
            //Store input
            mainSender = txtSender.Text;

            if (txtSender.Text == "")
            {
                MessageBox.Show("Error: Sender can not be blank");
                return;
            }
            else
            {
                //Decide sender depending on type
                if (mainType == "S")
                {
                    //call SMS method and pass user input
                    SMS.SmsSender(mainSender);

                    if (SMS.SmsSender(mainSender))
                    {
                        //complete
                        finalSender = mainSender;
                    }
                    else
                    {
                        //Error Message
                        MessageBox.Show("Error: SMS Sender must be numeric and 11 digits long.");
                        return;
                    }
                }
                else if (mainType == "E")
                {
                    //call Email Method and pass user input
                    Email.EmailSender(mainSender);

                    if (Email.EmailSender(mainSender))
                    {
                        //complete
                        finalSender = mainSender;
                    }
                    else
                    {
                        //Error message
                        MessageBox.Show("Error: Email Sender format is incorrect. Must be an Email Address format.");
                        return;
                    }
                }
                else
                {
                    //call Tweet Method and pass user input
                    Tweet.TweetSender(mainSender);

                    if (Tweet.TweetSender(mainSender))
                    {
                        //Complete
                        finalSender = mainSender;
                    }
                    else
                    {
                        //Error message
                        MessageBox.Show("Error: Tweet Sender must start with '@' and no longer than 15 characters. ");
                        return;
                    }
                }
            }

            //Store Sender from SMS, Email, or Tweet
            //mainSender = 
            #endregion


            #region Subject
            //store subject
            mainSubject = txtSubject.Text;

            //pass to Email.cs

            #endregion


            #region Sports Centre Code
            //Store SCC
            mainSCC = txtSCC.Text;

            //Pass to Email.cs

            #endregion


            #region Nature of Incident
            //store Nature of Incident selection
            mainNOI = txtNOI.SelectedItem.ToString();
            #endregion


            #region Message
            //Determine message requirements from type
            if (mainType == "S")
            {
                //Pass to SMS.cs
            }
            else if (mainType == "E")
            {
                //Pass to Email.cs
            }
            else
            {
                //Pass to Tweet.cs
            }

            //Store message passed back from SMS, Email, or Tweet
            //mainMessage = 
            #endregion
        }
    }
}
