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
using HolidayOutClient.Data;

namespace HolidayOutClient
{
    /// <summary>
    /// Interaktionslogik für BookRoom.xaml
    /// </summary>
    public partial class BookRoom : Window
    {
        private Guest g;
        private Room r;
        private DB db = null;
       

        public BookRoom(Guest selectedItem1, Room selectedItem2)
        {
            InitializeComponent();
            db = new DB();
            this.g = selectedItem1;
            this.r = selectedItem2;
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gast " + g + " soll wirklich im Zimmer " + r + " residieren ?");
            db.InsertStay(g, r, von.SelectedDate, bis.SelectedDate);
            MessageBox.Show("Erfolgreich gebucht");

        }
    }
}
