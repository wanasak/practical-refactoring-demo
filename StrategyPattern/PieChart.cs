using System;
using System.Drawing;
using System.Text;

namespace SGV
{
    public class PieChart
    {
        public static void RenderPieChart(Graphics g, Data data)
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
                        x.Append(Char.ToUpper(data.otherData[i]));
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

        public static Data GetPieChartData(string displayType)
        {
            Data data = new Data();
            if (displayType == ChartSingleCompareOrig.DisplayTypeFull)
            {
                data.otherData = "Pie Data\nLarge";
            }
            else
            {
                data.someOtherDataObject = "Pie Data\nSmall";
            }
            return data;
        }

        public static void RenderPieChartBackground(string displayType, Graphics g)
        {
            SolidBrush brush;
            if (displayType != ChartSingleCompareOrig.DisplayTypeFull)
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
    }
}