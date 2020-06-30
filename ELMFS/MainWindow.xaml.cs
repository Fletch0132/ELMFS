//Author: Fletcher Thomas Moore
//Description: Deals with the user input, validation and other functions/operations involving the user interface
//Start Date: 29/06/2020
//End Date: 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
                if ((txtHeader.Text.Substring(0, 1) == "S") || (txtHeader.Text.Substring(0, 1) == "s"))
                {
                    txtSCC.IsEnabled = false;
                    txtNOI.IsEnabled = false;
                }
                else if ((txtHeader.Text.Substring(0, 1) == "E") || (txtHeader.Text.Substring(0, 1) == "e"))
                {
                    txtSCC.IsEnabled = true;
                    txtNOI.IsEnabled = true;
                }
                else if ((txtHeader.Text.Substring(0, 1) == "T") || (txtHeader.Text.Substring(0, 1) == "t"))
                {
                    txtSCC.IsEnabled = false;
                    txtNOI.IsEnabled = false;
                }
                else if ((txtHeader.Text == "") || (txtHeader.Text.Substring(0, 1) == ""))
                {
                    txtSCC.IsEnabled = false;
                    txtNOI.IsEnabled = false;
                }
                else
                {
                    txtSCC.IsEnabled = false;
                    txtNOI.IsEnabled = false;
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                return;
            }
        }
    }
}
