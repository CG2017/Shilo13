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
            SubscribeHsv();
            SubscribeLuv();
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
            double X, Y, Z;
            ConvertFromRgbToXyz(r, g, b, out X, out Y, out Z);
            double L, U, V;
            ConvertFromXyzToLuv(X, Y, Z, out L, out U, out V);
            UpdateLuv(L, U, V);
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
                .GradientStops[1].Color = Color.FromRgb(0, g, b);
            ((GradientBrush) RGradientRect.Fill)
                .GradientStops[0].Color = Color.FromRgb(255, g, b);

            ((GradientBrush) GGradientRect.Fill)
                .GradientStops[1].Color = Color.FromRgb(r, 0, b);
            ((GradientBrush) GGradientRect.Fill)
                .GradientStops[0].Color = Color.FromRgb(r, 255, b);

            ((GradientBrush)BGradientRect.Fill)
                .GradientStops[1].Color = Color.FromRgb(r, g, 0);
            ((GradientBrush)BGradientRect.Fill)
                .GradientStops[0].Color = Color.FromRgb(r, g, 255);

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
            double var_R = R/255.0; //RGB from 0 to 255
            double var_G = G/255.0;
            double var_B = B/255.0;

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

                double del_R = ((var_Max - var_R)/6 + del_Max/2)/del_Max;
                double del_G = ((var_Max - var_G)/6 + del_Max/2)/del_Max;
                double del_B = ((var_Max - var_B)/6 + del_Max/2)/del_Max;

                if (Math.Abs(var_R - var_Max) < eps) H = del_B - del_G;
                else if (Math.Abs(var_G - var_Max) < eps) H = 1/3.0 + del_R - del_B;
                else H = 2/3.0 + del_G - del_R;

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
            double X, Y, Z;
            ConvertFromRgbToXyz(rgbColor.R, rgbColor.G, rgbColor.B,
                    out X, out Y, out Z);
            double L, U, V;
            ConvertFromXyzToLuv(X, Y, Z, out L, out U, out V);
            UpdateLuv(L, U, V);
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
                .GradientStops[1].Color = Color.FromRgb(255, g, b);
            ((GradientBrush)CGradientRect.Fill)
                .GradientStops[0].Color = Color.FromRgb(0, g, b);

            ((GradientBrush)MGradientRect.Fill)
                .GradientStops[1].Color = Color.FromRgb(r, 255, b);
            ((GradientBrush)MGradientRect.Fill)
                .GradientStops[0].Color = Color.FromRgb(r, 0, b);

            ((GradientBrush)YGradientRect.Fill)
                .GradientStops[1].Color = Color.FromRgb(r, g, 255);
            ((GradientBrush)YGradientRect.Fill)
                .GradientStops[0].Color = Color.FromRgb(r, g, 0);
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
            double X, Y, Z;
            ConvertFromRgbToXyz(color.R, color.G, color.B, out X, out Y, out Z);
            double L, U, V;
            ConvertFromXyzToLuv(X, Y, Z, out L, out U, out V);
            UpdateLuv(L, U, V);
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

        #region Luv

        private void SubscribeLuv()
        {
            LSlider.ValueChanged += UpdateLuvFromSliders;
            uSlider.ValueChanged += UpdateLuvFromSliders;
            vSlider.ValueChanged += UpdateLuvFromSliders;
        }

        private void DesubscribeLuv()
        {
            LSlider.ValueChanged -= UpdateLuvFromSliders;
            uSlider.ValueChanged -= UpdateLuvFromSliders;
            vSlider.ValueChanged -= UpdateLuvFromSliders;
        }

        private void UpdateLuvFromSliders(object sender, EventArgs args)
        {
            double l, u, v;
            l = LSlider.Value;
            u = uSlider.Value;
            v = vSlider.Value;
            UpdateFromLuvModel(l, u, v);
        }

        private void UpdateFromLuvModel(double l, double u, double v)
        {
            UpdateLuv(l, u, v);
            double x, y, z;
            ConvertFromLuvToXyz(l, u, v, out x, out y, out z);
            Color rgbColor = GetRgbColorFromXyz(x, y, z);
            byte r, g, b;
            r = rgbColor.R;
            g = rgbColor.G;
            b = rgbColor.B;
            UpdateRgb(r, g, b);
            double C, M, Y;
            ConvertFromRgbToCmy(r, g, b, out C, out M, out Y);
            UpdateCmy(C, M, Y);
            double H, S, V;
            ConvertFromRgbToHsv(r, g, b, out H, out S, out V);
            UpdateHsv(H, S, V);
        }

        private void ConvertFromLuvToXyz(
            double l, double u, double v, out double x, out double y, out double z)
        {
            double var_Y = (l+16)/116;
            if (Math.Pow(var_Y, 3) > 0.008856)
                var_Y = Math.Pow(var_Y, 3);
            else
                var_Y = (var_Y - 16.0/116)/7.787;

            double ref_X = 95.047; //Observer= 2°, Illuminant= D65
            double ref_Y = 100.000;
            double ref_Z = 108.883;

            double ref_U = 4*ref_X/(ref_X + 15*ref_Y + 3*ref_Z);
            double ref_V = 9*ref_Y/(ref_X + 15*ref_Y + 3*ref_Z);

            double var_U = u/ (13*l) + ref_U;
            double var_V = v/ (13*l) + ref_V;

            y = var_Y*100;
            x = -(9*y*var_U)/((var_U - 4)*var_V - var_U*var_V);
            z = (9*y - 15*var_V*y - var_V*x)/(3*var_V);
        }

        private void ConvertFromXyzToLuv(
            double X, double Y, double Z, out double l, out double u, out double v)
        {
            if (Math.Abs(X) < eps)
                X = eps;
            if (Math.Abs(Y) < eps)
                Y = eps;
            if (Math.Abs(Z) < eps)
                Z = eps;
            double var_U = (4*X)/(X + (15*Y) + (3*Z));
            double var_V = (9*Y)/(X + (15*Y) + (3*Z));

            double var_Y = Y/100;
            if (var_Y > 0.008856) var_Y = Math.Pow(var_Y,(1.0/3));
            else var_Y = (7.787*var_Y) + (16.0/116);

            double ref_X = 95.047;      //Observer= 2°, Illuminant= D65
            double ref_Y = 100.000;
            double ref_Z = 108.883;

            double ref_U = (4*ref_X)/(ref_X + (15*ref_Y) + (3*ref_Z));
            double ref_V = (9*ref_Y)/(ref_X + (15*ref_Y) + (3*ref_Z));

            l= (116*var_Y) - 16;
            u= 13*l*(var_U - ref_U);
            v= 13*l*(var_V - ref_V);
        }

        private void ConvertFromRgbToXyz(
            double R, double G, double B, out double x, out double y, out double z)
        {
            double var_R = (R/255); //R from 0 to 255
            double var_G = (G/255); //G from 0 to 255
            double var_B = (B/255); //B from 0 to 255

            if (var_R > 0.04045) var_R = Math.Pow((var_R + 0.055)/1.055, 2.4);
            else var_R = var_R/12.92;
            if (var_G > 0.04045) var_G = Math.Pow((var_G + 0.055)/1.055, 2.4);
            else var_G = var_G/12.92;
            if (var_B > 0.04045) var_B = Math.Pow((var_B + 0.055)/1.055, 2.4);
            else var_B = var_B/12.92;

            var_R = var_R*100;
            var_G = var_G*100;
            var_B = var_B*100;//Observer. = 2°, Illuminant = D65

            x = var_R*0.4124 + var_G*0.3576 + var_B*0.1805;
            y = var_R*0.2126 + var_G*0.7152 + var_B*0.0722;
            z = var_R*0.0193 + var_G*0.1192 + var_B*0.9505;
        }

        private Color GetRgbColorFromXyz(double x, double y, double z)
        {
            double var_X = x/100; //X from 0 to  95.047      (Observer = 2°, Illuminant = D65)
            double var_Y = y/100; //Y from 0 to 100.000
            double var_Z = z/100; //Z from 0 to 108.883

            double var_R = var_X*3.2406 + var_Y*-1.5372 + var_Z*-0.4986;
            double var_G = var_X*-0.9689 + var_Y*1.8758 + var_Z*0.0415;
            double var_B = var_X*0.0557 + var_Y*-0.2040 + var_Z*1.0570;

            if (var_R > 0.0031308) var_R = 1.055*Math.Pow(var_R, (1/2.4)) - 0.055;
            else var_R = 12.92*var_R;
            if (var_G > 0.0031308) var_G = 1.055*(Math.Pow(var_G, (1/2.4))) - 0.055;
            else var_G = 12.92*var_G;
            if (var_B > 0.0031308) var_B = 1.055*(Math.Pow(var_B, (1/2.4))) - 0.055;
            else var_B = 12.92*var_B;

            double r = (var_R*255);
            double g = (var_G*255);
            double b = (var_B*255);
            LogTextBlock.Text = "";
            if (r > 255)
            {
                LogTextBlock.Text += $"r = {r:#.##} is greater than 255";
                r = 255;
            }
            if (g > 255)
            {
                LogTextBlock.Text += $"g = {g:#.##} is greater than 255";
                g = 255;
            }
            if (b > 255)
            {
                LogTextBlock.Text += $"b = {b:#.##} is greater than 255";
                b = 255;
            }
            return Color.FromRgb((byte) r, (byte) g, (byte) b);
        }

        private void UpdateLuv(double l, double u, double v)
        {
            DesubscribeLuv();

            LSlider.Value = l;
            uSlider.Value = u;
            vSlider.Value = v;

            LValueTextBox.Text = l.ToString(CultureInfo.CurrentCulture);
            uValueTextBox.Text = u.ToString(CultureInfo.CurrentCulture);
            vValueTextBox.Text = v.ToString(CultureInfo.CurrentCulture);

            SubscribeLuv();
        }
        #endregion
    }
}
