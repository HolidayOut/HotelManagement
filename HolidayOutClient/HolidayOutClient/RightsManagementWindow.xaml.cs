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
            if(listViewPermissionsOfRole.Items.CurrentItem != null)
            {
                listViewPermissionsOfRole.Items.Clear();
                foreach(Permission p in db.GetAllPermissionsByRole(int.Parse(listViewRoles.SelectedItem.ToString())))
                {
                    listViewPermissionsOfRole.Items.Add(p);
                }
            }
            
        }


        private void btnAddRole_Click(object sender, RoutedEventArgs e)
        {
            AddRoleWindow arw = new AddRoleWindow();
            arw.Show();
        }

        private void btnRemoveRole_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.removeRole(int.Parse(listViewRoles.SelectedItem.ToString()));
                
            }
            catch(Exception ex)
            {
                lblMessage.Content = "Role cannot be deleted, there is an account using this role.";
            }
            refresh();

        }

        private void refresh()
        {
            listViewRoles.Items.Clear();
            foreach (Role r in db.GetAllRoles())
            {
                listViewRoles.Items.Add(r);
            }
        }

        private void btnAddPermissionToRole_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemovePermissionFromRole_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
