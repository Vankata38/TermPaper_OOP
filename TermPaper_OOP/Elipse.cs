using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermPaper_OOP
{
    public class Elipse : VectorObject
    {
        public float Height { get; set; }
        public float Width { get; set; }

        public Elipse(float x, float y, float height, float width, Color color) 
            : base(x, y, color)
        {
            Height = height;
            Width = width;
        }

        public override float Perimeter()
        {
            return 2 * MathF.PI * MathF.Sqrt((MathF.Pow(Height, 2) + MathF.Pow(Width, 2)) / 2);
        }

        public override float Area()
        {
            return MathF.PI * (Height / 2) * (Width / 2);
        }

        public override void Draw(Graphics graph)
        {
            graph.DrawEllipse(Pen, X, Y, Width, Height);
        }
    }
}
