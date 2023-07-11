namespace LinkedListPlus
{
    public partial class SortedList<T> : IViaList<T>
    {
        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public uint Count => throw new NotImplementedException();

        public bool IsEmpty => throw new NotImplementedException();

        public ViaListNode<T> Tail { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ViaListNode<T> Head { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddAfter(ViaListNode<T> node, T item)
        {
            throw new NotImplementedException();
        }

        public void AddAfter(ViaListNode<T> node, ViaListNode<T> newNode)
        {
            throw new NotImplementedException();
        }

        public void AddBefore(ViaListNode<T> node, T item)
        {
            throw new NotImplementedException();
        }

        public void AddBefore(ViaListNode<T> node, ViaListNode<T> newNode)
        {
            throw new NotImplementedException();
        }

        public void AddFirst(T item)
        {
            throw new NotImplementedException();
        }

        public void AddLast(T item)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<T> collection)
        {
            throw new NotImplementedException();
        }

        public void AddSort(T Value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public T[] CopyTo(T[] toCopy, int index)
        {
            throw new NotImplementedException();
        }

        public T[] CopyToOneDimensionalArray()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public DefaultList<ViaListNode<T>> SearchAll(T value)
        {
            throw new NotImplementedException();
        }

        public ViaListNode<T> SearchNode(T value)
        {
            throw new NotImplementedException();
        }

        public bool SerachFirst(T value)
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        ViaList<ViaListNode<T>> IViaList<T>.SearchAll(T value)
        {
            throw new NotImplementedException();
        }
    }
}
