using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace BaiTap5_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BitmapImage image = new BitmapImage(new Uri("C:\\Users\\chume\\source\\repos\\BaiTap5-1\\BaiTap5-1\\1.jpg"));
        public MainWindow()
        {
            InitializeComponent();
            
            img.Source = toGrayScale(image);
            SliderObj slider = new SliderObj();
            DataContext = slider;
            slider.levelChanged += sliderEventChangedHandler;
        }
   
        private void sliderEventChangedHandler(object sender, double newLevel)
        {
            img.Source = toGrayScale(image, newLevel);
        }

        public unsafe BitmapSource toGrayScale(BitmapSource source, double level = 1) {
            const int PIXEL_SIZE = 4;
            int width = source.PixelWidth;
            int height = source.PixelHeight;
            var bitmap = new WriteableBitmap(source);
            bitmap.Lock();
            var backBuffer = (byte*)bitmap.BackBuffer.ToPointer();
          
            for (int y = 0; y < height; y++) {
                var row = backBuffer + (y * bitmap.BackBufferStride);
                for (int x = 0; x < width; x++) {
                    byte r = (byte)(row[x * PIXEL_SIZE]);
                    byte g = (byte)(row[x * PIXEL_SIZE + 1]);
                    byte b = (byte)(row[x * PIXEL_SIZE + 2]);
                    byte a = (byte)(row[x * PIXEL_SIZE + 3]);

                    double grayScale = (r + g + b) / 3 * level;

                    for (int i = 0; i < PIXEL_SIZE; i++) {
                        double v = grayScale <= 255 ? grayScale : 255;
                        row[x * PIXEL_SIZE + i] = (byte) v;

                    }
                }
            }
            bitmap.AddDirtyRect(new Int32Rect(0, 0, width, height));
            bitmap.Unlock();
            return bitmap;
        }
    }
}

public delegate void SliderEventChangedHandler(object sender, double new_t);

public class SliderObj {
    private double _level;
    public SliderObj()
    {
        _level = 1;
    }
    public event SliderEventChangedHandler levelChanged;

    public double level {
        get { return _level; }
        set { _level = value; levelChanged(this, value); }
    }
}