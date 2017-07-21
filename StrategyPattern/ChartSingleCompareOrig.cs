using System;
using System.Drawing;
using System.Runtime.Remoting.Metadata;
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

        public void ShowChart(int chartType, string displayType, bool shouldShowDialog)
        {
            this.chartType = chartType;
            this.displayType = displayType;
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
                if (ShouldInvalidate(g, data))
                {
                    this.Invalidate();
                }
            }
            catch (ArgumentException ex)
            {
                this.Invalidate();
            }
        }

        private static bool ShouldInvalidate(Graphics g, Data data)
        {
            return !(g.DpiX == 300) ||
                   g != null && (data.otherData.Length > 20 || data.otherData.Length < 5) &&
                   (data == null || !data.data.StartsWith("hold"));
        }

        private void RenderChart(string displayType, Graphics g, Data data)
        {
            if (chartType == ChartTypeBar)
            {
                BarChart.RenderBarChart(displayType, g, data);
            }
            else
            {
                PieChart.RenderPieChart(g, data);
            }
        }

        private Data GetData(string displayType)
        {
            if (chartType == ChartTypeBar)
            {
                return BarChart.GetBarChartData(displayType);
            }
            else
            {
                return PieChart.GetPieChartData(displayType);
            }
        }

        private void RenderChartBackground(string displayType, Graphics g)
        {
            if (chartType == ChartTypeBar)
            {
                BarChart chart = new BarChart();
                BarChart.RenderBarChartBackground(displayType, g);
            }
            else
            {
                PieChart chart = new PieChart();
                PieChart.RenderPieChartBackground(displayType, g);
            }
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