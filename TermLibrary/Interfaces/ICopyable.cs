using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermLibrary.Interfaces
{
    public interface ICopyable<T>
    {
        T Copy();
    }
}
