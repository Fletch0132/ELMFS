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
        private bool tempNOI;

        public MainWindow()
        {
            InitializeComponent();
            //Disable Email Related Inputs
            txtSubject.IsEnabled = false;
            txtSCC.IsEnabled = false;
            txtNOI.IsEnabled = false;
        }

        #region HeaderType
        //Determines the message type from the header and what should be displayed
        private void txtHeader_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                //select character and select type from character
                //if the first character is "S" or "s" then email components remain disabled
                if ((txtHeader.Text.Substring(0, 1) == "S") || (txtHeader.Text.Substring(0, 1) == "s"))
                {
                    txtSubject.IsEnabled = false;
                    txtSCC.IsEnabled = false;
                    txtNOI.IsEnabled = false;
                }
                //if the first character is "E" or "e" then email components enabled
                else if ((txtHeader.Text.Substring(0, 1) == "E") || (txtHeader.Text.Substring(0, 1) == "e"))
                {
                    txtSubject.IsEnabled = true;
                    txtSCC.IsEnabled = true;
                    txtNOI.IsEnabled = true;
                }
                //if the first character is "T" or "t" then email components remain disabled
                else if ((txtHeader.Text.Substring(0, 1) == "T") || (txtHeader.Text.Substring(0, 1) == "t"))
                {
                    txtSubject.IsEnabled = false;
                    txtSCC.IsEnabled = false;
                    txtNOI.IsEnabled = false;
                }
                //if the textbox or first character empty then email components remain disabled
                else if ((txtHeader.Text == "") || (txtHeader.Text.Substring(0, 1) == ""))
                {
                    txtSubject.IsEnabled = false;
                    txtSCC.IsEnabled = false;
                    txtNOI.IsEnabled = false;
                }
                //email components remain disabled
                else
                {
                    txtSubject.IsEnabled = false;
                    txtSCC.IsEnabled = false;
                    txtNOI.IsEnabled = false;
                }
            }
            //catch errors
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
        }
        #endregion

        #region Add Button
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
                        return;
                    }
                }
            }
            #endregion


            #region Subject
            //store subject
            mainSubject = txtSubject.Text;

            //determine if there should be input, pass input on for validation, no blank input
            if (mainHeader.Substring(0, 1).ToUpper() == "E")
            {
                //Normal email or SIR
                if (txtNOI.SelectedIndex == 0)
                {
                    //standard email
                    tempNOI = false;
                }
                else
                {
                    //SIR email
                    tempNOI = true;
                }

                //pass variable to Email.cs class
                Email.EmailSubject(mainSubject, tempNOI);
            }
            //If blank, display error
            else if (mainSubject == "")
            {
                MessageBox.Show("Error: Email Subject cannot be blank.");
                return;
            }

            //store validated variable from Email.cs
            if (Email.EmailSubject(mainSubject, tempNOI))
            {
                finalSubject = mainSubject;
            }
            else
            {
                return;
            }

            #endregion


            #region Sports Centre Code
            //Store SCC
            mainSCC = txtSCC.Text;

            //determine if there should be input, pass input on for validation, no blank input
            if (mainHeader.Substring(0, 1).ToUpper() == "E")
            {
                //Normal email or SIR
                if (txtNOI.SelectedIndex == 0)
                {
                    //standard email
                    tempNOI = false;
                }
                else
                {
                    //SIR email
                    tempNOI = true;
                }

                //pass variable to Email.cs class
                Email.EmailSCC(mainSubject, tempNOI);
            }
            //If blank, display error
            else if (mainSCC == "")
            {
                MessageBox.Show("Error: Email Sports Centre Code cannot be blank.");
                return;
            }

            //store validated variable from Email.cs
            if (Email.EmailSCC(mainSubject, tempNOI))
            {
                finalSCC = mainSCC; 
            }
            else
            {
                return;
            }
            #endregion


            #region Nature of Incident
            //store Nature of Incident selection
            mainNOI = txtNOI.SelectedIndex.ToString();

            if ((mainHeader.Substring(0, 1).ToUpper() == "E") && (txtNOI.SelectedIndex <0) && (txtNOI.SelectedIndex >12))
            {
                MessageBox.Show("Error: Email is selected and must have a selection within Nature of Incident - if no incident select 'No Significant Incident'.");
                return;
            }
            else
            {
                finalNOI = mainNOI;
            }

            #endregion


            #region Message
            //store message temp
            mainMessage = txtMessage.Text;

            //Can't be blank
            if (mainMessage == "")
            {
                MessageBox.Show("Error: Message cannot be blank.");
                return;
            }
            //Determine message requirements from type
            else if (mainType == "S")
            {
                //if less than 140 char Pass to SMS.cs
                if (mainMessage.Length < 140)
                {
                    Message.TextSpeak(mainMessage);
                }
                else
                {
                    MessageBox.Show("Error: Message body for SMS muct be less than 140 characters.");
                    return;
                }
               
            }
            else if (mainType == "E")
            {
                //If its not blank Pass to Email.cs
                Email.EmailMessage(mainMessage);
            }
            else if (mainType == "T")
            {
                //If its not blank Pass to Tweet.cs
                Tweet.TweetMessage(mainMessage);
            }
            else
            {
                MessageBox.Show("Error: Something went wrong processing the message.");
                return;
            } 
            #endregion
        }
        #endregion

       
    }
}
