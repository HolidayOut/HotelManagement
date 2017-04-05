using HolidayOutClient.Data;
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
    /// Interaction logic for MapWindow.xaml
    /// </summary>
    public partial class MapWindow : Window
    {
        public MapWindow()
        {
            InitializeComponent();
            loadAndPaint();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void loadAndPaint()
        {
            DB db = new DB();
            List<Coordinate> listCoordinates = db.getCoordinatesOfRooms();

            Coordinate borderC = new Coordinate(1,1);
            Rectangle r1 = new Rectangle();
            r1.Width = 500;
            r1.Height = 300;
            r1.StrokeThickness = 5;
            r1.Stroke = Brushes.Black;

            map.Children.Add(r1);

            Canvas.SetLeft(r1, borderC.x);
            Canvas.SetTop(r1, borderC.y);

            foreach (Coordinate c in listCoordinates)
            {
                Rectangle r = new Rectangle();
                r.Width = 150;
                r.Height = 120;
                r.Fill = Brushes.Red;
                r.StrokeThickness = 2;
                r.Stroke = Brushes.Black;

                map.Children.Add(r);

                Canvas.SetLeft(r, c.x);
                Canvas.SetTop(r, c.y);
            }

            Coordinate doorC = new Coordinate(490, 135);
            Rectangle r2 = new Rectangle();
            r2.Width = 15;
            r2.Height = 25;
            r2.Fill = Brushes.Blue;

            map.Children.Add(r2);

            Canvas.SetLeft(r2, doorC.x);
            Canvas.SetTop(r2, doorC.y);

        }
    }
}
