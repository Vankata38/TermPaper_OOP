using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermLibrary.Classes;
using TermLibrary.Interfaces;
using TermPaper_OOP.Interfaces;

namespace TermPaper_OOP.Classes
{
    public class DrawHandler : IGraphics
    {
        Graphics graphics;
        public DrawHandler(Graphics graph)
        {
            graphics = graph;
        }

        public void DrawLine(PointF startPoint, PointF endPoint, float thickness, Color color)
        {
            DrawingResources.SetPen(color, thickness);
            graphics.DrawLine(DrawingResources.SharedPen, startPoint, endPoint);
        }

        public void DrawRectangle(float x, float y, float width, float height, float thickness, Color color)
        {
            DrawingResources.SetPen(color, thickness);
            graphics.DrawRectangle(DrawingResources.SharedPen, x, y, width, height);
        }

        public void FillRectangle(float x, float y, float width, float height, Color color)
        {
            DrawingResources.SetBrushColor(color);
            graphics.FillRectangle(DrawingResources.SharedBrush, x, y, width, height);
        }

        public void DrawEllipse(float x, float y, float width, float height, float thickness, Color color)
        {
            DrawingResources.SetPen(color, thickness);
            graphics.DrawEllipse(DrawingResources.SharedPen, x, y, width, height);
        }

        public void FillEllipse(float x, float y, float width, float height, Color color)
        {
            DrawingResources.SetBrushColor(color);
            graphics.FillEllipse(DrawingResources.SharedBrush, x, y, width, height);
        }

        public void DrawPath(PointF[] points, float thickness, Color color)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLines(points);

            DrawingResources.SetPen(color, thickness);
            graphics.DrawPath(DrawingResources.SharedPen, path);
        }

        public void FillPath(PointF[] points, Color color)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLines(points);

            DrawingResources.SetBrushColor(color);
            graphics.FillPath(DrawingResources.SharedBrush, path);
        }
    }
}
