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
            //Variables 
            string mainHeader;
            string mainSender;
            string mainSubject;
            string mainSCC;
            string mainNOI;
            string mainMessage;
            string mainType;

            
            #region Header
            //Regular Expression Defined - First character is a letter followed by 9 digits
            Regex rxHeader = new Regex(@"^[a-zA-Z][0-9]{9}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            
            //Store value in temp variable
            string tempHeader = txtHeader.Text;
            
            //Validate
            Match matchHeader = rxHeader.Match(tempHeader);
            
            //Validate and store Header - match input to regex, if matches store, if not then display error
            if (matchHeader.Success)
            {
                mainHeader = txtHeader.Text.ToUpper();
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

            //Decide sender depending on type
            if(mainType == "S")
            {
                //call SMS method
            }
            else if(mainType == "E")
            {
                //call Email Method
            }
            else
            {
                //call Tweet Method
            }
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

            #endregion


            #region Message

            #endregion
        }
    }
}
