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
using System.Windows.Forms;

namespace ELMFS.Displays
{
    /// <summary>
    /// Interaction logic for Trending.xaml
    /// </summary>
    public partial class Trending : Window
    {
        public Trending(List<string> hTags)
        {
            InitializeComponent();

            foreach (string ht in hTags)
                lstTrending.Items.Add(ht);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            //Exit
            this.Close();
        }
    }
}
