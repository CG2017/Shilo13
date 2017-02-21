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

        private double x;


        public MainWindow()
        {
            InitializeComponent();
            SubscribeRgb();
            SubscribeCmy();
            SubscribeHsv();
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
            double h, s, v;
            ConvertFromRgbToHsv(r, g, b, out h, out s, out v);
            UpdateHsv(h, s, v);
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

            ((GradientBrush) RGradientRect.Fill)
                .GradientStops[0].Color = Color.FromRgb(0, g, b);
            ((GradientBrush) RGradientRect.Fill)
                .GradientStops[1].Color = Color.FromRgb(255, g, b);

            ((GradientBrush) GGradientRect.Fill)
                .GradientStops[0].Color = Color.FromRgb(r, 0, b);
            ((GradientBrush) GGradientRect.Fill)
                .GradientStops[1].Color = Color.FromRgb(r, 255, b);

            ((GradientBrush)BGradientRect.Fill)
                .GradientStops[0].Color = Color.FromRgb(r, g, 0);
            ((GradientBrush)BGradientRect.Fill)
                .GradientStops[1].Color = Color.FromRgb(r, g, 255);

            RgbColorPicker.SelectedColor = Color.FromRgb(r, g, b);

            SubscribeRgb();
        }
        #endregion

        private Color GetRgbColorFromCmy(double c, double m, double y)
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

        private Color GetRgbColorFromHsv(double H, double S, double V)
        {
            byte R, G, B;
            if (Math.Abs(S) < eps) //HSV from 0 to 1
            {
                R = (byte) (V*255);
                G = (byte) (V*255);
                B = (byte) (V*255);
            }
            else
            {
                double var_h = H*6;
                if (Math.Abs(var_h - 6) < eps)
                    var_h = 0; //H must be < 1
                int var_i = (int) var_h; //Or ... var_i = floor( var_h )
                double var_1 = V*(1 - S);
                double var_2 = V*(1 - S*(var_h - var_i));
                double var_3 = V*(1 - S*(1 - (var_h - var_i)));
                double var_r, var_g, var_b;
                if (var_i == 0)
                {
                    var_r = V;
                    var_g = var_3;
                    var_b = var_1;
                }
                else if (var_i == 1)
                {
                    var_r = var_2;
                    var_g = V;
                    var_b = var_1;
                }
                else if (var_i == 2)
                {
                    var_r = var_1;
                    var_g = V;
                    var_b = var_3;
                }
                else if (var_i == 3)
                {
                    var_r = var_1;
                    var_g = var_2;
                    var_b = V;
                }
                else if (var_i == 4)
                {
                    var_r = var_3;
                    var_g = var_1;
                    var_b = V;
                }
                else
                {
                    var_r = V;
                    var_g = var_1;
                    var_b = var_2;
                }

                R = (byte) (var_r*255); //RGB results from 0 to 255
                G = (byte) (var_g*255);
                B = (byte) (var_b*255);
            }
            return Color.FromRgb(R, G, B);
        }

        private void ConvertFromRgbToHsv(
            byte R, byte G, byte B, out double H, out double S, out double V)
        {
            double var_R = (R/255.0); //RGB from 0 to 255
            double var_G = (G/255.0);
            double var_B = (B/255.0);

            double var_Min = Math.Min(var_R, Math.Min(var_G, var_B)); //Min. value of RGB
            double var_Max = Math.Max(var_R, Math.Max(var_G, var_B)); //Max. value of RGB
            double del_Max = var_Max - var_Min; //Delta RGB value 

            V = var_Max;

            if (Math.Abs(del_Max) < eps) //This is a gray, no chroma...
            {
                H = 0; //HSV results from 0 to 1
                S = 0;
            }
            else //Chromatic data...
            {
                S = del_Max/var_Max;

                double del_R = (((var_Max - var_R)/6) + (del_Max/2))/del_Max;
                double del_G = (((var_Max - var_G)/6) + (del_Max/2))/del_Max;
                double del_B = (((var_Max - var_B)/6) + (del_Max/2))/del_Max;

                if (Math.Abs(var_R - var_Max) < eps) H = del_B - del_G;
                else if (Math.Abs(var_G - var_Max) < eps) H = (1/3.0) + del_R - del_B;
                else H = (2/3.0) + del_G - del_R;

                if (H < 0) H += 1;
                if (H > 1) H -= 1;
            }
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
            Color rgbColor = GetRgbColorFromCmy(c, m, y);
            UpdateRgb(rgbColor.R, rgbColor.G, rgbColor.B);
            double h, s, v;
            ConvertFromRgbToHsv(rgbColor.R, rgbColor.G, rgbColor.B,
                out h, out s, out v);
            UpdateHsv(h, s, v);
        }

        private void UpdateCmy(double c, double m, double y)
        {
            DesubscribeCmy();
            SetSliderValue(CSlider, c);
            SetSliderValue(MSlider, m);
            SetSliderValue(YSlider, y);

            SetTextBoxText(CValueTextBox, c.ToString(CultureInfo.CurrentCulture));
            SetTextBoxText(MValueTextBox, m.ToString(CultureInfo.CurrentCulture));
            SetTextBoxText(YValueTextBox, y.ToString(CultureInfo.CurrentCulture));

            Color rgbColor = GetRgbColorFromCmy(c, m, y);
            byte r = rgbColor.R;
            byte g = rgbColor.G;
            byte b = rgbColor.B;

            ((GradientBrush)CGradientRect.Fill)
                .GradientStops[0].Color = Color.FromRgb(255, g, b);
            ((GradientBrush)CGradientRect.Fill)
                .GradientStops[1].Color = Color.FromRgb(0, g, b);

            ((GradientBrush)MGradientRect.Fill)
                .GradientStops[0].Color = Color.FromRgb(r, 255, b);
            ((GradientBrush)MGradientRect.Fill)
                .GradientStops[1].Color = Color.FromRgb(r, 0, b);

            ((GradientBrush)YGradientRect.Fill)
                .GradientStops[0].Color = Color.FromRgb(r, g, 255);
            ((GradientBrush)YGradientRect.Fill)
                .GradientStops[1].Color = Color.FromRgb(r, g, 0);
            SubscribeCmy();
        }

        #endregion

#region HSV

        private void SubscribeHsv()
        {
            HSlider.ValueChanged += UpdateHsvFromSliders;
            SSlider.ValueChanged += UpdateHsvFromSliders;
            VSlider.ValueChanged += UpdateHsvFromSliders;
        }

        private void DesubscribeHsv()
        {
            HSlider.ValueChanged -= UpdateHsvFromSliders;
            SSlider.ValueChanged -= UpdateHsvFromSliders;
            VSlider.ValueChanged -= UpdateHsvFromSliders;
        }

        private void UpdateHsvFromSliders(object sender, EventArgs args)
        {
            double h = HSlider.Value;
            double s = SSlider.Value;
            double v = VSlider.Value;
            UpdateFromHsvModel(h, s, v);
        }

        private void UpdateFromHsvModel(double h, double s, double v)
        {
            UpdateHsv(h, s, v);
            Color color = GetRgbColorFromHsv(h, s, v);
            UpdateRgb(color.R, color.G, color.B);
            double c, m, y;
            ConvertFromRgbToCmy(color.R, color.G, color.B, out c, out m, out y);
            UpdateCmy(c, m, y);
        }

        private void UpdateHsv(double h, double s, double v)
        {
            DesubscribeHsv();

            SetTextBoxText(HValueTextBox, (h*365).ToString(CultureInfo.CurrentCulture));
            SetTextBoxText(SValueTextBox, s.ToString(CultureInfo.CurrentCulture));
            SetTextBoxText(VValueTextBox, v.ToString(CultureInfo.CurrentCulture));

            SetSliderValue(HSlider, h);
            SetSliderValue(SSlider, s);
            SetSliderValue(VSlider, v);

            double hDeg = 0;
            foreach (var stop in ((GradientBrush) HGradientRect.Fill).GradientStops)
            {
                stop.Color = GetRgbColorFromHsv(hDeg, s, v);
                hDeg += 1.0/6;
            }
            GradientBrush SBrush = SGradientRect.Fill as GradientBrush;
            SBrush.GradientStops[0].Color = GetRgbColorFromHsv(h, 0, v);
            SBrush.GradientStops[1].Color = GetRgbColorFromHsv(h, 1, v);

            GradientBrush VBrush = VGradientRect.Fill as GradientBrush;
            VBrush.GradientStops[0].Color = GetRgbColorFromHsv(h, s, 0);
            VBrush.GradientStops[1].Color = GetRgbColorFromHsv(h, s, 1);
            SubscribeHsv();
        }
#endregion
    }
}
