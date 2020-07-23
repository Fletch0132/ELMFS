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
        public Trending()
        {
            InitializeComponent();
        }

        //SAME ISSUE FOR ALL DISPLAYS
        //Tried adding any relevent datasource reference, tried with InitializeComponent - didn't work, thought to try outside of there
        //and use a button to populate but no matter what "DataSource" won't be accepted. Tutorial's online show that DataSource should appear
        //like predictive text (such as Messagebox. - and then the option"Show" appears) but doesn't for me. 
        //Tried other ways of populating the listbox such as lstTrending.Items.Add(tweetHashtags) but It only displays the filepath of the list within the project
        //Although this won't be marked even as an attempt - if you have time - I would love to know how this works/best way to do it as this has bugged me for over a week now
        //but I have other coursework that has been delayed due to me spending so much time here.
        /*private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            TweetHashtags tweetHashtags = new TweetHashtags();
            lstTrending.DataSource = 
        }*/

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            //Exit
            this.Close();
        }
    }
}
