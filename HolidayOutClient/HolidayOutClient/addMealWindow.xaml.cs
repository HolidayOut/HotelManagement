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
                m.name = txtName.Text;

                try
                {
                    m.price = decimal.Parse(txtPrize.Text);

                    if (radioButtonSuppe.IsChecked == true)
                        m.mealType = 1;
                    if (radioButtonHaupt.IsChecked == true)
                        m.mealType = 2;
                    if (radioButtonNach.IsChecked == true)
                        m.mealType = 3;

                    m.time = DateTime.Now.ToString("dd.MMM.yyyy");

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
