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
using System.Windows.Shapes;
using ELMFS.TypeTweet;

namespace ELMFS.Displays
{
    /// <summary>
    /// Interaction logic for Mentions.xaml
    /// </summary>
    public partial class Mentions : Window
    {
        public Mentions(List<string> tMentions)
        {
            InitializeComponent();

            foreach (string men in tMentions)
                lstMentions.Items.Add(men);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            //Exit
            this.Close();
        }
    }
}
