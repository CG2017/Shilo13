using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorMine.ColorSpaces;

namespace lab2WF
{
    public static class ColorConverter
    {
        public static double GetDistance(LabColor first, LabColor second,
            double kL = 1, double kA = 1, double kB = 1)
        {
            return Math.Sqrt(kA * (first.A - second.A)*(first.A - second.A)
                             + kB * (first.B - second.B)*(first.B - second.B)+
                             kL*(first.L - second.L) * (first.L - second.L));
        }

        public static XyzColor GetXyzColorFromRgb(Color color)
        {
            double R = color.R;
            double G = color.G;
            double B = color.B;
            double var_R = (R / 255); //R from 0 to 255
            double var_G = (G / 255); //G from 0 to 255
            double var_B = (B / 255); //B from 0 to 255

            if (var_R > 0.04045) var_R = Math.Pow((var_R + 0.055) / 1.055, 2.4);
            else var_R = var_R / 12.92;
            if (var_G > 0.04045) var_G = Math.Pow((var_G + 0.055) / 1.055, 2.4);
            else var_G = var_G / 12.92;
            if (var_B > 0.04045) var_B = Math.Pow((var_B + 0.055) / 1.055, 2.4);
            else var_B = var_B / 12.92;

            var_R = var_R * 100;
            var_G = var_G * 100;
            var_B = var_B * 100;//Observer. = 2°, Illuminant = D65

            double x = var_R * 0.4124 + var_G * 0.3576 + var_B * 0.1805;
            double y = var_R * 0.2126 + var_G * 0.7152 + var_B * 0.0722;
            double z = var_R * 0.0193 + var_G * 0.1192 + var_B * 0.9505;
            return new XyzColor(x, y, z);
        }

        public static Color GetRgbColorFromXyz(XyzColor color)
        {
            double x = color.X;
            double y = color.Y;
            double z = color.Z;
            double var_X = x / 100; //X from 0 to  95.047      (Observer = 2°, Illuminant = D65)
            double var_Y = y / 100; //Y from 0 to 100.000
            double var_Z = z / 100; //Z from 0 to 108.883

            double var_R = var_X * 3.2406 + var_Y * -1.5372 + var_Z * -0.4986;
            double var_G = var_X * -0.9689 + var_Y * 1.8758 + var_Z * 0.0415;
            double var_B = var_X * 0.0557 + var_Y * -0.2040 + var_Z * 1.0570;

            if (var_R > 0.0031308) var_R = 1.055 * Math.Pow(var_R, (1 / 2.4)) - 0.055;
            else var_R = 12.92 * var_R;
            if (var_G > 0.0031308) var_G = 1.055 * (Math.Pow(var_G, (1 / 2.4))) - 0.055;
            else var_G = 12.92 * var_G;
            if (var_B > 0.0031308) var_B = 1.055 * (Math.Pow(var_B, (1 / 2.4))) - 0.055;
            else var_B = 12.92 * var_B;

            double r = (var_R * 255);
            double g = (var_G * 255);
            double b = (var_B * 255);
            //LogTextBox.Text = "";
            if (r > 255)
            {
                //LogTextBox.Text += $"r = {r:#.##} is greater than 255";
                r = 255;
            }
            if (g > 255)
            {
                //LogTextBox.Text += $"g = {g:#.##} is greater than 255";
                g = 255;
            }
            if (b > 255)
            {
                //LogTextBox.Text += $"b = {b:#.##} is greater than 255";
                b = 255;
            }
            return Color.FromArgb((byte)r, (byte)g, (byte)b);
        }

        public static XyzColor GetXyzColorFromLab(LabColor labColor)
        {
            double L = labColor.L;
            double a = labColor.A;
            double b = labColor.B;
            double var_Y = (L + 16) / 116;
            double var_X = a / 500 + var_Y;
            double var_Z = var_Y - b / 200;

            if (Math.Pow(var_Y, 3) > 0.008856) var_Y = Math.Pow(var_Y, 3);
            else var_Y = (var_Y - 16.0 / 116) / 7.787;
            if (Math.Pow(var_X, 3) > 0.008856) var_X = Math.Pow(var_X, 3);
            else var_X = (var_X - 16.0 / 116) / 7.787;
            if (Math.Pow(var_Z, 3) > 0.008856) var_Z = Math.Pow(var_Z, 3);
            else var_Z = (var_Z - 16.0 / 116) / 7.787;

            double ref_X = 95.047;
            double ref_Y = 100.000;
            double ref_Z = 108.883;
            double X = ref_X * var_X;     //ref_X =  95.047     Observer= 2°, Illuminant= D65
            double Y = ref_Y * var_Y;     //ref_Y = 100.000
            double Z = ref_Z * var_Z;     //ref_Z = 108.883
            return new XyzColor(X, Y, Z);
        }

        public static LabColor GetLabColorFromXyz(XyzColor xyzColor)
        {
            double ref_X = 95.047;
            double ref_Y = 100.000;
            double ref_Z = 108.883;
            double X = xyzColor.X;
            double Y = xyzColor.Y;
            double Z = xyzColor.Z;
            double var_X = X / ref_X; //ref_X =  95.047   Observer= 2°, Illuminant= D65
            double var_Y = Y / ref_Y; //ref_Y = 100.000
            double var_Z = Z / ref_Z; //ref_Z = 108.883

            if (var_X > 0.008856) var_X = Math.Pow(var_X, (1.0 / 3));
            else var_X = (7.787 * var_X) + (16.0 / 116);
            if (var_Y > 0.008856) var_Y = Math.Pow(var_Y, (1.0 / 3));
            else var_Y = (7.787 * var_Y) + (16.0 / 116);
            if (var_Z > 0.008856) var_Z = Math.Pow(var_Z, (1.0 / 3));
            else var_Z = (7.787 * var_Z) + (16.0 / 116);

            double L = (116 * var_Y) - 16;
            double a = 500 * (var_X - var_Y);
            double b = 200 * (var_Y - var_Z);

            return new LabColor(L, a, b);
        }

        public static LabColor GetLabFromRgb(Color rgbColor)
        {
            Lab labColor = new Lab {};
            labColor.Initialize(new Rgb { R = rgbColor.R, B = rgbColor.B, G = rgbColor.G });

            return new LabColor(labColor.L, labColor.A, labColor.B);
        }

        public static Color GetRgbColorFromLab(LabColor labColor)
        {
            Lab lab = new Lab {A = labColor.A, B = labColor.B, L = labColor.L};
            IRgb rgbColor = lab.ToRgb();
            return Color.FromArgb((int)rgbColor.R, (int)rgbColor.G, (int)rgbColor.B);
        }
    }

    public static class MyMath
    {
        public static double Clamp(double value, double left, double right)
        {
            //if (value < left)
            //    return left;
            //if (value > right)
            //    return right;
            return value;
        }    
    }

    public struct LabColor
    {
        public double L { get; }
        public double A { get; }
        public double B { get; }

        public LabColor(double l, double a, double b)
        {
            /*  L in [0, 100]
                A in [-86.185, 98,254]
                B in [-107.863, 94.482]
             */
            L = MyMath.Clamp(l, 0, 100);
            A = MyMath.Clamp(a, -86.185, 98.254);
            B = MyMath.Clamp(b, -107.863, 94.482);
        }

        public static LabColor operator +(LabColor first, LabColor second)
        {
            return new LabColor(first.L + second.L, first.A + second.A, first.B + second.B);
        }

        public static LabColor operator -(LabColor first, LabColor second)
        {
            return new LabColor(first.L - second.L, first.A - second.A, first.B - second.B);
        }
    }

    public struct XyzColor
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public XyzColor(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
