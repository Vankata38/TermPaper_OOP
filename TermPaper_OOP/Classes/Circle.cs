using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermPaper_OOP.Interfaces;

namespace TermPaper_OOP.Classes
{
    public class Circle : IShape
    {
        private PointF Position;
        public float Radius { get; set; }
        public Color Color { get; set; }

        public Circle(float x, float y, float radius, Color color)
        {
            Position = new PointF(x, y);
            Radius = radius;
            Color = color;
        }

        float IPositionable.X
        {
            get { return Position.X; }
            set { Position.X = value; }
        }

        float IPositionable.Y
        {
            get { return Position.Y; }
            set { Position.Y = value; }
        }

        public float CalculatePerimeter()
        {
            return 2 * MathF.PI * Radius;
        }

        public float CalculateArea()
        {
            return MathF.PI * Radius * Radius;
        }

        public override string ToString()
        {
            return $"Circle at {Position} with radius of {Radius}";
        }

        public bool pointIsInside(PointF point)
        {
            return MathF.Sqrt(MathF.Pow(point.X - Position.X, 2) + 
                   MathF.Pow(point.Y - Position.Y, 2)) <= Radius;
        }

        public void Draw(Graphics graphics, DrawType drawType, float thickness) {
            if (graphics == null) return;
            
            switch (drawType)
            {
                case DrawType.Pen:
                    graphics.DrawEllipse(new Pen(Color, thickness),
                        Position.X, Position.Y,
                        Radius, Radius
                    ); 
                    break;

                case DrawType.Brush:
                    graphics.FillEllipse(new SolidBrush(Color),
                        Position.X, Position.Y,
                        Radius, Radius
                    );
                    break;
            }
        }
    }
}
