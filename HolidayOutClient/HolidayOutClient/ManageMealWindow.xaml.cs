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
    /// Interaction logic for ManageMealWindow.xaml
    /// </summary>
    public partial class ManageMealWindow : Window
    {
        private DB db;
        public ManageMealWindow()
        {
            InitializeComponent();
            db = new HolidayOutClient.DB();
        }

        private void radioButtonSuppe_Checked(object sender, RoutedEventArgs e)
        {
            listViewMeals.Items.Clear();
            List<Meal> temp = db.LoadMeals();
            
            foreach(Meal m in temp)
            {
                if (m.MealType == 1)
                    listViewMeals.Items.Add(m);
            }
        }

        private void radioButtonNachspeise_Checked(object sender, RoutedEventArgs e)
        {
            listViewMeals.Items.Clear();
            List<Meal> temp = db.LoadMeals();

            foreach (Meal m in temp)
            {
                if (m.MealType == 3)
                    listViewMeals.Items.Add(m);
            }
        }

        private void radioButtonHauptspeise_Checked(object sender, RoutedEventArgs e)
        {
            listViewMeals.Items.Clear();
            List<Meal> temp = db.LoadMeals();

            foreach (Meal m in temp)
            {
                if (m.MealType == 2)
                    listViewMeals.Items.Add(m);
            }
        }

        private void btnRemoveMeal_Click(object sender, RoutedEventArgs e)
        {
            if (listViewMeals.SelectedItem != null)
            {
                Meal m = (Meal)listViewMeals.SelectedItem;

                if (radioButtonSuppe.IsChecked == true)
                    m.MealType = 1;
                if (radioButtonHauptspeise.IsChecked == true)
                    m.MealType = 2;
                if (radioButtonNachspeise.IsChecked == true)
                    m.MealType = 3;

                m.Time = DateTime.Now;

                db.RemoveMeal(m);
            } else
            {
                lblMsg.Content = "no item selected !";
            }
            
        }

        private void btnEditMeal_Click(object sender, RoutedEventArgs e)
        {
            if(listViewMeals.SelectedItem != null)
            {
                Meal m = (Meal)listViewMeals.SelectedItem;

                EditMealWindow emw = new EditMealWindow(m);
                emw.Show();
            } else
            {
                lblMsg.Content = "no item selected !";
            }
        }

        private void btnAddMeal_Click(object sender, RoutedEventArgs e)
        {
            addMealWindow amw = new addMealWindow();
            amw.Show();
        }
    }
}
