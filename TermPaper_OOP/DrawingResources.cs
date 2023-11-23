using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermPaper_OOP
{
    public static class DrawingResources
    {
        public static Brush SharedBrush { get; private set; } = new SolidBrush(Color.Black);
        public static Pen SharedPen { get; private set; } = new Pen(Color.Black);

        public static void SetBrushColor(Color color)
        {
            SharedBrush = new SolidBrush(color);
        }

        public static void SetPen(Color color, float thickness)
        {
            SharedPen.Color = color;
            SharedPen.Width = thickness;
        }
    }
}
