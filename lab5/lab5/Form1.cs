using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using lab5.Properties;
using ZedGraph;

namespace lab5
{
    public partial class Form1 : Form
    {
        private static readonly List<Point> DataList = new List<Point>();
        private List<Button> buttonsList = new List<Button>();

        public Form1()
        {
            InitializeComponent();
            InitTrackbars();
            ConfigureButtons();
            btn1BLine_Click(this, null);
            zedGraphControl1.GraphPane.XAxis.MajorGrid.IsVisible = true;
            zedGraphControl1.GraphPane.YAxis.MajorGrid.IsVisible = true;
        }

        private void ConfigureButtons()
        {
            buttonsList.Add(btn1BLine);
            buttonsList.Add(btn2BCircle);
            buttonsList.Add(btn3DDA);
            buttonsList.Add(btn4SimpleIter);
        }

        private void InitTrackbars()
        {
            if (x1TB.Text.Length == 0)
            {
                x1TB.Text = Resources.Form1_InitTrackbars__0;
            }
            if (y1TB.Text.Length == 0)
            {
                y1TB.Text = Resources.Form1_InitTrackbars__0;
            }

            trackBar1.Maximum = trackBar3.Maximum = Convert.ToInt32(x1TB.Text);
            trackBar1.TickFrequency = trackBar3.TickFrequency = trackBar3.Maximum/10;
            trackBar2.Maximum = trackBar4.Maximum = Convert.ToInt32(y1TB.Text);
            trackBar2.TickFrequency = trackBar4.TickFrequency = trackBar3.Maximum/10;
        }

        private void BlockButton(int index)
        {
            for (int i = 0; i < buttonsList.Count; i++)
            {
                if (i != index)
                {
                    buttonsList[i].Enabled = true;
                }
                else
                {
                    buttonsList[i].Enabled = false;
                }
            }
        }

        private static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        public static void Line(int x0, int y0, int x1, int y1)
        {
            var steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
            if (steep)
            {
                Swap(ref x0, ref y0);
                Swap(ref x1, ref y1);
            }
            if (x0 > x1)
            {
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }
            int dX = x1 - x0, dY = Math.Abs(y1 - y0), err = dX/2, ystep = y0 < y1 ? 1 : -1, y = y0;

            for (var x = x0; x <= x1; ++x)
            {
                if (steep)
                    PutPixel(y, x);
                else
                    PutPixel(x, y);
                err = err - dY;
                if (err < 0)
                {
                    y += ystep;
                    err += dX;
                }
            }
        }

        public static void Simple(int x0, int y0, int x1, int y1)
        {
            var dxabs = Math.Abs(x0 - x1);
            var dyabs = Math.Abs(y0 - y1);
            if (dyabs > dxabs)
            {
                if (y1 < y0)
                {
                    Swap(ref x0, ref x1);
                    Swap(ref y0, ref y1);
                }

                var dx = x1 - x0;
                var dy = y1 - y0;

                for (var y = y0; y < y1; y++)
                {
                    var x = x0 + dx * (y - y0) / dy;
                    PutPixel(x, y);
                }
            }
            else
            {
                if (x0 > x1)
                {
                    Swap(ref x0, ref x1);
                    Swap(ref y0, ref y1);
                }
                var dx = x1 - x0;
                var dy = y1 - y0;

                for (var x = x0; x < x1; x++)
                {
                    var y = y0 + dy * (x - x0) / dx;
                    PutPixel(x, y);
                }
            }

        }

        private static bool PutPixel(int x0, int y0)
        {
            if ((x0 >= 0 && y0 >= 0))
            {
                DataList.Add(new Point(x0, y0));
            }

            return true;
        }

        public static void Bresenham4Line(int x, int y)
        {
            Line(0, 0, x, y);
        }

        private static int Part(float x)
        {
            return (int) x;
        }

        private void GenerateBLine(int x0, int y0, int x, int y)
        {
            Line(x0, y0, x, y);
        }

        private void GenerateBCircle(int radius)
        {
            BresenhamCircle(radius);
        }
        
        private static void BresenhamCircle(int radius)
        {
            int x0 = radius + 5, y0 = radius + 5;
            MyBresenhamCircle(x0, y0, radius);
            return;
            int x = 0, y = radius, gap, delta = 2 - 2*radius;
            while (y >= 0)
            {
                PutPixel(x0 + x, y0 + y);
                PutPixel(x0 + x, y0 - y);
                PutPixel(x0 - x, y0 - y);
                PutPixel(x0 - x, y0 + y);
                gap = 2*(delta + y) - 1;
                if (delta < 0 && gap <= 0)
                {
                    x++;
                    delta += 2*x + 1;
                    continue;
                }
                if (delta > 0 && gap > 0)
                {
                    y--;
                    delta -= 2*y + 1;
                    continue;
                }
                x++;
                delta += 2*(x - y);
                y--;
            }
        }

        public static void MyBresenhamCircle(int x0, int y0, int radius)
        {
            int x = 0;
            int y = radius;
            PutCirclePixel(x0, y0, x, y);
            while (y > 0)
            {
                int xr = x + 1;
                int xv = x;
                int xd = x + 1;
                int yr = y;
                int yv = y - 1;
                int yd = y - 1;
                int diffR = CountDiff(xr, yr, radius);
                int diffV = CountDiff(xv, yv, radius);
                int diffD = CountDiff(xd, yd, radius);
                if (diffR < diffD && diffR < diffV)
                {
                    PutCirclePixel(x0, y0, xr, yr);
                    x = xr;
                    y = yr;
                }
                else if (diffV < diffD && diffV < diffD)
                {
                    PutCirclePixel(x0, y0, xv, yv);
                    x = xv;
                    y = yv;
                }
                else
                {
                    PutCirclePixel(x0, y0, xd, yd);
                    x = xd;
                    y = yd;
                }

            }
        }

        public static void PutCirclePixel(int x0, int y0, int x, int y)
        {
            PutPixel(x0 + x, y0 + y);
            PutPixel(x0 + x, y0 - y);
            PutPixel(x0 - x, y0 - y);
            PutPixel(x0 - x, y0 + y);
        }

        public static int CountDiff(int x, int y, int radius)
        {
            //double dist = Math.Sqrt(x * x + y * y);
            //double diff = Math.Abs(dist - radius);
            int dist = x * x + y * y;
            int diff = dist - radius * radius;
            return Math.Abs(diff);
        }

        private void y1TB_TextChanged(object sender, EventArgs e)
        {
            InitTrackbars();
        }

        private void x1TB_TextChanged(object sender, EventArgs e)
        {
            InitTrackbars();
        }

        private void ShowLine()
        {
            label6.Text = Resources.Form1_ShowLine_x0__ + trackBar1.Value;
            label5.Text = Resources.Form1_ShowLine_y0__ + trackBar2.Value;
            label8.Text = Resources.Form1_ShowLine_x1__ + trackBar3.Value;
            label7.Text = Resources.Form1_ShowLine_y1__ + trackBar4.Value;
            if (!btn1BLine.Enabled)
            {
                GenerateBLine(trackBar1.Value, trackBar2.Value, trackBar3.Value, trackBar4.Value);
            }
            else if (!btn2BCircle.Enabled)
            {
                GenerateBCircle(trackBar3.Value);
            }
            else if (!btn3DDA.Enabled)
            {
                GenerateDda(trackBar1.Value, trackBar2.Value, trackBar3.Value, trackBar4.Value);
            }
            else if (!btn4SimpleIter.Enabled)
            {
                GenerateSimple(trackBar1.Value, trackBar2.Value, trackBar3.Value, trackBar4.Value);
            }
        }

        private void GenerateDda(int x0, int y0, int x1, int y1)
        {
            Dda(x0, y0, x1, y1);
        }

        private void Dda(int x0, int y0, int x1, int y1)
        {
            var dx = x1 - x0;
            var dy = y1 - y0;
            int step, k;
            float xInc, yInc, x = x0, y = y0;
            if (Math.Abs(dx) > Math.Abs(dy))
                step = Math.Abs(dx);
            else
                step = Math.Abs(dy);
            xInc = (float) dx/step;
            yInc = (float) dy/step;
            PutPixel((int) Math.Round(x), (int) Math.Round(y));
            for (k = 0; k < step; k++)
            {
                x += xInc;
                y += yInc;
                PutPixel((int)Math.Round(x), (int)Math.Round(y));
            }
        }

        private void GenerateSimple(int x0, int y0, int x1, int y1)
        {
            Simple(x0, y0, x1, y1);
        }

        private void trackBarScroll(object sender, EventArgs e)
        {
            DataList.Clear();
            ShowLine();
            DrawGraph();
        }

        /// <summary>
        /// Drawing all points
        /// </summary>
        private void DrawGraph()
        {
            var pane = zedGraphControl1.GraphPane;
            pane.GraphObjList.Clear();
            int maxx=0, maxy = 0;
            foreach (var point in DataList)
            {
                maxx = Math.Max(maxx, point.X);
                maxy = Math.Max(maxy, point.Y);
               
                BoxObj boxObj = new BoxObj(point.X-0.5,point.Y+0.5,1,1,Color.Green,Color.Green);
                boxObj.IsVisible = true;
                boxObj.Location.CoordinateFrame = CoordType.AxisXYScale;
                boxObj.ZOrder = ZOrder.A_InFront;
                pane.GraphObjList.Add(boxObj);
            }
            pane.YAxis.Scale.Max = 100;//* maxy+10;
            pane.XAxis.Scale.Max = 100;// maxx+10;

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void btn1BLine_Click(object sender, EventArgs e)
        {
            label1.Text = Resources.Form1_checkedListBox1_SelectedValueChanged_max_x;
            label2.Text = Resources.Form1_checkedListBox1_SelectedValueChanged_max_y;
            y1TB.Enabled = true;
            x1TB.Enabled = true;

            trackBar2.Enabled = true;
            trackBar1.Enabled = true;
            trackBar3.Enabled = true;
            trackBar4.Enabled = true;

            BlockButton(0);
            trackBarScroll(this, null);
        }

        private void btn3DDA_Click(object sender, EventArgs e)
        {
            label1.Text = Resources.Form1_checkedListBox1_SelectedValueChanged_max_x;
            label2.Text = Resources.Form1_checkedListBox1_SelectedValueChanged_max_y;
            y1TB.Enabled = true;
            x1TB.Enabled = true;

            trackBar2.Enabled = true;
            trackBar1.Enabled = true;
            trackBar3.Enabled = true;
            trackBar4.Enabled = true;

            BlockButton(2);
            trackBarScroll(this, null);
        }

        private void btn2BCircle_Click(object sender, EventArgs e)
        {
            label1.Text = Resources.Form1_checkedListBox1_SelectedValueChanged_radius;
            label2.Text = "";
            y1TB.Enabled = false;
            trackBar2.Enabled = false;
            trackBar1.Enabled = false;
            trackBar3.Enabled = true;
            trackBar4.Enabled = false;

            BlockButton(1);
            trackBarScroll(this, null);
        }

        private void btn4SimpleIter_Click(object sender, EventArgs e)
        {
            label1.Text = Resources.Form1_checkedListBox1_SelectedValueChanged_max_x;
            label2.Text = Resources.Form1_checkedListBox1_SelectedValueChanged_max_y;
            y1TB.Enabled = true;
            x1TB.Enabled = true;

            trackBar2.Enabled = true;
            trackBar1.Enabled = true;
            trackBar3.Enabled = true;
            trackBar4.Enabled = true;

            BlockButton(3);
            trackBarScroll(this, null);
        }
    }
}