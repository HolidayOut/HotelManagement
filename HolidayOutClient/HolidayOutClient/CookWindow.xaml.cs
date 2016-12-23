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

            Polling();
        }

        public void Polling()
        {
            Thread test = new Thread(new ThreadStart(GetData));
            test.Start();
        }

        private void UpdateList(List<Meal> meals)
        {
            var temp = meals;
            List<Meal> items = (List<Meal>)listViewToDo.ItemsSource;
            if (temp != null)
            {
                if()
                var ids = items.Select(i => i.id).ToList();
                ids.Sort();

                foreach (Meal meal in meals)
                {
                    if (ids.Contains(meal.id) == false)
                    {
                        listViewToDo.Items.Add(meal);
                    }
                }
            }
        }


        public void GetData()
        {
            var db = new DB();

            while (true)
            {
                var meals = db.LoadMeals();

                listViewToDo.Dispatcher.Invoke(
                    new UpdateListDelegate(this.UpdateList),
                    meals
                );

                Thread.Sleep(3000);
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
    }
}
