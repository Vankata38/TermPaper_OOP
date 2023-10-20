using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermPaper_OOP
{
    public abstract class VectorObject
    {
        private float X { get; set; }
        private float Y { get; set; }

        public VectorObject(float x, float y)
        {
            X = x;
            Y = y;
        }

        public abstract void Perimeter();
        public abstract void Area();
        public abstract void Draw();
    }
}
