﻿using HolidayOutClient.Data;
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
        public ReceptionistWindow(string username, Role Rolle)
        {
           
            lblUsernameText.Content = username;
            InitializeComponent();
        }

        private void btnManageRooms_Click(object sender, RoutedEventArgs e)
        {
            infoLabel.Content = "Current Rooms: ";
            List<Room> rooms = new List<Room>();
            rooms = db.getAllRooms();
        }
    }
}
