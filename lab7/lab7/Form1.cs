using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace lab7
{
    public partial class Form1 : Form
    {
        private RectangleF _bounds;

        private List<Tuple<PointF, PointF>> _lines = new List<Tuple<PointF, PointF>>();
        private List<Tuple<PointF, PointF>> tab3Lines = new List<Tuple<PointF, PointF>>();
        /* {
                        new PointF(100,100),new PointF(150,100),new PointF(220,200),new PointF(200,200)
                    };*/
        private PointF? _prevPoint;
        private readonly List<PointF> _boundsList = new List<PointF>();

        private List<Tuple<PointF, PointF>> boundaryList = new List<Tuple<PointF, PointF>>();

        public Form1()
        {
            InitializeComponent();
            ReadFile();
        }

        private void ReadFile()
        {
            int n;
            var counter = 0;
            using (TextReader reader = File.OpenText(@"input.txt"))
            {
                string line;
                int count = int.Parse(reader.ReadLine());
                for (int i = 0; i < count; i++)
                {
                    var lines = reader.ReadLine().Split(' ');
                    _lines.Add(
                                new Tuple<PointF, PointF>(
                                    new PointF(Convert.ToSingle(lines[0]), Convert.ToSingle(lines[1])),
                                    new PointF(Convert.ToSingle(lines[2]), Convert.ToSingle(lines[3]))));
                }
                while ((line = reader.ReadLine()) != null)
                {
                    var lines = line.Split(' ');
                    if (lines[0].Contains("poly"))
                    {
                        _boundsList.Add(new PointF(Convert.ToSingle(lines[1]), Convert.ToSingle(lines[2])));
                    }
                    else
                    {
                        _bounds = new RectangleF(Convert.ToSingle(lines[0]), Convert.ToSingle(lines[1]),
                            Convert.ToSingle(lines[2]), Convert.ToSingle(lines[3]));
                        boundaryList.Add(new Tuple<PointF, PointF>(
                            new PointF(_bounds.Left, _bounds.Top), new PointF(_bounds.Right, _bounds.Top)));
                        boundaryList.Add(new Tuple<PointF, PointF>(
                            new PointF(_bounds.Right, _bounds.Top), new PointF(_bounds.Right, _bounds.Bottom)));
                        boundaryList.Add(new Tuple<PointF, PointF>(
                            new PointF(_bounds.Right, _bounds.Bottom), new PointF(_bounds.Left, _bounds.Bottom)));
                        boundaryList.Add(new Tuple<PointF, PointF>(
                            new PointF(_bounds.Left, _bounds.Bottom), new PointF(_bounds.Left, _bounds.Top)));
                    }
                }
            }
        }


        private void btnClearLines_Click(object sender, EventArgs e)
        {
            _lines = new List<Tuple<PointF, PointF>>();
            _prevPoint = null;
            tabPage1.Invalidate();
            tabPage2.Invalidate();
            tabPage3.Invalidate();
        }


        private void btnClipLines_Click(object sender, EventArgs e)
        {
            var newLines = new List<Tuple<PointF, PointF>>();
            if (tabControl1.SelectedIndex == 2)
            {
                var polygon = new Polygon(_boundsList);

                var newPolygonSegments = polygon.SazerlandHojmanClip(_bounds);
                tab3Lines = new List<Tuple<PointF, PointF>>();
                foreach (var newSegment in newPolygonSegments)
                {
                    tab3Lines.Add(new Tuple<PointF, PointF>(newSegment.A, newSegment.B));
                }
            }
            else
                foreach (var line in _lines)
                {
                    var p1 = line.Item1;
                    var p2 = line.Item2;
                    if (tabControl1.SelectedIndex == 0)
                    {
                        var clipped = LiangBarskiy.ClipSegment(_bounds, p1, p2);
                        if (clipped != null)
                        {
                            newLines.Add(clipped);
                        }
                    }
                    if (tabControl1.SelectedIndex == 1)
                    {
                        Midpoint.ClipSegment(_bounds, p1, p2, newLines);
                    }
                }
            _lines = newLines;
            tabPage1.Invalidate();
            tabPage2.Invalidate();
            tabPage3.Invalidate();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            _lines.Clear();
            ReadFile();
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            _lines.Clear();
            ReadFile();
            tabPage1.Invalidate();
            tabPage2.Invalidate();
            tabPage3.Invalidate();
        }

        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {
            var width = tabPage1.ClientSize.Width;
            var height = tabPage1.ClientSize.Height;
            var heightIn = _bounds.Height;
            var widthIn = _bounds.Width;
            var widthBound = _bounds.X; //width/2 - widthIn/2;
            var heightBound = _bounds.Y; //height/2 - heightIn/2;


            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.DrawLine(Pens.Gray, widthBound, 0, widthBound, height);
            g.DrawLine(Pens.Gray, widthIn + widthBound, 0, widthIn + widthBound, height);
            g.DrawLine(Pens.Gray, 0, heightBound, width, heightBound);
            g.DrawLine(Pens.Gray, 0, heightIn + heightBound, width, heightIn + heightBound);

            var rects = new[]
            {
                new RectangleF(0, 0, widthBound, heightBound),
                new RectangleF(widthBound, 0, widthIn, heightBound),
                new RectangleF(widthIn + widthBound, 0, widthBound, heightBound),
                new RectangleF(0, heightBound, widthBound, heightIn),
                new RectangleF(widthBound, heightBound, widthIn, heightIn),
                new RectangleF(widthIn + widthBound, heightBound, widthBound, heightIn),
                new RectangleF(0, heightIn + heightBound, widthBound, heightBound),
                new RectangleF(widthBound, heightIn + heightBound, widthIn, heightBound),
                new RectangleF(widthIn + widthBound, heightIn + heightBound, widthBound, heightBound)
            };
            var codes = new[]
            {
                "Left|Top", "Top", "Right|Top",
                "Left", "Inside", "Right",
                "Left|Bottom", "Bottom", "Right|Bottom"
            };

            for (var i = 0; i < codes.Length; i++)
            {
                var brush = Brushes.Black;
                g.DrawString(codes[i], DefaultFont, brush, rects[i],
                    new StringFormat {Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center});
            }


            foreach (var line in _lines)
            {
                g.DrawLine(new Pen(Color.Black, 1), line.Item1, line.Item2);
            }
        }

        private void tabPage1_MouseClick(object sender, MouseEventArgs e)
        {
            var position = e.Location;
            if (_prevPoint == null)
            {
                _prevPoint = position;
            }
            else
            {
                var line = new Tuple<PointF, PointF>(_prevPoint.Value, position);
                _lines.Add(line);
                _prevPoint = null;
                tabPage1.Invalidate();
            }
        }

        private void tabPage2_Paint(object sender, PaintEventArgs e)
        {
            var width = tabPage2.ClientSize.Width;
            var height = tabPage2.ClientSize.Height;
            var heightIn = _bounds.Height;
            var widthIn = _bounds.Width;
            var widthBound = _bounds.X; //width/2 - widthIn/2;
            var heightBound = _bounds.Y; //height/2 - heightIn/2;


            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.DrawLine(Pens.Gray, widthBound, 0, widthBound, height);
            g.DrawLine(Pens.Gray, widthIn + widthBound, 0, widthIn + widthBound, height);
            g.DrawLine(Pens.Gray, 0, heightBound, width, heightBound);
            g.DrawLine(Pens.Gray, 0, heightIn + heightBound, width, heightIn + heightBound);

            var rects = new[]
            {
                new RectangleF(0, 0, widthBound, heightBound),
                new RectangleF(widthBound, 0, widthIn, heightBound),
                new RectangleF(widthIn + widthBound, 0, widthBound, heightBound),
                new RectangleF(0, heightBound, widthBound, heightIn),
                new RectangleF(widthBound, heightBound, widthIn, heightIn),
                new RectangleF(widthIn + widthBound, heightBound, widthBound, heightIn),
                new RectangleF(0, heightIn + heightBound, widthBound, heightBound),
                new RectangleF(widthBound, heightIn + heightBound, widthIn, heightBound),
                new RectangleF(widthIn + widthBound, heightIn + heightBound, widthBound, heightBound)
            };
            var codes = new[]
            {
                "Left|Top", "Top", "Right|Top",
                "Left", "Inside", "Right",
                "Left|Bottom", "Bottom", "Right|Bottom"
            };

            for (var i = 0; i < codes.Length; i++)
            {
                var brush = Brushes.Black;
                g.DrawString(codes[i], DefaultFont, brush, rects[i],
                    new StringFormat {Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center});
            }


            foreach (var line in _lines)
            {
                g.DrawLine(new Pen(Color.Black, 1), line.Item1, line.Item2);
            }
        }

        private void tabPage2_MouseClick(object sender, MouseEventArgs e)
        {
            var position = e.Location;
            if (_prevPoint == null)
            {
                _prevPoint = position;
            }
            else
            {
                var line = new Tuple<PointF, PointF>(_prevPoint.Value, position);
                _lines.Add(line);
                _prevPoint = null;
                tabPage2.Invalidate();
            }
        }

        private void tabPage3_MouseClick(object sender, MouseEventArgs e)
        {
            var position = e.Location;
            if (_prevPoint == null)
            {
                _prevPoint = position;
            }
            else
            {
                var line = new Tuple<PointF, PointF>(_prevPoint.Value, position);
                _lines.Add(line);
                _prevPoint = null;
                tabPage3.Invalidate();
            }
        }

        private void tabPage3_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            for (var i = 0; i < _boundsList.Count - 1; i++)
            {
                g.DrawLine(new Pen(Color.Red, 2), _boundsList[i], _boundsList[i + 1]);
            }
            g.DrawLine(new Pen(Color.Red, 2), _boundsList.Last(), _boundsList.First());

            foreach (var line in boundaryList)
            {
                g.DrawLine(new Pen(Color.Black, 1), line.Item1, line.Item2);
            }

            foreach (var line in tab3Lines)
            {
                g.DrawLine(new Pen(Color.Chocolate, 4), line.Item1, line.Item2);
            }
        }
    }
}