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

namespace lab1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Point startGradientPoint = new Point(0, 0.5);
        private readonly Point endGradientPoint = new Point(1, 0.5);

        public MainWindow()
        {
            InitializeComponent();
            ConfigureApplication();
            UpdateRgb();
        }

        private void ConfigureApplication()
        {
            RSlider.ValueChanged += (sender, args) => UpdateRgb();
            GSlider.ValueChanged += (sender, args) => UpdateRgb();
            BSlider.ValueChanged += (sender, args) => UpdateRgb();
        }

        private void UpdateRgb()
        {
            byte r = (byte) RSlider.Value;
            byte g = (byte) GSlider.Value;
            byte b = (byte) BSlider.Value;
            BackgroundGrid.Background =
                    new SolidColorBrush(Color.FromRgb(r, g, b));
            RValueTextBox.Text = r.ToString();
            GValueTextBox.Text = g.ToString();
            BValueTextBox.Text = b.ToString();
            RGradientRect.Fill = new LinearGradientBrush(Color.FromRgb(0, g, b), Color.FromRgb(0xFF, g, b),
                startGradientPoint, endGradientPoint);
            GGradientRect.Fill = new LinearGradientBrush(Color.FromRgb(r, 0, b), Color.FromRgb(r, 0xFF, b),
                startGradientPoint, endGradientPoint);
            BGradientRect.Fill = new LinearGradientBrush(Color.FromRgb(r, g, 0), Color.FromRgb(r, g, 0xFF),
                startGradientPoint, endGradientPoint);
        }
    }
}
