using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermPaper_OOP.Interfaces;

namespace TermPaper_OOP.Commands
{
    public class ChangeFilled : ICommand
    {
        private readonly IShape _shape;
        private readonly bool _oldFilledState;
        private readonly bool _newFilledState;

        public ChangeFilled(IDrawableAndSelectable obj, bool newFilledState)
        {
            _shape = obj as IShape ?? throw new Exception("The object is not a shape!");
            _oldFilledState = _shape.IsFilled;
            _newFilledState = newFilledState;
        }

        public void Execute()
        {
            _shape.IsFilled = _newFilledState;
            Scene._selectedObject = _shape;
        }

        public void Undo()
        {
            _shape.IsFilled = _oldFilledState;
            Scene._selectedObject = _shape;
        }
    }
}
