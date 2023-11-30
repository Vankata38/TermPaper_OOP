using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermPaper_OOP.Interfaces;

namespace TermPaper_OOP.Commands
{
    public class ChangeColor : ICommand
    {
        private readonly IDrawableAndSelectable _object;
        private readonly Color _oldColor;
        private readonly Color _newColor;

        public ChangeColor(IDrawableAndSelectable obj, Color newColor)
        {
            _object = obj;
            _oldColor = _object.Color;
            _newColor = newColor;
        }

        public void Execute()
        {
            _object.Color = _newColor;
            Scene._selectedObject = _object;
        }

        public void Undo()
        {
            _object.Color = _oldColor;
            Scene._selectedObject = _object;
        }
    }
}
