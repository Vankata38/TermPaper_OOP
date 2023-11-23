using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermPaper_OOP.Interfaces;

namespace TermPaper_OOP.Classes
{
    public class Rectangle : IShape
    {
        private PointF _position;

        public bool IsFilled { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Thickness { get; set; }
        public Color Color { get; set; }

        public Rectangle(float x, float y, float width, float height, 
                         bool isFilled, Color color, float thickness = 1.0f)
        {
            _position = new PointF(x, y);
            IsFilled = isFilled;
            Width = width;
            Height = height;
            Thickness = thickness;
            Color = color;
        }

        public IDrawableAndSelectable Copy()
        {
            return new Rectangle(_position.X, _position.Y, Width, Height, IsFilled, Color, Thickness);
        }

        public float X
        {
            get { return _position.X; }
            set { _position.X = value; }
        }

        public float Y
        {
            get { return _position.Y; }
            set { _position.Y = value; }
        }

        public float CalculatePerimeter()
        {
            return 2 * (Width + Height);
        }

        public float CalculateArea()
        {
            return Width * Height;
        }

        public override string ToString()
        {
            return $"Rectangle at {_position} with width of {Width} and height of {Height}";
        }
        
        public bool PointIsInside(PointF point)
        {
            return point.X >= _position.X && point.X <= _position.X + Width 
                && point.Y >= _position.Y && point.Y <= _position.Y + Height;
        }

        public void Draw(Graphics graphics)
        {
            if (graphics == null) return;

            if (IsFilled)
            {
                DrawingResources.SetBrushColor(Color);
                graphics.FillRectangle(DrawingResources.SharedBrush,
                        _position.X, _position.Y,
                        Width, Height);
            } else
            {
                DrawingResources.SetPen(Color, Thickness);
                graphics.DrawRectangle(DrawingResources.SharedPen,
                        _position.X, _position.Y,
                        Width, Height);
            }
        }
    }
}
