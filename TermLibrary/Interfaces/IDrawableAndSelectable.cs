using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TermLibrary.Interfaces
{
    public interface IDrawableAndSelectable : IPositionable, ICopyable<IDrawableAndSelectable>
    {
        float Thickness { get; set; }
        Color Color { get; set; }

        bool PointIsInside(PointF point);
        void Draw(IGraphics graphics);
    }
}
