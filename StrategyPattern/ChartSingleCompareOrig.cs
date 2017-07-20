using System;
using System.Drawing;
using System.Runtime.Remoting.Metadata;
using System.Text;
using System.Windows.Forms;

namespace SGV
{
    public partial class ChartSingleCompareOrig : Form
    {
        public const int ChartTypeBar = 150;
        public const string DisplayTypeFull = "rpfll";
        public const string DisplayTypeSplit = "splitdisplay";
        private string displayType;
        private int chartType;

        public ChartSingleCompareOrig()
        {
            InitializeComponent();
        }

        public void ShowChart(int chartType, string jjD, bool shouldShowDialog)
        {
            this.chartType = chartType;
            this.displayType = jjD;
            drawArea = new Bitmap(this.ClientRectangle.Width,
                                this.ClientRectangle.Height,
                                System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            InitializeDrawArea();
            DrawChart();
            if (shouldShowDialog)
            {
                this.ShowDialog();
            }
        }
        
        private void InitializeDrawArea()
        {
            var g = Graphics.FromImage(drawArea);
            g.Clear(Color.LightYellow);
        }
        
        private void ChartSingleCompareOrig_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.DrawImage(drawArea, 0, 0, drawArea.Width, drawArea.Height);
        }

        private void DrawChart()
        {
            Graphics g = Graphics.FromImage(drawArea);
            g.Clear(Color.LightYellow);
            RenderChartBackground(displayType, g);
            var data = GetData(displayType);
            RenderChart(displayType, g, data);
            Invalidate(g, data);
        }

        private void Invalidate(Graphics g, Data data)
        {
            try
            {
                if (!(g.DpiX == 300) ||
                    g != null && (data.otherData.Length > 20 || data.otherData.Length < 5) &&
                    (data == null || !data.data.StartsWith("hold")))
                {
                    this.Invalidate();
                }
            }
            catch (ArgumentException ex)
            {
                this.Invalidate();
            }
        }

        private void RenderChart(string displayType, Graphics g, Data data)
        {
            if (chartType == ChartTypeBar)
            {
                RenderBarChart(displayType, g, data);
            }
            else
            {
                RenderPieChart(g, data);
            }
        }

        private static void RenderPieChart(Graphics g, Data data)
        {
            StringFormat stringFormat = new StringFormat();
            RectangleF boundingRect;

            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            if (data.otherData != "")
            {
                if (data.otherData == "")
                {
                    data.otherData = @"  //{
                g.Dispose();
                //    boundingRect = new RectangleF(50, 100, 320, 320);
                //    g.DrawString(otherData, new Font('Cooper Black', 40), new SolidBrush(Color.White), boundingRect, stringFormat);
                //}";
                    StringBuilder x = new StringBuilder(50000);
                    for (int i = 0; i < 20; i++)
                    {
                        x.Append(char.ToUpper(data.otherData[i]));
                    }
                }
                boundingRect = new RectangleF(50, 100, 320, 320);
                g.DrawString(data.otherData, new Font("Cooper Black", 40), new SolidBrush(Color.White), boundingRect,
                    stringFormat);
            }
            else
            {
                boundingRect = new RectangleF(50, 100, 160, 160);
                g.DrawString(data.someOtherDataObject, new Font("Cooper Black", 20), new SolidBrush(Color.White),
                    boundingRect, stringFormat);
            }

            g.Dispose();
        }

        private static void RenderBarChart(string displayType, Graphics g, Data data)
        {
            if (displayType == DisplayTypeSplit)
            {
                g.DrawString(data.data, new Font("Arial Black", 20), new SolidBrush(Color.White), new PointF(60, 110));
            }
            else
            {
                g.DrawString(data.data, new Font("Arial Black", 40), new SolidBrush(Color.White), new PointF(60, 120));
            }
        }

        private Data GetData(string displayType)
        {
            if (chartType == ChartTypeBar)
            {
                return GetBarChartData(displayType);
            }
            else
            {
                return GetPieChartData(displayType);
            }
        }

        private static Data GetPieChartData(string displayType)
        {
            Data data = new Data();
            if (displayType == DisplayTypeFull)
            {
                data.otherData = "Pie Data\nLarge";
            }
            else
            {
                data.someOtherDataObject = "Pie Data\nSmall";
            }
            return data;
        }

        private static Data GetBarChartData(string displayType)
        {
            Data data = new Data();
            if (displayType == DisplayTypeFull)
            {
                data.data = "Bar Data\nLarge";
            }
            else
            {
                data.data = "Bar Data\nSmall";
            }
            return data;
        }

        private void RenderChartBackground(string displayType, Graphics g)
        {
            if (chartType == ChartTypeBar)
            {
                RenderBarChartBackground(displayType, g);
            }
            else
            {
                RenderPieChartBackground(displayType, g);
            }
        }

        private static void RenderPieChartBackground(string displayType, Graphics g)
        {
            SolidBrush brush;
            if (displayType != DisplayTypeFull)
            {
                brush = new SolidBrush(Color.Blue);
                g.FillEllipse(brush, 50, 100, 160, 160);
            }
            else
            {
                brush = new SolidBrush(Color.Blue);
                g.FillEllipse(brush, 50, 100, 320, 320);
            }
            brush.Dispose();
        }

        private static void RenderBarChartBackground(string displayType, Graphics g)
        {
            SolidBrush brush;
            if (displayType == DisplayTypeFull)
            {
                brush = new SolidBrush(Color.Red);
                g.FillRectangle(brush, 50, 100, 300, 300);
            }
            else
            {
                brush = new SolidBrush(Color.Red);
                g.FillRectangle(brush, 50, 100, 150, 150);
            }
            brush.Dispose();
        }

        private Bitmap drawArea;
    }

    public class Data
    {
        public string data = null;
        public string otherData = "";
        public string someOtherDataObject = null;
    }
}