namespace LinkedListPlus
{
    public partial class SortedList<T> : IViaList<T> where T : IComparable
    {
        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public uint Count => throw new NotImplementedException();

        public bool IsEmpty => throw new NotImplementedException();

        public ViaListNode<T> Tail { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ViaListNode<T> Head { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsDecimalTypeList { get; init; }
        public SortedList()
        {
            IsDecimalTypeList = IsDecimalType(typeof(T));
        }
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

        public IResult AddSort(T Value)
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

        public IResult Sort()
        {
            if (IsDecimalTypeList)
            {
                //Sırala
            }
            else 
            {
                return new ErrorResult("Listeniz sıralanabilecek türden bir liste değil.");
            }
        }

        ViaList<ViaListNode<T>> IViaList<T>.SearchAll(T value)
        {
            throw new NotImplementedException();
        }
        public bool IsDecimalType(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.Int16:
                case TypeCode.UInt16:
                case TypeCode.Int32:
                case TypeCode.UInt32:
                case TypeCode.Int64:
                case TypeCode.UInt64:
                case TypeCode.Single:
                case TypeCode.Double:
                case TypeCode.Decimal:
                case TypeCode.Boolean:
                case TypeCode.Char:
                case TypeCode.DateTime:
                    return true;
                default:
                    return false;
            }
        }

        public void Validate(object? toValidate)
        {
            throw new NotImplementedException();
        }

        public void Validate(object? toValidate, object? toValidate2)
        {
            throw new NotImplementedException();
        }
    }
}
