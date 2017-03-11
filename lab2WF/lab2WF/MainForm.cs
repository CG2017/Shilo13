using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab2WF.Properties;

namespace lab2WF
{
    public partial class MainForm : Form
    {
        private FileDialog fileDialog;
        private ColorDialog colorDialog;
        private Color selectedColor;
        private int sensDistance = 50;
        private Color targetColor;
        private LabColor targetLabColor;
        private LabColor selectedLabColor;
        private LabColor deltaVector;

        public MainForm()
        {
            InitializeComponent();
            ConfigureApplication();
        }

        private void ConfigureApplication()
        {    
            colorDialog = new ColorDialog();
            fileDialog = new OpenFileDialog();
            fileDialog.FileOk += FileOkHandler;
            pctBoxSource.MouseClick += PixelMouseClickHandler;
            selectedColor = Color.FromArgb(255, 255, 255);
            targetColor = Color.FromArgb(255, 255, 255);
            selectedLabColor = ColorConverter.GetLabFromRgb(selectedColor);
            targetLabColor = ColorConverter.GetLabFromRgb(targetColor);
            sensDistance = sliderSensitivity.Value;
            sliderSensitivity.ValueChanged += (o, e) =>
            {
                sensDistance = sliderSensitivity.Value;
                btnConvert_Click(this, EventArgs.Empty);
            };
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            fileDialog.ShowDialog(this);
            //fileDialog.Filter = Resources.FilesFilterString;
        }

        private void PixelMouseClickHandler(object sender, MouseEventArgs args)
        {
            Point location = args.Location;
            
            if (location.X < 0 || location.Y < 0
                || location.X > pctBoxSource.Width || location.Y > pctBoxSource.Height)
            {
                return;
            }

            Bitmap bitmap = pctBoxSource.Image as Bitmap;
            if (bitmap == null)
            {
                return;
            }

            double picWidth = pctBoxSource.Width;
            double picHeight = pctBoxSource.Height;
            double bitWidth = bitmap.Width;
            double bitHeight = bitmap.Height;
            int realX = (int) (location.X/picWidth*bitWidth);
            int realY = (int) (location.Y/picHeight*bitHeight);
            selectedColor = bitmap.GetPixel(realX, realY);
            selectedLabColor = ColorConverter.GetLabFromRgb(selectedColor);
            pctBoxSelectedColor.BackColor = selectedColor;
        }

        private void FileOkHandler(object sender, CancelEventArgs args)
        {
            pctBoxSource.Image = Bitmap.FromFile(fileDialog.FileName);
        }

        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog(this);
            targetColor = colorDialog.Color;
            targetLabColor = ColorConverter.GetLabFromRgb(targetColor);
            pctBoxDestColor.BackColor = targetColor;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            Bitmap sourceBitmap = pctBoxSource.Image as Bitmap;
            if (sourceBitmap == null)
            {
                return;
            }

            deltaVector = targetLabColor - selectedLabColor;
            Bitmap destBitmap = new Bitmap(sourceBitmap);
            for (int x = 0; x < sourceBitmap.Width; x++)
            {
                for (int y = 0; y < sourceBitmap.Height; y++)
                {
                    destBitmap.SetPixel(x, y, ConvertPixel(x, y, sourceBitmap));
                }
            }

            pctBoxDestination.Image = destBitmap;
        }

        private Color ConvertPixel(int x, int y, Bitmap source)
        {
            Color curPixel = source.GetPixel(x, y);
            LabColor curLabColor = ColorConverter.GetLabFromRgb(curPixel);

            if (ColorConverter.GetDistance(curLabColor, selectedLabColor) <= sensDistance)
            {
                return ColorConverter.GetRgbColorFromLab(curLabColor + deltaVector);
            }

            return curPixel;
        }

        private void btnSetAsSource_Click(object sender, EventArgs e)
        {
            if (pctBoxDestination.Image == null)
            {
                return;
            }

            pctBoxSource.Image = new Bitmap(pctBoxDestination.Image);
        }
    }
}
