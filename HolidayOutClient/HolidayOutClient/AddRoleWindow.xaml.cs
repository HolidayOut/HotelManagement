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
        RightsManagementWindow rmw = null;
        public AddRoleWindow(RightsManagementWindow _rmw)
        {
            db = new DB();
            InitializeComponent();
            rmw = _rmw;
        }

        private void btnAddRole_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(txtRoleName.Text != "")
                {
                    db.addRole(txtRoleName.Text);
                    rmw.refresh();
                    this.Close();
                }
                else
                {
                    lblMessage.Content = "Error: No input for Rolename";
                } 
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
