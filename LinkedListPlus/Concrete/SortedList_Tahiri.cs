namespace LinkedListPlus
{
    public partial class SortedList<T> : AbsViaList<T>
    {
        public override bool IsDecimalTypeList { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
        public SortedList()
        {
            
        }
        public override void AddAfter(ViaListNode<T> node, T item)
        {
            throw new NotImplementedException();
        }

        public override void AddAfter(ViaListNode<T> node, ViaListNode<T> newNode)
        {
            throw new NotImplementedException();
        }

        public override void AddBefore(ViaListNode<T> node, T item)
        {
            throw new NotImplementedException();
        }

        public override void AddBefore(ViaListNode<T> node, ViaListNode<T> newNode)
        {
            throw new NotImplementedException();
        }

        public override void AddFirst(T item)
        {
            throw new NotImplementedException();
        }

        public override void AddLast(T item)
        {
            throw new NotImplementedException();
        }

        public override void AddRange(IEnumerable<T> collection)
        {
            throw new NotImplementedException();
        }

        public override IResult Sort()
        {
            throw new NotImplementedException();
        }
        public override IResult AddSort(T Value)
        {
            return base.AddSort(Value);
        }
    }
}
