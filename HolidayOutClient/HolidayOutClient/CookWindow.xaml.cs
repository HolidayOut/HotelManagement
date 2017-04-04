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
    /// Interaction logic for CookWindow.xaml
    /// </summary>
    public partial class CookWindow : Window
    {
        delegate void UpdateListDelegate(List<Meal> meals);

        public CookWindow()
        {
            InitializeComponent();

            var db = new DB();

            var meals = db.LoadMeals();

            foreach (Meal meal in meals)
            {        
                    listViewToDo.Items.Add(meal);              
            }
        }

        private void btnMove_Click(object sender, RoutedEventArgs e)
        {
            Meal m = (Meal)listViewToDo.SelectedItem;
            Meal newM = new Meal(m.id,m.name,m.time, 0, 0);
            listViewDone.Items.Add(newM);
        }

        private void listViewToDo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            var db = new DB();

            var meals = db.LoadMeals();

            foreach (Meal meal in meals)
            {
                listViewToDo.Items.Add(meal);
            }
        }
    }
}
