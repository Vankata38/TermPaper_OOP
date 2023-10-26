using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermPaper_OOP.Interfaces
{
    public enum DrawType
    {
        Pen,
        Brush
    }

    public interface IDrawable
    {
        void Draw(Graphics graphics, Color color, DrawType drawType, float thickness);
    }
}
