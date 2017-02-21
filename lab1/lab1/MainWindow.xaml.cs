using System;
using System.Collections.Generic;
using System.Globalization;
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
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace lab1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly double eps = 1e-6;
        private readonly Point startGradientPoint = new Point(0, 0.5);
        private readonly Point endGradientPoint = new Point(1, 0.5);

        public MainWindow()
        {
            InitializeComponent();
            SubscribeRgb();
            SubscribeCmy();
            UpdateRgbFromSliders(new object(), new EventArgs());
        }

#region RGB

        private void SetSliderValue(Slider slider, double value)
        {
            if (Math.Abs(slider.Value - value) > eps)
                slider.Value = value;
        }

        private void SetTextBoxText(TextBox textBox, string text)
        {
            if (!string.Equals(textBox.Text, text))
            {
                textBox.Text = text;
            }
        }

        private void SubscribeRgb()
        {
            RSlider.ValueChanged += UpdateRgbFromSliders;
            GSlider.ValueChanged += UpdateRgbFromSliders;
            BSlider.ValueChanged += UpdateRgbFromSliders;

            RValueTextBox.KeyDown += UpdateRgbFromTextBoxes;
            GValueTextBox.KeyDown += UpdateRgbFromTextBoxes;
            BValueTextBox.KeyDown += UpdateRgbFromTextBoxes;

            RgbColorPicker.SelectedColorChanged += UpdateFromColorPicker;
        }

        private void DesubscribeRgb()
        {
            RSlider.ValueChanged -= UpdateRgbFromSliders;
            GSlider.ValueChanged -= UpdateRgbFromSliders;
            BSlider.ValueChanged -= UpdateRgbFromSliders;

            RValueTextBox.KeyDown -= UpdateRgbFromTextBoxes;
            GValueTextBox.KeyDown -= UpdateRgbFromTextBoxes;
            BValueTextBox.KeyDown -= UpdateRgbFromTextBoxes;

            RgbColorPicker.SelectedColorChanged -= UpdateFromColorPicker;
        }

        private void UpdateFromColorPicker(object sender, EventArgs args)
        {
            if (RgbColorPicker.SelectedColor == null)
                return;
            byte r = RgbColorPicker.SelectedColor.Value.R;
            byte g = RgbColorPicker.SelectedColor.Value.G;
            byte b = RgbColorPicker.SelectedColor.Value.B;
            UpdateFromRgbModel(r, g, b);
        }

        private void UpdateRgbFromSliders(object sender, EventArgs args)
        {
            byte r = (byte) RSlider.Value;
            byte g = (byte) GSlider.Value;
            byte b = (byte) BSlider.Value;
            UpdateFromRgbModel(r, g, b);
        }

        private void UpdateRgbFromTextBoxes(object sender, KeyEventArgs args)
        {
            if (args.Key != Key.Enter)
                return;
            byte r, g, b;
            try
            {
                r = byte.Parse(RValueTextBox.Text);
                g = byte.Parse(GValueTextBox.Text);
                b = byte.Parse(BValueTextBox.Text);
            }
            catch (Exception)
            {
                return;
            }
            UpdateFromRgbModel(r, g, b);
        }

        private void UpdateFromRgbModel(byte r, byte g, byte b)
        {
            UpdateRgb(r, g, b);
            double c, m, y;
            ConvertFromRgbToCmy(r, g, b, out c, out m, out y);
            UpdateCmy(c, m, y);
        }

        private void UpdateRgb(byte r, byte g, byte b)
        {
            DesubscribeRgb();
            BackgroundGrid.Background =
                    new SolidColorBrush(Color.FromRgb(r, g, b));
            SetTextBoxText(RValueTextBox, r.ToString());
            SetTextBoxText(GValueTextBox, g.ToString());
            SetTextBoxText(BValueTextBox, b.ToString());

            SetSliderValue(RSlider, r);
            SetSliderValue(GSlider, g);
            SetSliderValue(BSlider, b);
            RGradientRect.Fill = new LinearGradientBrush(
                Color.FromRgb(0, g, b), Color.FromRgb(255, g, b),
                startGradientPoint, endGradientPoint);
            GGradientRect.Fill = new LinearGradientBrush(
                Color.FromRgb(r, 0, b), Color.FromRgb(r, 255, b),
                startGradientPoint, endGradientPoint);
            BGradientRect.Fill = new LinearGradientBrush(
                Color.FromRgb(r, g, 0), Color.FromRgb(r, g, 255),
                startGradientPoint, endGradientPoint);

            RgbColorPicker.SelectedColor = Color.FromRgb(r, g, b);

            SubscribeRgb();
        }
        #endregion

        private Color GetColorFromCmy(double c, double m, double y)
        {
            double r = (1 - c) * 255;
            double g = (1 - m) * 255;
            double b = (1 - y) * 255;
            return Color.FromRgb((byte)r, (byte)g, (byte)b);
        }

        private void ConvertFromRgbToCmy(
            byte r, byte g, byte b, out double c, out double m, out double y)
        {
            c = 1.0 - r/255.0;
            m = 1.0 - g/255.0;
            y = 1.0 - b/255.0;
        }

        #region CMY

        private void SubscribeCmy()
        {
            CSlider.ValueChanged += UpdateCmyFromSliders;
            MSlider.ValueChanged += UpdateCmyFromSliders;
            YSlider.ValueChanged += UpdateCmyFromSliders;

            CValueTextBox.KeyDown += UpdateCmyFromTextBoxes;
            MValueTextBox.KeyDown += UpdateCmyFromTextBoxes;
            YValueTextBox.KeyDown += UpdateCmyFromTextBoxes;
        }

        private void DesubscribeCmy()
        {
            CSlider.ValueChanged -= UpdateCmyFromSliders;
            MSlider.ValueChanged -= UpdateCmyFromSliders;
            YSlider.ValueChanged -= UpdateCmyFromSliders;

            CValueTextBox.KeyDown -= UpdateCmyFromTextBoxes;
            MValueTextBox.KeyDown -= UpdateCmyFromTextBoxes;
            YValueTextBox.KeyDown -= UpdateCmyFromTextBoxes;
        }

        private void UpdateCmyFromSliders(object sender, EventArgs args)
        {
            double c = CSlider.Value;
            double m = MSlider.Value;
            double y = YSlider.Value;
            UpdateFromCmyModel(c, m, y);
        }

        private void UpdateCmyFromTextBoxes(object sender, KeyEventArgs args)
        {
            if (args.Key != Key.Enter)
                return;
            double c, m, y;
            try
            {
                c = double.Parse(CValueTextBox.Text);
                m = double.Parse(MValueTextBox.Text);
                y = double.Parse(YValueTextBox.Text);
            }
            catch (Exception)
            {
                return;
            }
            UpdateFromCmyModel(c, m, y);
        }

        private void UpdateFromCmyModel(double c, double m, double y)
        {
            UpdateCmy(c, m, y);
            Color rgbColor = GetColorFromCmy(c, m, y);
            UpdateRgb(rgbColor.R, rgbColor.G, rgbColor.B);
        }

        private void UpdateCmy(double c, double m, double y)
        {
            SetSliderValue(CSlider, c);
            SetSliderValue(MSlider, m);
            SetSliderValue(YSlider, y);

            SetTextBoxText(CValueTextBox, c.ToString(CultureInfo.CurrentCulture));
            SetTextBoxText(MValueTextBox, m.ToString(CultureInfo.CurrentCulture));
            SetTextBoxText(YValueTextBox, y.ToString(CultureInfo.CurrentCulture));

            Color rgbColor = GetColorFromCmy(c, m, y);
            CGradientRect.Fill = new LinearGradientBrush(
                Color.FromRgb(255, rgbColor.G, rgbColor.B), Color.FromRgb(0, rgbColor.G, rgbColor.B),
                startGradientPoint, endGradientPoint);
            MGradientRect.Fill = new LinearGradientBrush(
                Color.FromRgb(rgbColor.R, 255, rgbColor.B), Color.FromRgb(rgbColor.R, 0, rgbColor.B),
                startGradientPoint, endGradientPoint);
            YGradientRect.Fill = new LinearGradientBrush(
                Color.FromRgb(rgbColor.R, rgbColor.G, 255), Color.FromRgb(rgbColor.R, rgbColor.G, 0),
                startGradientPoint, endGradientPoint);
        }
        
#endregion


    }
}
