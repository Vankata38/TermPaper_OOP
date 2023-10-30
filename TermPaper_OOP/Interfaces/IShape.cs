using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermPaper_OOP.Interfaces
{
    public interface IShape : IPositionable, IDrawable
    {
        decimal CalculatePerimeter();
        decimal CalculateArea();
    }
}
