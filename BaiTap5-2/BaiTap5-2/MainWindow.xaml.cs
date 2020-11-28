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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BaiTap5_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BackgroundObject bo = new BackgroundObject();
            this.DataContext = bo;
            bo.SpeedChanged += bo_SpeedChanged;
            Storyboard sb = (Storyboard)grid.FindResource("spin");
            sb.Begin();
        }

        public void bo_SpeedChanged(object sender, int newSpeed)
        {
            Storyboard sb = (Storyboard)grid.FindResource("spin");
            sb.SetSpeedRatio(newSpeed);
        }

    }
}

public delegate void SpeedChangedEventHandler(object sender, int newSpeed);
public class BackgroundObject
{
    public BackgroundObject()
    {
        _speed = 10;
    }
    public event SpeedChangedEventHandler SpeedChanged;
    private int _speed;
    public int Speed
    {
        get { return _speed; }
        set { _speed = value; SpeedChanged(this, value); }
    }
}