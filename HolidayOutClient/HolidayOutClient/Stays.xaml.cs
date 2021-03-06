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
    /// Interaktionslogik für Stays.xaml
    /// </summary>
    public partial class Stays : Window
    {
        public Stays()
        {
            InitializeComponent();
            DB db = new DB();
            List<Stay> list = db.LoadStays();

            this.dataGrid.ItemsSource = list;
        }

    
    }
}
