using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SGV
{
    public partial class ChartSingleCompareOrig : Form
    {
        private string jjD;
        private int ct;

        public ChartSingleCompareOrig()
        {
            InitializeComponent();
        }

        public void iniDS(int ct, string jjReq1205, bool b)
        {
            this.ct = ct;
            this.jjD = jjReq1205;
            drawArea = new Bitmap(this.ClientRectangle.Width,
                                this.ClientRectangle.Height,
                                System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            InitializeDrawArea();
            DrawChart();
            if (b)
            {
                this.ShowDialog();
            }
        }
        
        private void InitializeDrawArea()
        {
            Graphics g;
            g = Graphics.FromImage(drawArea);
            g.Clear(Color.LightYellow);
        }
        
        private void ChartSingleCompareOrig_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            g = e.Graphics;
            g.DrawImage(drawArea, 0, 0, drawArea.Width, drawArea.Height);
        }

        private void DrawChart()
        {
            string jjD = this.jjD;
            Graphics g = Graphics.FromImage(drawArea);
            g.Clear(Color.LightYellow);

            // Render chart background
            SolidBrush brush;
            if (ct == 150)
            {
                if (jjD == "rpfll")
                {
                    brush = new SolidBrush(Color.Red);
                    g.FillRectangle(brush, 50, 100, 300, 300);
                }
                else
                {


                    brush = new SolidBrush(Color.Red);



                    g.FillRectangle(brush, 50, 100, 150, 150);


                }
            }
            else
            {
                if (jjD != "rpfll")
                {
                    brush = new SolidBrush(Color.Blue);
                    g.FillEllipse(brush, 50, 100, 160, 160);
                }
                else
                {
                    brush = new SolidBrush(Color.Blue);
                    g.FillEllipse(brush, 50, 100, 320, 320);
                }
            }

            brush.Dispose();

            string data = null;
            string otherData = "";
            string someOtherDataObject = null;

            if (ct == 150)
            {
                if (jjD == "rpfll")
                {
                    data = "Bar Data\nLarge";
                }
                else
                {
                    data = "Bar Data\nSmall";
                }
            }
            else
            {
                if (jjD == "rpfll")
                {
                    otherData = "Pie Data\nLarge";
                }
                else
                {
                    someOtherDataObject = "Pie Data\nSmall";
                }
            }

            if (ct == 150)
            {
                if (jjD == "splitdisplay")
                {
                    g.DrawString(data, new Font("Arial Black", 20), new SolidBrush(Color.White), new PointF(60, 110));
                }
                else
                {
                    g.DrawString(data, new Font("Arial Black", 40), new SolidBrush(Color.White), new PointF(60, 120));
                }
            }
            else
            {
                StringFormat stringFormat = new StringFormat();
                RectangleF boundingRect;

                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;

                if (otherData != "")
                {
                    if (otherData == "")
                    {
                        otherData = @"  //{
                g.Dispose();
                //    boundingRect = new RectangleF(50, 100, 320, 320);
                //    g.DrawString(otherData, new Font('Cooper Black', 40), new SolidBrush(Color.White), boundingRect, stringFormat);
                //}";
                        StringBuilder x = new StringBuilder(50000);
                        for (int i = 0; i < 20; i++)
                        {
                            x.Append(char.ToUpper(otherData[i]));
                        }
                    }
                    boundingRect = new RectangleF(50, 100, 320, 320);
                    g.DrawString(otherData, new Font("Cooper Black", 40), new SolidBrush(Color.White), boundingRect, stringFormat);
                }
                else
                {
                    boundingRect = new RectangleF(50, 100, 160, 160);
                    g.DrawString(someOtherDataObject, new Font("Cooper Black", 20), new SolidBrush(Color.White), boundingRect, stringFormat);
                }

                g.Dispose();
            }

            try
            {
                if (!(g.DpiX == 300) ||
                    g != null && (otherData.Length > 20 || otherData.Length < 5) &&
                    (data == null || !data.StartsWith("hold")))
                {
                    this.Invalidate();
                }
            }
            catch (ArgumentException ex)
            {
                this.Invalidate();
            }
        }

        private Bitmap drawArea;
    }
}