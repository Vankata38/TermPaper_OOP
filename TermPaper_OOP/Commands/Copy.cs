using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermLibrary.Classes;
using TermLibrary.Interfaces;
using TermPaper_OOP.Interfaces;

namespace TermPaper_OOP.Commands
{
    public class Copy : ICommand
    {
        private readonly List<IDrawableAndSelectable> _list = Scene.Objects;
        private IDrawableAndSelectable _copy;
        private readonly PointF _position;

        public Copy(IDrawableAndSelectable obj, PointF position)
        {
            _copy = obj.Copy();
            _position = position;
        }   

        public void Execute()
        {
            if (_copy is Line)
            {
                var line = _copy as Line;

                line!.EndX = line.EndX - (line.X - _position.X);
                line!.EndY = line.EndY - (line.Y - _position.Y);

                _copy = line;
            }

            _copy.X = _position.X;
            _copy.Y = _position.Y;

            Scene._selectedObject = _copy;
            _list.Add(_copy);
        }

        public void Undo()
        {
            _list.Remove(_copy);
        }
    }
}
