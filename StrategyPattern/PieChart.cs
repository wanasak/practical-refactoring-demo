using System;
using System.Drawing;
using System.Text;

namespace SGV
{
    public class PieChart : IChart
    {
        public void Render(string displayType, Graphics g, Data data)
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

        public Data GetData(string displayType)
        {
            Data data = new Data();
            if (displayType == ChartSingleCompareOrig.DisplayType.Full)
            {
                data.otherData = "Pie Data\nLarge";
            }
            else
            {
                data.someOtherDataObject = "Pie Data\nSmall";
            }
            return data;
        }

        public void RenderBackground(string displayType, Graphics g)
        {
            SolidBrush brush;
            if (displayType != ChartSingleCompareOrig.DisplayType.Full)
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