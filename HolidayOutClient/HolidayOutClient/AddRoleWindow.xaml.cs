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
    /// Interaction logic for AddRoleWindow.xaml
    /// </summary>
    public partial class AddRoleWindow : Window
    {
        DB db = null;
        public AddRoleWindow()
        {
            db = new DB();
            InitializeComponent();
        }

        private void btnAddRole_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.addRole("Test");
            }
            catch(Exception ex)
            {
                lblMessage.Content = "Error: " + ex.Message;
            }
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
