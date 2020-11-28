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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BaiTap5_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SliderBall t = new SliderBall();
            this.DataContext = t;
            t.t_Changed += t_Changed;
        }

        private void t_Changed(object sender, double new_t)
        {
            Canvas.SetLeft(ball, new_t);
            int range = 500 - 230;
            double pt = (new_t - 230) / range;
            Canvas.SetTop(ball, 243 + (177-243) * pt);

            Canvas.SetLeft(ellipse, new_t + 5);
            Canvas.SetLeft(disk, new_t + 5);
            Canvas.SetLeft(square, new_t + 5);
            Canvas.SetLeft(plane, new_t );
           
        }

        private void hiddenAll()
        {
            ellipse.Visibility = Visibility.Hidden;
            disk.Visibility = Visibility.Hidden;
            square.Visibility = Visibility.Hidden;
            plane.Visibility =  Visibility.Hidden;
        }
        private void ellipse_Checked(object sender, RoutedEventArgs e)
        {
            hiddenAll();
            ellipse.Visibility = Visibility.Visible;
        }

        private void disk_Checked(object sender, RoutedEventArgs e)
        {
            hiddenAll();
            disk.Visibility = Visibility.Visible;
        }

        private void square_Checked(object sender, RoutedEventArgs e)
        {
            hiddenAll();
            square.Visibility = Visibility.Visible;
        }
        private void plane_Checked(object sender, RoutedEventArgs e)
        {
            hiddenAll();
            plane.Visibility = Visibility.Visible;
        }
    }
}


public delegate void t_ChangedEventHandler(object sender, double new_t);
public class SliderBall
{
    public SliderBall()
    {
        _t = 0;
    }
    public event t_ChangedEventHandler t_Changed;
    private double _t;
    public double t
    {
        get { return _t; }
        set { _t = value; t_Changed(this, value); }
    }
}