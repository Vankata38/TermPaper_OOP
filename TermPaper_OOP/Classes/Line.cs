using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermPaper_OOP.Interfaces;

namespace TermPaper_OOP.Classes
{
    public class Line : IPositionable
    {
        public Point StartPoint;
        public Point EndPoint;

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
    }
}
