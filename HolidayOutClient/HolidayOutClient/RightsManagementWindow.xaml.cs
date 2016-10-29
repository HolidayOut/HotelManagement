using HolidayOutClient.Data;
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

namespace HolidayOutClient
{
    /// <summary>
    /// Interaction logic for RightsManagementWindow.xaml
    /// </summary>
    public partial class RightsManagementWindow : Window
    {
        DB db = null;
        
        public RightsManagementWindow(String _username)
        {
            db = new DB();

            InitializeComponent();
            foreach(Role r in  db.GetAllRoles())
            {
                listViewRoles.Items.Add(r);
            }
            
        }

        private void listViewRoles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}
