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

namespace Ex5_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();


        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 250);
            dispatcherTimer.Tick += dispatcherTimer_Tick; // set it up here
            dispatcherTimer.Start();

            tObject t = new tObject();
            this.DataContext = t;
            t.t_Changed += t_Changed;


        }

        private void t_Changed(object sender, double new_t)
        {
            Canvas.SetLeft(dot21, new_t * 100);
            Canvas.SetLeft(dot22, (new_t + 1) * 100);
            Canvas.SetLeft(dot23, (new_t + 2) * 100);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if(set1.Visibility == Visibility.Visible)
            {
                set1.Visibility = Visibility.Hidden;
                set2.Visibility = Visibility.Visible;
            } else
            {
                set1.Visibility = Visibility.Visible;
                set2.Visibility = Visibility.Hidden;
            }
        }
    }
}

public delegate void t_ChangedEventHandler(object sender, double new_t);
public class tObject
{
    public tObject()
    {
        _t = 0.25;
    }
    public event t_ChangedEventHandler t_Changed;
    private double _t;
    public double t
    {
        get { return _t; }
        set { _t = value; t_Changed(this, value); }
    }
}