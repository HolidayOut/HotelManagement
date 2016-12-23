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
    /// Interaction logic for AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        DB db;
        public AddEmployeeWindow()
        {
            InitializeComponent();
            db = new DB();
            fillRoles();
        }

        private void fillRoles()
        {
            comboBoxRoles.ItemsSource = db.GetAllRoles();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            if(txtName.Text == "")
            {
                lblMsg.Content = "Please set Name !";
            } else
            {
                lblMsg.Content = "";
                if(txtNachname.Text == "")
                {
                    lblMsg.Content = "Please set Nachname !";
                }
                else
                {
                    lblMsg.Content = "";
                    lblUsernameFinished.Content = db.GenerateUsername(txtName.Text, txtNachname.Text);
                }
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "")
            {
                lblMsg.Content = "Please set Name !";
            }
            else
            {
                lblMsg.Content = "";
                if (txtNachname.Text == "")
                {
                    lblMsg.Content = "Please set Nachname !";
                }
                else
                {
                    lblMsg.Content = "";
                    if ((string)lblUsernameFinished.Content == "")
                    {
                        lblMsg.Content = "Please generate Username first !";
                    }
                    else
                    {
                        lblMsg.Content = "";
                        if (comboBoxRoles.SelectedItem == null)
                        {
                            lblMsg.Content = "Please select Role for Employee !";
                        }
                        else
                        {
                            lblMsg.Content = "";
                            if (birthdate.SelectedDate == null)
                            {
                                lblMsg.Content = "Please select Birthdate !";
                            }
                            else
                            {
                                lblMsg.Content = "";
                                if (comboBoxRoles.SelectedItem == null)
                                {
                                    lblMsg.Content = "Please Select Role !";
                                }
                                else
                                {
                                    lblMsg.Content = "";
                                    Role r = (Role)comboBoxRoles.SelectedItem;
                                    Employee emp = new Employee();

                                    db.InsertAccount(txtName.Text, txtNachname.Text, "Trump2k16", r.id_Role);

                                    emp.name = txtName.Text;
                                    emp.nachname = txtNachname.Text;
                                    emp.birthdate = birthdate.SelectedDate.Value.ToString("dd.mmm.yyyy");
                                    emp.username = (string)lblUsernameFinished.Content;
                                   
                                    db.InsertEmployee(emp);
                                }
                            }
                        }
                    }
                }
            }
         }
        }
    }

