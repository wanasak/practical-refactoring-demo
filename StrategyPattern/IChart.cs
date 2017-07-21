using System.Drawing;

namespace SGV
{
    public interface IChart
    {
        void RenderBackground(string displayType, Graphics g);
        Data GetData(string displayType);
        void Render(string displayType, Graphics p1, Data data);
    }
}