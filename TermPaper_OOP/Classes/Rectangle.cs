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
        private PointF Position;
        public float Width { get; set; }
        public float Height { get; set; }
        public Color Color { get; set; }

        public Rectangle(float x, float y, float width, float height, Color color)
        {
            Position = new PointF(x, y);
            Width = width;
            Height = height;
            Color = color;
        }

        public float X
        {
            get { return Position.X; }
            set { Position.X = value; }
        }

        public float Y
        {
            get { return Position.Y; }
            set { Position.Y = value; }
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
            return $"Rectangle at {Position} with width of {Width} and height of {Height}";
        }
        
        public bool pointIsInside(PointF point)
        {
            return point.X >= Position.X && point.X <= Position.X + Width 
                && point.Y >= Position.Y && point.Y <= Position.Y + Height;
        }

        public void Draw(Graphics graphics, DrawType drawType, float thickness)
        {
            if (graphics == null) return;

            switch (drawType)
            {
                case DrawType.Pen:
                    graphics.DrawRectangle(new Pen(Color, thickness),
                        Position.X, Position.Y,
                        Width, Height);
                    break;

                case DrawType.Brush:
                    graphics.FillRectangle(new SolidBrush(Color),
                        Position.X, Position.Y,
                        Width, Height);
                    break;
            }
        }
    }
}
