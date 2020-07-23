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
using ELMFS.TypeEmail;


namespace ELMFS.Displays
{
    /// <summary>
    /// Interaction logic for SIR.xaml
    /// </summary>
    public partial class SIR : Window
    {public SIR(List<string> eSIR)
        {
            InitializeComponent();

            foreach (string sir in eSIR)
                lstSIR.Items.Add(sir);
        }

        //Exit
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
