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
    /// Interaction logic for EditRoomWindow.xaml
    /// </summary>
    public partial class EditRoomWindow : Window
    {
        private DB db = null;
        private Room updateRoom = null;
        private int RoomIDToUpdate;
        public EditRoomWindow(int RoomID)
        {
            RoomIDToUpdate = RoomID;
            db = new DB();
            InitializeComponent();
            updateRoom = db.getRoomByID(RoomID);
            txtRoomNr.Text = updateRoom.id + "";
            txtRoomsize.Text = updateRoom.roomsize + "";
            txtRoomprice.Text = updateRoom.roomprize + "";
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Room r = new Room();
                r.id = Int32.Parse(txtRoomNr.Text);
                r.roomsize = Int32.Parse(txtRoomsize.Text);
                r.roomprize = Int32.Parse(txtRoomprice.Text);
                db.updateRoom(RoomIDToUpdate, r);
                this.Close();
            }
            catch (Exception ex)
            {
                lblMessage.Content = ex.Message;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
