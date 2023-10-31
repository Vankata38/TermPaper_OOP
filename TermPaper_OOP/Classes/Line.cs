using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermPaper_OOP.Interfaces;

namespace TermPaper_OOP.Classes
{
    public class Line : IPositionable, IDrawable
    {
        private Point StartPoint;
        private Point EndPoint;
        public Color Color { get; set; }

        public Line(decimal x, decimal y, decimal endX, decimal endY, Color color) {
            StartPoint = new Point(x, y);
            EndPoint = new Point(endX, endY);
            Color = color;
        }

        decimal IPositionable.X
        {
            get { return StartPoint.X; }
            set { StartPoint.X = value; }
        }

        decimal IPositionable.Y
        {
            get { return StartPoint.Y; }
            set { StartPoint.Y = value; }
        }

        // TODO: Fix the implementation
        public decimal EndX
        {
            get { return EndPoint.X; }
            set { EndPoint.X = value; }
        }

        // TODO: Fix the implementation
        public decimal EndY
        {
            get { return EndPoint.Y; }
            set { EndPoint.Y = value; }
        }

        public override string ToString() { return $"Line starting at {StartPoint} and ending at {EndPoint}"; }

        public void Draw(Graphics graphics, DrawType drawType, float thickness)
        {
            if (graphics == null) return;
            if (drawType != DrawType.Pen) return;

            graphics.DrawLine(
                new Pen(Color, thickness),
                new PointF((float)StartPoint.X, (float)StartPoint.Y),
                new PointF((float)EndPoint.X, (float)EndPoint.Y)
            );
        }
    }
}
