using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermLibrary.Interfaces
{
    public interface IGraphics
    {
        void DrawLine(PointF startPoint, PointF endPoint, float thickness, Color color);

        void DrawRectangle(float x, float y, float width, float height, float thickness, Color color);
        void FillRectangle(float x, float y, float width, float height, Color color);

        void DrawEllipse(float x, float y, float width, float height, float thickness, Color color);
        void FillEllipse(float x, float y, float width, float height, Color color);

        void DrawPath(PointF[] points, float thickness, Color color);
        void FillPath(PointF[] points, Color color);
    }
}
