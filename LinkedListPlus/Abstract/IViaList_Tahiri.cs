using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPlus
{
    public partial interface IViaList<T>
    {
        public ViaListNode<T> Tail { get; }
        public ViaListNode<T> Head { get; }
        bool IsEmpty { get;}
        ViaList<ViaListNode<T>> SearchAll(T value);
        bool SerachFirst(T value);
        void AddSort(T Value);
        void Sort();
        IEnumerator<T> GetEnumerator();
    }
}
