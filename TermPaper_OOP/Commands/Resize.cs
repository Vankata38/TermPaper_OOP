using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermPaper_OOP.Interfaces;
using TermPaper_OOP.Classes;

namespace TermPaper_OOP.Commands
{
    public class Resize : ICommand
    {
        private readonly IDrawableAndSelectable _object;
        private readonly SizeF _oldSize;
        private readonly SizeF _newSize;

        public Resize(IDrawableAndSelectable obj, SizeF newSize)
        {
            _object = obj;

            if (_object is IShape shape)
            {
                _oldSize = new SizeF(shape.Width, shape.Height);
            }

            if (_object is Line line)
            {
                _oldSize = new SizeF(line.EndX, line.EndY);
            }

            _newSize = newSize;
        }

        public void Execute()
        {
            if (_object is IShape shape)
            {
                shape.Width = _newSize.Width;

                if (shape is not Circle)
                    shape.Height = _newSize.Height;

                Scene._selectedObject = shape;
            }

            if (_object is Line line)
            {
                line!.EndX = _newSize.Width;
                line!.EndY = _newSize.Height;

                Scene._selectedObject = line;
            }
        }

        public void Undo()
        {
            if (_object is IShape shape)
            {
                shape.Width = _oldSize.Width;

                if (shape is not Circle)
                    shape.Height = _oldSize.Height;

                Scene._selectedObject = shape;
            }

            if (_object is Line line)
            {
                line!.EndX = _oldSize.Width;
                line!.EndY = _oldSize.Height;

                Scene._selectedObject = line;
            }
        }
    }
}
