using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermPaper_OOP.Interfaces;

namespace TermPaper_OOP.Classes
{
    public class Line : IPositionable, IDrawableAndSelectable
    {
        private PointF _startPoint;
        private PointF _endPoint;

        public float Thickness { get; set; }
        public Color Color { get; set; }

        public Line(float x, float y, float endX, float endY, 
                    Color color, float thickness = 1.0f)
        {
            _startPoint = new PointF(x, y);
            _endPoint = new PointF(endX, endY);
            Color = color;

            if (thickness < 1.0f) thickness = 1.0f;
            Thickness = thickness;
        }

        public Line(Line original)
        {
            _startPoint = original._startPoint;
            _endPoint = original._endPoint;
            Thickness = original.Thickness;
            Color = original.Color;
        }

        public Line(PointF startPoint, PointF endPoint,
                    Color color, float thickness = 1.0f)
        {
            _startPoint = startPoint;
            _endPoint = endPoint;
            Color = color;
            Thickness = thickness;
        }

        public IDrawableAndSelectable Copy()
        {
            return new Line(_startPoint, _endPoint, Color, Thickness);
        }

        public float X
        {
            get { return _startPoint.X; }
            set { _startPoint.X = value; }
        }

        public float Y
        {
            get { return _startPoint.Y; }
            set { _startPoint.Y = value; }
        }

        public float EndX
        {
            get { return _endPoint.X; }
            set { _endPoint.X = value; }
        }

        public float EndY
        {
            get { return _endPoint.Y; }
            set { _endPoint.Y = value; }
        }

        public override string ToString() { return $"Line starting at {_startPoint}" +
                                                   $" and ending at {_endPoint}"; }

        public bool PointIsInside(PointF current)
        {
            // Calculate the coefficients of the line equation Ax + By + C = 0
            float A = EndY - Y;
            float B = X - EndX;
            float C = EndX * Y - X * EndY;

            // Calculate the distance from the point to the line
            float distance = MathF.Abs(A * current.X + B * current.Y + C) / 
                                       MathF.Sqrt(A * A + B * B);

            // Check if the distance is within the specified Thickness
            float thickness = 5f;
            return distance <= thickness;
        }

        public void Draw(Graphics graphics)
        {
            if (graphics == null) return;

            DrawingResources.SetPen(Color, Thickness);
            graphics.DrawLine(
                DrawingResources.SharedPen,
                _startPoint,
                _endPoint
            );
        }
    }
}
