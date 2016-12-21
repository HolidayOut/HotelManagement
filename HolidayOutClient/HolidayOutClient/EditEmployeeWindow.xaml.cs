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
    /// Interaction logic for EditEmployeeWindow.xaml
    /// </summary>
    public partial class EditEmployeeWindow : Window
    {
        DB db;
        Employee empl;
        public EditEmployeeWindow(Employee e)
        {
            InitializeComponent();

            empl = e;
            db = new HolidayOutClient.DB();

            fillRoles();

            txtName.Text = e.Name;
            txtNachname.Text = e.Nachname;
            lblUsernameFinished.Content = e.Username;

            foreach (Role r in comboBoxRoles.Items)
            {
                if (r.ID_Role == e.id_Role)
                    comboBoxRoles.SelectedItem = r;
            }

        }

        private void fillRoles()
        {
            comboBoxRoles.ItemsSource = db.GetAllRoles();
            
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
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
                            if (Birthdate.SelectedDate == null)
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

                                    Employee emp = new Employee();

                                    emp.ID = empl.ID;
                                    emp.Name = txtName.Text;
                                    emp.Nachname = txtNachname.Text;
                                    emp.Birthdate = (DateTime)Birthdate.SelectedDate;
                                    emp.Username = (string)lblUsernameFinished.Content;
                                    Role r = (Role)comboBoxRoles.SelectedItem;
                                    emp.id_Role = r.ID_Role;

                                    db.UpdateEmployee(emp);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
