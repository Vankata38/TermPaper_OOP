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
        private PointF StartPoint;
        private PointF EndPoint;
        public Color Color { get; set; }

        public Line(float x, float y, float endX, float endY, Color color) {
            StartPoint = new PointF(x, y);
            EndPoint = new PointF(endX, endY);
            Color = color;
        }

        public float X
        {
            get { return StartPoint.X; }
            set { StartPoint.X = value; }
        }

        public float Y
        {
            get { return StartPoint.Y; }
            set { StartPoint.Y = value; }
        }

        public float EndX
        {
            get { return EndPoint.X; }
            set { EndPoint.X = value; }
        }

        public float EndY
        {
            get { return EndPoint.Y; }
            set { EndPoint.Y = value; }
        }

        public override string ToString() { return $"Line starting at {StartPoint} and ending at {EndPoint}"; }

        public bool pointIsInside(PointF current)
        {
            // Calculate the coefficients of the line equation Ax + By + C = 0
            float A = EndY - Y;
            float B = X - EndX;
            float C = EndX * Y - X * EndY;

            // Calculate the distance from the point to the line
            float distance = MathF.Abs(A * current.X + B * current.Y + C) / MathF.Sqrt(A * A + B * B);

            // Check if the distance is within the specified thickness
            float thickness = 5f;
            return distance <= thickness;
        }

        public void Draw(Graphics graphics, DrawType drawType, float thickness)
        {
            if (graphics == null) return;
            if (drawType != DrawType.Pen) return;

            graphics.DrawLine(
                new Pen(Color, thickness),
                new PointF(StartPoint.X, StartPoint.Y),
                new PointF(EndPoint.X, EndPoint.Y)
            );
        }
    }
}
