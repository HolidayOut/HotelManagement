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
using System.Windows.Shapes;

namespace HolidayOutClient
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        DB db;
        Account temp;

        private static int ID_ADMIN = 1;
        private static int ID_GUEST = 2;
        private static int ID_RECEPTIONIST = 3;

        public LoginWindow()
        {
            InitializeComponent();
            db = new DB();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "")
                lblEmptyUsername.Content = "Please enter a value !";
            else
            {
                lblEmptyUsername.Content = "";
                if (passwordBox.Password == "")
                    lblEmptyPassword.Content = "Please enter a value !";
                else
                {
                    lblEmptyPassword.Content = "";
                    temp = db.GetAccountByUsername(txtUsername.Text, passwordBox.Password);
                }
            }

            if (temp == null)
                lblMsg.Content = "Invalid Login ! Check Username or Password ...";
            else
            {                 
                Role r = db.GetRoleByUsername(txtUsername.Text);
                if(r.ID_Role == ID_ADMIN)
                {
                    AdminWindow aw = new AdminWindow(txtUsername.Text, r);
                    aw.Show();
                    this.Close();
                }
                else if(r.ID_Role == ID_GUEST)
                {

                }
                else if(r.ID_Role == ID_RECEPTIONIST)
                {
                    //ReceptionistWindow rw = new ReceptionistWindow(txtUsername.Text, r);
                    //rw.Show();
                    this.Close();
                }
                lblMsg.Content = "Success !";

                MainWindow mw = new MainWindow(txtUsername.Text);
                mw.Show();
                this.Close();
            }
        }
    }
}
