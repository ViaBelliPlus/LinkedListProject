using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPlus
{
    public partial interface IViaList<T>
    {
        uint Count { get; }
        void AddFirst(T item);
        void AddLast(T item);
        void AddAfter(ViaListNode<T> node, T item);
        void AddAfter(ViaListNode<T> node, ViaListNode<T> newNode);
        void AddBefore(ViaListNode<T> node, T item);
        void AddBefore(ViaListNode<T> node, ViaListNode<T> newNode);
        void AddRange(IEnumerable<T> collection);
        T[] CopyTo(T[] toCopy, int index);
        T[] CopyToOneDimensionalArray();
        void Clear();
        T RemoveFirst();
        T this[int index] { get; set; }
        IResult RemoveAfter(ViaListNode<T> node);
        T RemoveLast();
        IResult RemoveBefore(ViaListNode<T> node);
        IResult RemoveAt(ViaListNode<T> node);
        IResult RemoveAtValue(T value);
        void RemoveRange(IEnumerable<T> collection);
        IResult RemoveRange(int startİndex, int endİndex);
        ViaListNode<T> SearchNode(T value);
        void RemoveAll(T value);

    }
}
