using HolidayOutClient.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for BarKeeperWindow.xaml
    /// </summary>
    public partial class BarKeeperWindow : Window
    {

        public BarKeeperWindow()
        {
            InitializeComponent();

            var db = new DB();

            var meals = db.LoadMeals();

            foreach (Meal meal in meals)
            {
                listViewToDo.Items.Add(meal);
            }
        }

        private void btnShiftSnack_Click(object sender, RoutedEventArgs e)
        {
            Snack s = listViewToDo.SelectedItem as Snack;
            listViewDone.Items.Add(s);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            listViewToDo.Items.Clear();

            var db = new DB();

            var meals = db.LoadMeals();

            foreach (Meal meal in meals)
            {
                listViewToDo.Items.Add(meal);
            }
        }
    }

}
