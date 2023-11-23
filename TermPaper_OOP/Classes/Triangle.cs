using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermPaper_OOP.Interfaces;

namespace TermPaper_OOP.Classes
{
    public class Triangle : IShape
    {
        private PointF _leftBottom;
        private PointF _rightBottom;
        private PointF _top;
        private float _width;
        private float _height;

        public bool IsFilled { get; set; }
        public float Thickness { get; set; }
        public Color Color { get; set; }

        public Triangle(float x, float y, float width, float height,
                        bool isFilled, Color color, float thickness = 1.0f)
        {
            _leftBottom = new PointF(x, y + height);
            _rightBottom = new PointF(x + width, y + height);
            _top = new PointF(x + width / 2, y);
            _width = width;
            _height = height;
            IsFilled = isFilled;
            Thickness = thickness;
            Color = color;
        }

        public IDrawableAndSelectable Copy()
        {
            return new Triangle(_leftBottom.X, _leftBottom.Y, _width, _height, IsFilled, Color, Thickness);
        }

        public float X
        {
            get { return _leftBottom.X; }
            set { 
                _leftBottom.X = value;
                _rightBottom.X = value + _width;
                _top.X = value + _width / 2;
            }
        }

        public float Y
        {
            get { return _leftBottom.Y; }
            set {
                _leftBottom.Y = value;
                _rightBottom.Y = value;
                _top.Y = value - _height;
            }
        }

        public float Width
        {
            get { return _width; }
            set
            {
                _width = value;
                _rightBottom.X = _leftBottom.X + value;
                _top.X = _leftBottom.X + value / 2;
            }
        }

        public float Height
        {
            get { return _height; }
            set
            {
                _height = value;

                // TODO: check if this is correct
                _leftBottom.Y = _rightBottom.Y = _leftBottom.Y + value; 
            }
        }

        // Finds distance between two points, used for perimeter and area calculations
        private float CalculateDistance(PointF point1, PointF point2)
        {
            return MathF.Sqrt(MathF.Pow(point2.X - point1.X, 2) + MathF.Pow(point2.Y - point1.Y, 2));
        }

        public float CalculatePerimeter()
        {
            float side1 = CalculateDistance(_leftBottom, _rightBottom);
            float side2 = CalculateDistance(_rightBottom, _top);
            float side3 = CalculateDistance(_top, _leftBottom);

            return side1 + side2 + side3;
        }

        public float CalculateArea()
        {
            float side1 = CalculateDistance(_leftBottom, _rightBottom);
            float side2 = CalculateDistance(_rightBottom, _top);
            float side3 = CalculateDistance(_top, _leftBottom);

            float s = (side1 + side2 + side3) / 2;
            return MathF.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
        }

        public override string ToString()
        {
            return $"Rectangle at {_leftBottom} with right bottom at {_rightBottom} and top at {_top}";
        }

        public bool PointIsInside(PointF point)
        {
            float u, v, w;
            CalculateBarycentricCoordinates(point, out u, out v, out w);

            // Check if all barycentric coordinates are between 0 and 1
            return u >= 0 && v >= 0 && w >= 0 && u <= 1 && v <= 1 && w <= 1;
        }

        private void CalculateBarycentricCoordinates(PointF point, out float u, out float v, out float w)
        {
            // Calculate the barycentric coordinates using the formula
            float detT = (_rightBottom.Y - _top.Y) * (_leftBottom.X - _top.X) + (_top.X - _rightBottom.X) * (_leftBottom.Y - _top.Y);
            u = ((_rightBottom.Y - _top.Y) * (point.X - _top.X) + (_top.X - _rightBottom.X) * (point.Y - _top.Y)) / detT;
            v = ((_top.Y - _leftBottom.Y) * (point.X - _top.X) + (_leftBottom.X - _top.X) * (point.Y - _top.Y)) / detT;
            w = 1 - u - v;
        }

        public void Draw(Graphics graphics)
        {
            if (graphics == null) return;

            GraphicsPath path = new GraphicsPath();
            path.AddLines(new PointF[] { _leftBottom, _rightBottom, _top, _leftBottom });

            if (IsFilled)
            {
                DrawingResources.SetBrushColor(Color);
                graphics.FillPath(DrawingResources.SharedBrush, path);
            } else
            {
                DrawingResources.SetPen(Color, Thickness);
                graphics.DrawPath(DrawingResources.SharedPen, path);
            }
        }
    }
}
