using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermLibrary.Interfaces;
using TermPaper_OOP.Interfaces;

namespace TermPaper_OOP.Commands
{
    public class ChangeThickness : ICommand
    {
        private readonly IDrawableAndSelectable _drawable;
        private readonly float _oldThickness;
        private readonly float _newThickness;

        public ChangeThickness(IDrawableAndSelectable drawable, float oldThickness, float newThickness)
        {
            _drawable = drawable;
            _oldThickness = oldThickness;
            _newThickness = newThickness;
        }

        public void Execute()
        {
            _drawable.Thickness = _newThickness;
            Scene._selectedObject = _drawable;
        }

        public void Undo()
        {
            _drawable.Thickness = _oldThickness;
            Scene._selectedObject = _drawable;
        }
    }
}
