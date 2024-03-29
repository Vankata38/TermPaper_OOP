﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermLibrary.Classes;
using TermLibrary.Interfaces;
using TermPaper_OOP.Interfaces;

namespace TermPaper_OOP.Commands
{
    public class Move : ICommand
    {
        private IDrawableAndSelectable _object;
        private readonly PointF _oldPosition;
        private readonly PointF _newPosition;

        public Move(IDrawableAndSelectable obj, PointF oldPosition ,PointF newPosition)
        {
            _object = obj;
            _oldPosition = oldPosition;
            _newPosition = newPosition;
        }   

        public void Execute()
        {
            if (_object is Line)
            {
                var line = _object as Line;

                line!.EndX = line.EndX - (line.X - _newPosition.X);
                line!.EndY = line.EndY - (line.Y - _newPosition.Y);

                _object = line;
            }

            _object.X = _newPosition.X;
            _object.Y = _newPosition.Y;

            Scene._selectedObject = _object;
        }

        public void Undo()
        {
            if (_object is Line)
            {
                var line = _object as Line;

                line!.EndX = line.EndX - (line.X - _oldPosition.X);
                line!.EndY = line.EndY - (line.Y - _oldPosition.Y);

                _object = line;
            }

            _object.X = _oldPosition.X;
            _object.Y = _oldPosition.Y;

            Scene._selectedObject = _object;
        }
    }
}
