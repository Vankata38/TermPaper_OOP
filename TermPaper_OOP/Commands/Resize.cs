using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermPaper_OOP.Interfaces;

namespace TermPaper_OOP.Commands
{
    public class ResizeCommand : ICommand
    {
        private readonly IResizable _resizable;
        private readonly SizeF _oldSize;
        private readonly SizeF _newSize;

        public ResizeCommand(IDrawableAndSelectable obj, SizeF newSize)
        {
            _resizable = obj as IResizable ?? throw new Exception("Object is not resizable");

            _oldSize = new SizeF(_resizable.Width, _resizable.Height);
            _newSize = newSize;
        }

        public void Execute()
        {
            _resizable.Width = _newSize.Width;
            _resizable.Height = _newSize.Height;

            Scene._selectedObject = _resizable as IDrawableAndSelectable;
        }

        public void Undo()
        {
            _resizable.Width = _oldSize.Width;
            _resizable.Height = _oldSize.Height;

            Scene._selectedObject = _resizable as IDrawableAndSelectable;
        }
    }
}
