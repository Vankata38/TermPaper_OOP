using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermPaper_OOP.Interfaces;

namespace TermPaper_OOP.Commands
{
    public class CommandManager
    {
        private static int _stackSize = 50;
        private Stack<ICommand> _undoStack = new Stack<ICommand>(_stackSize);
        private Stack<ICommand> _redoStack = new Stack<ICommand>(_stackSize);

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _undoStack.Push(command);
        }

        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                var command = _undoStack.Pop();
                command.Undo();
                _redoStack.Push(command);
            }
        }

        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                var command = _redoStack.Pop();
                ExecuteCommand(command);
            }
        }

        public void Clear()
        {
            _undoStack.Clear();
            _redoStack.Clear();
        }
    }
}
