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
    /// Interaction logic for ManageEmployeesWindow.xaml
    /// </summary>
   
    public partial class ManageEmployeesWindow : Window
    {
        DB db;
        public ManageEmployeesWindow()
        {
            InitializeComponent();
            db = new DB();
            fillView();
        }

        private void fillView()
        {
            List<Employee> list = db.loadEmployees();
            this.listViewEmployees.ItemsSource = list;
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            lblMsg.Content = "";
            AddEmployeeWindow aew = new AddEmployeeWindow();
            aew.Show();
        }

        private void btnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            lblMsg.Content = "";
            if(listViewEmployees.SelectedItem != null)
            {
                EditEmployeeWindow eew = new EditEmployeeWindow((Employee)listViewEmployees.SelectedItem);
                eew.Show();
            } else
            {
                lblMsg.Content = "Please select Employee to change !";
            }
        }

        private void btnRemoveEmployee_Click(object sender, RoutedEventArgs e)
        {
            lblMsg.Content = "";
            if (listViewEmployees.SelectedItem != null)
            {
                Employee emp = (Employee)listViewEmployees.SelectedItem;

                db.RemoveEmployee(emp);
            }
            else
            {
                lblMsg.Content = "Please select Employee to change !";
            }
        }
    }
}
