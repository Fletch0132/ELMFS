using System;
using System.Collections.Generic;
using System.Windows;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;

namespace ELMFS.Displays
{
    /// <summary>
    /// Interaction logic for Messages.xaml
    /// </summary>
    public partial class Messages : Window
    {
        public Messages()
        {
            MainWindow compMess = new MainWindow();
            lstMessages.Items.Add(compMess);
            InitializeComponent();
        }

        

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            //Exit
            this.Close();
        }
    }
}
