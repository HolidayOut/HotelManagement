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
            listViewToDo.Items.Clear();
            foreach (var meal in meals) { 
                listViewToDo.Items.Add(meal);
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

                Thread.Sleep(2000);
            }
        }
    }
}
