﻿using HolidayOutClient.Data;
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
    /// Interaction logic for EditMealWindow.xaml
    /// </summary>
    public partial class EditMealWindow : Window
    {
        DB db;
        public EditMealWindow(Meal m)
        {
            InitializeComponent();
            db = new DB();
            txtName.Text = m.Name;
            txtPrice.Text = m.Price.ToString();
        }

        private void btnSubmitChange_Click(object sender, RoutedEventArgs e)
        {
            if(txtName.Text == "")
            {
                lblNameMsg.Content = "no name set !";
            } else
            {
                lblNameMsg.Content = "";
                if(txtPrice.Text == "")
                {
                    lblPriceMsg.Content = "no Price set !";
                } else
                {
                    Meal m = new Meal();
                    m.Name = txtName.Text;

                    try
                    {
                        m.Price = decimal.Parse(txtPrice.Text);

                        m.Time = DateTime.Now;

                        db.UpdateMeal(m);
                    }
                    catch (Exception ex)
                    {
                        lblPriceMsg.Content = "is not a valid number !";
                    }
                }
            }
        }
    }
}
