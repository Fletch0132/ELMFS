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
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using ELMFS.Displays;

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

        #region Clear All
        //Clear everything when called
        public void ClearAll()
        {
            txtHeader.Text = "";
            txtSender.Text = "";
            txtSubject.Text = "";
            txtSCC.Text = "";
            txtNOI.Items.Clear();
            txtMessage.Text = "";
        }
        #endregion

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


        //BUTTONS
        #region Button Add
        //When ADD button clicked by user
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            #region Set-up
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

            //file path
            string filepath = @"D:\University\Year 3\SoftwareEngineering\json\messages.json";

            //if JSON file doesn't exist, create new
            //if (!File.Exists(filepath))
            //{
                //File.WriteAllText(filepath, "messages");
            //}

            #endregion


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
                Email.EmailSubject(mainSubject, tempNOI, mainHeader);
            }

            //store main as final
            finalSubject = mainSubject;



            //store validated variable from Email.cs
            //if (Email.EmailSubject(mainSubject, tempNOI, mainHeader))
            //{
            //finalSubject = mainSubject;
            //}
            //else
            //{
            //return;
            //}

            #endregion


            #region Sports Centre Code
            //Wanted most of this code in the Email.cs but for some reason it continued to miss the "TryParse" line
            
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

                //SIR email, can't be blank, pass to EmailSCC()
                if (tempNOI == true)
                {
                    //if blank - display error
                    if (mainSCC == "")
                    {
                        MessageBox.Show("Error: Email Sports Centre Code cannot be blank.");
                        return;
                    }
                    //if SIR email
                    else if (tempNOI == true)
                    {
                        //if input equals 7 char
                        if (mainSCC.Length == 7)
                        {
                            //variables
                            int mSCC;
                            //take input and test if numeric
                            bool num = int.TryParse(mainSCC, out mSCC);

                            //if numeric store - if not numeric display error
                            if (num)
                            {
                                mainSCC = mSCC.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Error: Sport's Centre Code must be numeric.");
                                return;
                            }
                        }
                        //if less or more than 7 display error
                        else
                        {
                            MessageBox.Show("Error: SCC must by 7 integers long.");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: Sports Centre Code does not match format: '6666699'. System will break the code with '-' when processing");
                        return;
                    }
                    //pass variable to Email.cs class
                    Email.EmailSCC(mainSubject, tempNOI, mainHeader);
                }
            }

            //store validated variable from Email.cs
            finalSCC = mainSCC;
            
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


            #region Write to SIR List
            //pass subject, SCC and NOI to write to SIR List
            //Email.EmailSIRList(finalSubject, finalSCC, finalNOI);
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
                if (mainMessage.Length <= 140)
                {
                    //pass to Textspeak
                    Textspeak.TextSpeak(mainMessage);

                    //final store
                    finalMessage = mainMessage;

                    //Write to JSON
                    //new instance of list
                    List<SMS> sms = new List<SMS>();
                    //add inputs to list
                    sms.Add(new SMS(finalHeader, finalSender, "No Subject", finalMessage));
                    //convert list to array
                    string JSON = JsonConvert.SerializeObject(sms.ToArray());
                    //Add to file
                    File.AppendAllText(filepath, JSON + Environment.NewLine);

                    //confirm
                    MessageBox.Show("Message Added to File");

                    //Clear everything method
                    ClearAll();
                    
                }
                else
                {
                    MessageBox.Show("Error: Message body for SMS must be less than 140 characters.");
                    return;
                }
               
            }
            else if (mainType == "E")
            {
                if (mainMessage.Length <= 1028)
                {
                    //If its not blank Pass to Email.cs
                    Email.EmailMessage(mainMessage);

                    //If SIR email, store SCC and NOI as first 2 lines of main
                    if ((finalSCC != null) && (txtNOI.SelectedIndex != 0))
                    {
                        finalMessage = finalSCC + "\n" + finalNOI + "\n" + mainMessage;
                    }
                    //if standard email, store main 
                    else
                    {
                        finalMessage = mainMessage;
                    }

                    //Write to JSON
                    //new instance of list
                    List<Email> email = new List<Email>();
                    //add inputs to list
                    email.Add(new Email(finalHeader, finalSender, finalSubject, finalMessage));
                    //convert list to array
                    string JSON = JsonConvert.SerializeObject(email.ToArray());
                    //Add to file
                    File.AppendAllText(filepath, JSON + Environment.NewLine);

                    //confirm
                    MessageBox.Show("Message Added to File");

                    //Clear everything method
                    ClearAll();
                }
                else
                {
                    MessageBox.Show("Error: Message body for Email must be less than 1028 characters.");
                    return;
                }
            }
            else if (mainType == "T")
            {
                if (mainMessage.Length <= 140)
                {
                    //If its not blank Pass to Tweet.cs
                    Tweet.TweetMessage(mainMessage);

                    //final store
                    finalMessage = mainMessage;

                    //Write to JSON
                    //new instance of list
                    List<Tweet> tweet = new List<Tweet>();
                    //add inputs to list
                    tweet.Add(new Tweet(finalHeader, finalSender, "No Subject", finalMessage));
                    //convert list to array
                    string JSON = JsonConvert.SerializeObject(tweet.ToArray());
                    //Add to file
                    File.AppendAllText(filepath, JSON + Environment.NewLine);

                    //confirm
                    MessageBox.Show("Message Added to File");

                    //Clear everything method
                    ClearAll();

                }
                else
                {
                    MessageBox.Show("Error: Message body for Tweet must be less than 140 characters.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Error: Something went wrong processing the message.");
                return;
            }
            #endregion

        }



        #endregion

        #region Button SIR
        private void btnSIR_Click(object sender, RoutedEventArgs e)
        {
            //When button clicked change view
            Window SIR = new SIR();
            SIR.Show();
        }
        #endregion

        #region Button Trending
        private void btnTrending_Click(object sender, RoutedEventArgs e)
        {
            //When button clicked change view
            Window Trending = new Trending();
            Trending.Show();
        }
        #endregion

        #region Button Mentions
        private void btnMentions_Click(object sender, RoutedEventArgs e)
        {
            //when button clicked change view
            Window Mentions = new Mentions();
            Mentions.Show();
        }
        #endregion

        #region Button Quarantine
        private void btnQuarantine_Click(object sender, RoutedEventArgs e)
        {
            //When button clicked change view
            Window Quarantine = new Quarantine();
            Quarantine.Show();
        }
        #endregion
    }

}
