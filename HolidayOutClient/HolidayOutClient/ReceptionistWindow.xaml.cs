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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HolidayOutClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ReceptionistWindow : Window
    {
        DB db = null;
        public ReceptionistWindow(Account acc, Role Rolle)
        {
            InitializeComponent();
            db = new DB();
            lblUsernameText.Content = acc.username;
            lblRoleText.Content = Rolle.name;
 
            listViewRooms.ItemsSource = db.getAllRooms();
            listViewGuests.ItemsSource = db.getAllGuests();
            foreach(Guest g in db.getAllGuests())
            {
                MessageBox.Show(g.username + ", " + g.name);
            }

        }

        private void btnAddGuest_Click(object sender, RoutedEventArgs e)
        {
            AddGuestWindow agw = new AddGuestWindow(this.listViewGuests);
            agw.Show();
            
        }

        private void btnBookRoom_Click(object sender, RoutedEventArgs e)
        {
            BookRoom br = new BookRoom((Guest)this.listViewGuests.SelectedItem, (Room)this.listViewRooms.SelectedItem);
            br.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Stays s = new Stays();
            s.Show();
        }
    }
}
