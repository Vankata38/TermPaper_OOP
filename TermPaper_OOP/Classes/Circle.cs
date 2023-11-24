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
        private PointF _position;

        public bool IsFilled { get; set; }
        public float Radius { get; set; }
        public float Thickness { get; set; }
        public Color Color { get; set; }

        public Circle(float x, float y, float radius, bool isFilled, 
                      Color color, float thickness = 1.0f)
        {
            _position = new PointF(x, y);
            IsFilled = isFilled;
            Radius = radius;
            Thickness = thickness;
            Color = color;
        }

        public IDrawableAndSelectable Copy()
        {
            return new Circle(_position.X, _position.Y, Radius, IsFilled, Color, Thickness);
        }

        float IPositionable.X
        {
            get { return _position.X; }
            set { _position.X = value; }
        }

        float IPositionable.Y
        {
            get { return _position.Y; }
            set { _position.Y = value; }
        }

        public float Width { get => Radius; set => Radius = value; }
        public float Height { get => Radius; set => Radius = value; }

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
            return $"Circle at {_position} with radius of {Radius}";
        }

        // TODO: - Fix a bug where the circle is selected with the mouse outside of it
        public bool PointIsInside(PointF point)
        {
            return MathF.Sqrt(MathF.Pow(point.X - _position.X, 2) + 
                   MathF.Pow(point.Y - _position.Y, 2)) <= Radius;
        }

        public void Draw(Graphics graphics) {
            if (graphics == null) return;
            
            if (IsFilled) {
                DrawingResources.SetBrushColor(Color);
                graphics.FillEllipse(DrawingResources.SharedBrush, _position.X, _position.Y, Radius, Radius);
            } else
            {
                DrawingResources.SetPen(Color, Thickness);
                graphics.DrawEllipse(DrawingResources.SharedPen, _position.X, _position.Y, Radius, Radius);
            }
        }
    }
}
