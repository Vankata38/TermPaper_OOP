using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TermPaper_OOP.Interfaces;

namespace TermPaper_OOP.Classes
{
    [Serializable]
    public class Circle : IShape
    {
        private PointF _position;

        public bool IsFilled { get; set; }
        public float Radius { get; set; }
        public float Thickness { get; set; }

        [XmlIgnore]
        public Color Color { get; set; }

        [XmlElement("Color")]
        public int ColorAsArgb
        {
            get { return Color.ToArgb(); }
            set { Color = Color.FromArgb(value); }
        }

        public Circle() { }
        public Circle(float x, float y, float radius, bool isFilled, 
                      Color color, float thickness = 1.0f)
        {
            _position = new PointF(x - Radius / 2, y - radius / 2);
            IsFilled = isFilled;
            Radius = radius;
            Thickness = thickness;
            Color = color;
        }

        public IDrawableAndSelectable Copy()
        {
            return new Circle(_position.X, _position.Y, Radius, IsFilled, Color, Thickness);
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

        public float Width { 
            get => Radius;
            set
            {
                _position.X -= Radius / 2;
                _position.Y += Radius / 2;
                Radius = value;
                _position.X += Radius / 2;
                _position.Y -= Radius / 2;
            }
        }
        public float Height {
            get => Radius;
            set 
            {
                _position.X += Radius / 2;
                _position.Y += Radius / 2;
                Radius = value;
                _position.X -= Radius / 2;
                _position.Y -= Radius / 2;
            } 
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
            return $"Circle at {_position} with radius of {Radius}";
        }

        public bool PointIsInside(PointF point)
        {
            return MathF.Sqrt(MathF.Pow(point.X - _position.X, 2) +
                   MathF.Pow(point.Y - _position.Y, 2)) <= Radius;
        }

        public void Draw(Graphics graphics) {
            if (graphics == null) return;
            
            if (IsFilled) {
                DrawingResources.SetBrushColor(Color);
                graphics.FillEllipse(DrawingResources.SharedBrush, _position.X, _position.Y - Radius / 2, Radius, Radius);
            } else
            {
                DrawingResources.SetPen(Color, Thickness);
                graphics.DrawEllipse(DrawingResources.SharedPen, _position.X, _position.Y - Radius / 2, Radius, Radius);
            }
        }
    }
}
