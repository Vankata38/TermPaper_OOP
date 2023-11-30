using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermPaper_OOP.Interfaces;

namespace TermPaper_OOP.Commands
{
    public class Draw : ICommand
    {
        private readonly List<IDrawableAndSelectable> _list = Scene.Objects;
        private readonly IDrawableAndSelectable _drawable;

        public Draw(IDrawableAndSelectable drawable)
        {
            _drawable = drawable;
        }

        public void Execute()
        {
            _list.Add(_drawable);
            Scene._selectedObject = _drawable;
        }

        public void Undo()
        {
            _list.Remove(_drawable);
        }
    }
}
