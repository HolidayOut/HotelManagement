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

        delegate void UpdateListDelegate(List<Snack> snacks);

        public BarKeeperWindow()
        {
            InitializeComponent();
        }

        public void Polling()
        {
            Thread test = new Thread(new ThreadStart(GetData));
            test.Start();
        }

        private void UpdateList(List<Snack> snacks)
        {
            List<Snack> items = listViewToDo.ItemsSource as List<Snack>;
            var ids = items.Select(i => i.ID).ToList();
            ids.Sort();

            foreach (Snack s in snacks)
            {
                if (ids.Contains(s.ID) == false)
                {
                    listViewToDo.Items.Add(s);
                }
            }
        }


        public void GetData()
        {
            var db = new DB();

            while (true)
            {
                var snacks = db.loadSnacks();

                listViewToDo.Dispatcher.Invoke(
                    new UpdateListDelegate(this.UpdateList),
                    snacks
                );

                Thread.Sleep(2000);
            }
        }

        private void btnShiftSnack_Click(object sender, RoutedEventArgs e)
        {
            Snack s = listViewToDo.SelectedItem as Snack;
            listViewDone.Items.Add(s);
        }
    }

}
