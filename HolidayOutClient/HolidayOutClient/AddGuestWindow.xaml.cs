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
    /// Interaction logic for AddGuestWindow.xaml
    /// </summary>
    public partial class AddGuestWindow : Window
    {
        DB db = null;
        private ListView listViewGuests;

       

        public AddGuestWindow(ListView listViewGuests)
        {
            InitializeComponent();
            this.listViewGuests = listViewGuests;
            db = new DB();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           
            string pw = "Trump2k16";
            int roleID = 2;

            db.InsertAccount(this.txtVorname.Text, this.txtNachname.Text, pw, roleID);
            db.InsertHotelGuest(this.txtVorname.Text, this.txtNachname.Text);
            listViewGuests.ItemsSource = db.getAllGuests();
            

        }
    }
}
