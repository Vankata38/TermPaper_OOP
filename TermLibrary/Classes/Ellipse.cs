using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TermLibrary.Interfaces;
using System.Drawing;

namespace TermLibrary.Classes
{
    public class Ellipse : IShape
    {
        private PointF _position;
        public bool IsFilled { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Thickness { get; set; }

        [XmlIgnore]
        public Color Color { get; set; }

        [XmlElement("Color")]
        public int ColorAsArgb
        {
            get { return Color.ToArgb(); }
            set { Color = Color.FromArgb(value); }
        }

        public Ellipse() { }
        public Ellipse(float x, float y, float width, float height, bool isFilled,
                      Color color, float thickness = 1.0f)
        {
            _position = new PointF(x - width / 2, y - height / 2);
            IsFilled = isFilled;
            Width = width;
            Height = Height;
            Thickness = thickness;
            Color = color;
        }

        public IDrawableAndSelectable Copy()
        {
            return new Ellipse(_position.X, _position.Y, Width, Height, IsFilled, Color, Thickness);
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
            return MathF.PI * (3 / 2 * (Width / 2 + Height / 2) 
                - MathF.Sqrt(Width / 2 * Height / 2));
        }

        public float CalculateArea()
        {
            return MathF.PI * Width / 2 * Height / 2;
        }

        public override string ToString()
        {
            return $"Ellipse at {_position} with width of {Width} and height of {Height}";
        }

        //(x-h)^2/a^2 + (y-k)^2/b^2 <= 1
        public bool PointIsInside(PointF point)
        {
            return (MathF.Pow((point.X - _position.X), 2) / MathF.Pow((Width / 2), 2))
                + MathF.Pow((point.Y - _position.Y), 2) / MathF.Pow(Height / 2, 2) <= 1;
        }

        public void Draw(IGraphics graphics)
        {
            if (IsFilled)
                graphics.FillEllipse(_position.X - Width / 2, _position.Y - Height / 2, Width, Height, Color);
            else
                graphics.DrawEllipse(_position.X - Width / 2, _position.Y - Height / 2, Width, Height, Thickness, Color);
        }
    }
}
