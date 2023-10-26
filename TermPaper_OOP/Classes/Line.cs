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
        public Point StartPoint;
        public Point EndPoint;

        public Line(decimal x, decimal y, decimal endX, decimal endY) {
            StartPoint = new Point(x, y);
            EndPoint = new Point(endX, endY);
        }

        public decimal X
        {
            get { return StartPoint.X; }
            set { StartPoint.X = value; }
        }

        public decimal Y
        {
            get { return StartPoint.Y; }
            set { StartPoint.Y = value; }
        }

        public decimal EndX
        {
            get { return EndPoint.X; }
            set { EndPoint.X = value; }
        }

        public decimal EndY
        {
            get { return EndPoint.Y; }
            set { EndPoint.Y = value; }
        }

        public override string ToString() { return $"Line starting at {StartPoint} and ending at {EndPoint}"; }

        public void Draw(Graphics graphics, Color color, DrawType drawType, float thickness = 1.0f)
        {
            if (graphics == null) return;
            if (drawType != DrawType.Pen) return;

            graphics.DrawLine(
                new Pen(color, thickness),
                new PointF((float)StartPoint.X, (float)StartPoint.Y),
                new PointF((float)EndPoint.X, (float)EndPoint.Y)
            );
        }
    }
}
