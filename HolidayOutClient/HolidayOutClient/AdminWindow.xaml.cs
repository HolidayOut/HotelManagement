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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private String username = null;
        private DB db = null;
        public AdminWindow(String _username, Role r)
        {
            db = new DB();         
            username = _username;
            InitializeComponent();
            listRooms();
        }

        private void btnManageRolesAndPermissions_Click(object sender, RoutedEventArgs e)
        {
            RightsManagementWindow rmw = new RightsManagementWindow(username);
            rmw.Show();
        }

        private void btnAddRoom_Click(object sender, RoutedEventArgs e)
        {
            AddRoomWindow arw = new AddRoomWindow();
            arw.Show();
        }

        private void btnEditRoom_Click(object sender, RoutedEventArgs e)
        {
            if(listViewRooms.SelectedItem != null)
            {
                EditRoomWindow erw = new EditRoomWindow(Int32.Parse(listViewRooms.SelectedItem.ToString()));
                erw.Show();
            }
            else
            {
                lblMessage.Content = "Choose room to edit!";
            }
            
        }

        private void btnDeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            if (listViewRooms.SelectedItem != null)
            {
                db.deleteRoom(Int32.Parse(listViewRooms.SelectedItem.ToString()));
            }
            else
            {
                lblMessage.Content = "Choose room to delete!";
            }
        }

        private void listRooms()
        {
            listViewRooms.Items.Clear();
            foreach (Room room in db.getAllRooms())
            {
                listViewRooms.Items.Add(room);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            listRooms();
        }
    }
}
