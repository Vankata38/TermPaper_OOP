﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermPaper_OOP.Interfaces;

namespace TermPaper_OOP.Classes
{
    public class Circle : IPositionable, ISurface, IPerimeter, IDrawable
    {
        public Point Position;
        public decimal Radius { get; set; }

        public decimal X
        {
            get { return Position.X; }
            set { Position.X = value; }
        }

        public decimal Y
        {
            get { return Position.Y; }
            set { Position.Y = value; }
        }

        public decimal CalculatePerimeter()
        {
            return 2 * (decimal)Math.PI * Radius;
        }

        public decimal CalculateArea()
        {
            return (decimal)Math.PI * Radius * Radius;
        }

        public override string ToString()
        {
            return $"Circle at {Position} with radius of {Radius}";
        }

        public void Draw(Graphics graphics, Color color, DrawType drawType, float thickness = 1.0f) {
            if (graphics == null) return;
            
            switch (drawType)
            {
                case DrawType.Pen:
                    graphics.DrawEllipse(new Pen(color, thickness),
                        (float)Position.X, (float)Position.Y,
                        (float)Radius, (float)Radius
                    ); 
                    break;

                case DrawType.Brush:
                    graphics.FillEllipse(new SolidBrush(color),
                        (float)Position.X, (float)Position.Y,
                        (float)Radius, (float)Radius
                    );
                    break;
            }
        }
    }
}
