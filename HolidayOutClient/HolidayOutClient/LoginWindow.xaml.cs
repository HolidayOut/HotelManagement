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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        DB db;
        Account temp;

        private static int ID_ADMIN = 1;
        private static int ID_RECEPTIONIST = 3;
        private static int ID_COOK = 4;
        private static int ID_BARKEEPER = 5;

        public LoginWindow()
        {
            InitializeComponent();
            db = new DB();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            /*CookWindow c = new CookWindow();
            c.Show();*/


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
                    try
                    {
                        temp = db.GetAccountByUsername(txtUsername.Text, passwordBox.Password);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    }
                }

                if (temp == null)
                    lblMsg.Content = "Invalid Login ! Check Username or Password ...";
                else
                {
                    Role r = db.GetRoleByUsername(temp.username);
                    if (temp.role_id== ID_ADMIN)
                    {
                        AdminWindow aw = new AdminWindow(temp.username, r);
                        aw.Show();

                    }
                    else if (temp.role_id == ID_COOK)
                    {
                        CookWindow cw = new CookWindow();
                        cw.Show();
                    }
                    else if (temp.role_id == ID_RECEPTIONIST)
                    {
                        ReceptionistWindow rw = new ReceptionistWindow(temp, r);
                        rw.Show();

                    }
                    else if (temp.role_id == ID_BARKEEPER)
                    {
                        BarKeeperWindow bkw = new BarKeeperWindow();
                        bkw.Show();

                    }
                lblMsg.Content = "Success !";

                }
            }
           
            }
        }
    

