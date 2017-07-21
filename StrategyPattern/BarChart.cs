using System.Drawing;

namespace SGV
{
    public class BarChart : IChart
    {
        public void Render(string displayType, Graphics g, Data data)
        {
            if (displayType == ChartSingleCompareOrig.DisplayType.Split)
            {
                g.DrawString(data.data, new Font("Arial Black", 20), new SolidBrush(Color.White), new PointF(60, 110));
            }
            else
            {
                g.DrawString(data.data, new Font("Arial Black", 40), new SolidBrush(Color.White), new PointF(60, 120));
            }
        }

        public Data GetData(string displayType)
        {
            Data data = new Data();
            if (displayType == ChartSingleCompareOrig.DisplayType.Full)
            {
                data.data = "Bar Data\nLarge";
            }
            else
            {
                data.data = "Bar Data\nSmall";
            }
            return data;
        }

        public void RenderBackground(string displayType, Graphics g)
        {
            SolidBrush brush;
            if (displayType == ChartSingleCompareOrig.DisplayType.Full)
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
    }
}