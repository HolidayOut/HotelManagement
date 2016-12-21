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
    /// Interaction logic for addMealWindow.xaml
    /// </summary>
    public partial class addMealWindow : Window
    {
        DB db;
        public addMealWindow()
        {
            InitializeComponent();
            db = new HolidayOutClient.DB();
        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
           if(txtName.Text == "")
            {
                lblNameMsg.Content = "no name set !";
            }
            else
            {
                Meal m = new Meal();
                m.Name = txtName.Text;

                try
                {
                    m.Price = decimal.Parse(txtPrize.Text);

                    if (radioButtonSuppe.IsChecked == true)
                        m.MealType = 1;
                    if (radioButtonHaupt.IsChecked == true)
                        m.MealType = 2;
                    if (radioButtonNach.IsChecked == true)
                        m.MealType = 3;

                    m.Time = DateTime.Now;

                    db.InsertMeal(m);
                }
                catch (Exception ex)
                {
                    lblPrizeMsg.Content = "is not a valid number !";
                }               
            }
            
        }
    }
}
