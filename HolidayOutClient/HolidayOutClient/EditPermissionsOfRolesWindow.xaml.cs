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
    /// Interaction logic for EditPermissionsOfRolesWindow.xaml
    /// </summary>
    public partial class EditPermissionsOfRolesWindow : Window
    {
        private DB db = null;
        int ID_Role = 0;
        public EditPermissionsOfRolesWindow(int _ID_Role)
        {
            ID_Role = _ID_Role;
            db = new DB();
            InitializeComponent();
            lblPermissionsOfRole.Content = db.GetRoleByID(ID_Role).Name;
            refreshLists();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(listViewAllPermissions.SelectedItem != null)
            {
                try
                {
                    db.addPermissionToRole(ID_Role, int.Parse(listViewAllPermissions.SelectedItem.ToString()));
                    refreshListViewPermissionsOfRole();
                    lblMessage.Content = "";
                }
                catch(Exception ex)
                {
                    lblMessage.Content = "Error: This is already a Permission of this Role.";
                }
                
            }
            else
            {
                lblMessage.Content = "Error: No Permission to add to Role selected";
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if(listViewPermissionsOfRole.SelectedItem != null)
            {
                db.removePermissionFromRole(ID_Role, int.Parse(listViewPermissionsOfRole.SelectedItem.ToString()));
                refreshListViewPermissionsOfRole();
            }
            else
            {
                lblMessage.Content = "Error: No Permission to remove from Role selected.";
            }

        }

        private void refreshLists()
        {
            refreshListViewAllPermissions();
            refreshListViewPermissionsOfRole();
        }

        private void refreshListViewPermissionsOfRole()
        {
            listViewPermissionsOfRole.Items.Clear();
            foreach (Permission p in db.GetAllPermissionsByRole(ID_Role))
            {
                listViewPermissionsOfRole.Items.Add(p);
            }
        }

        private void refreshListViewAllPermissions()
        {
            listViewAllPermissions.Items.Clear();
            foreach (Permission p in db.getAllPermissions())
            {
                listViewAllPermissions.Items.Add(p);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
