using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPlus
{
    public interface IRegular<T> : IViaList
    {
        void AddFirst(T Value);
    }
}
