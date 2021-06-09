using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTasks;
using System.Drawing;

namespace GeometryPainting
{
    //Напишите здесь код, который заставит работать методы segment.GetColor и segment.SetColor
    static class SegmentExtensions
    {
        public static Dictionary<Segment, Color> colors = new Dictionary<Segment, Color>();

        public static Color GetColor (this Segment segment)
        {
            bool f = false;
            foreach (Segment segment1 in colors.Keys)
            {
                if (segment1 == segment)
                    f = true;
            }
            if (f)
                return colors[segment];
            else
                return Color.Black;
        }

        public static void SetColor(this Segment segment, Color newcolor)
        {
            bool f = false;
            foreach (Segment segment1 in colors.Keys)
            {
                if (segment1 == segment)
                {
                    f = true;
                    if (colors[segment] != newcolor)
                    {
                        colors[segment] = newcolor;
                        break;
                    }
                }                   
            }
            if (!f)
            {
                colors.Add(segment, newcolor);
            }
        }
    }
}
