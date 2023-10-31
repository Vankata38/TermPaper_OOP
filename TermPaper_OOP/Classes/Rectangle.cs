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
        private Point Position;
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public Color Color { get; set; }

        public Rectangle(decimal x, decimal y, decimal width, decimal height, Color color)
        {
            Position = new Point(x, y);
            Width = width;
            Height = height;
            Color = color;
        }

        decimal IPositionable.X
        {
            get { return Position.X; }
            set { Position.X = value; }
        }

        decimal IPositionable.Y
        {
            get { return Position.Y; }
            set { Position.Y = value; }
        }

        public decimal CalculatePerimeter()
        {
            return 2 * (Width + Height);
        }

        public decimal CalculateArea()
        {
            return Width * Height;
        }

        public override string ToString()
        {
            return $"Rectangle at {Position} with width of {Width} and height of {Height}";
        }

        public void Draw(Graphics graphics, DrawType drawType, float thickness)
        {
            if (graphics == null) return;

            switch (drawType)
            {
                case DrawType.Pen:
                    graphics.DrawRectangle(new Pen(Color, thickness),
                        (float)X, (float)Y,
                        (float)Width, (float)Height);
                    break;

                case DrawType.Brush:
                    graphics.FillRectangle(new SolidBrush(Color),
                        (float)X, (float)Y,
                        (float)Width, (float)Height);
                    break;
            }
        }
    }
}
