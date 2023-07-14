namespace LinkedListPlus
{
    public partial class SortedList<T> : AbsViaList<T>
    {
        public SortedList()
        {
            if (!typeof(T).GetInterfaces().Contains(typeof(IComparable)))
            {
                throw new ArgumentException("İlgili T tipi bir IComparable değildir! ");
            }
            #region Alternatif Yöntem(Not Üsteki daha sağlam)
            //Burada string tipleri ayrıca kontrol etmemiz string türlerin parametris bir constructur yapısına sahip olamamsından kaynaklanır. Çünkü Activator.CreateInstance parametresi olmayan constructorları kullanarak bir instance oluşturmayı dener.
            //if (typeof(T) != typeof(string) && !(Activator.CreateInstance<T>() is IComparable)) //İligli tipin bir nesnesini oluşturu ve bunun bir IComparable olup olmadığını kontrol eder.
            //{
            //    throw new ArgumentException("İlgili T tipi bir IComparable değildir! ");
            //}
            #endregion
        }
        public override void AddAfter(ViaListNode<T> node, T item)
        {
            AddSort(item);
        }

        public override void AddAfter(ViaListNode<T> node, ViaListNode<T> newNode)
        {
            AddSort(newNode.Value);
        }

        public override void AddBefore(ViaListNode<T> node, T item)
        {
            AddSort(item);
        }

        public override void AddBefore(ViaListNode<T> node, ViaListNode<T> newNode)
        {
            AddSort(newNode.Value);
        }

        public override IResult AddFirst(T item)
        {
            return AddSort(item);
        }

        public override void AddLast(T item)
        {
            AddSort(item);
        }

        public override void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                AddSort(item);
            }
        }
        private IResult AddSort(T value)
        {
            if (value is IComparable comparableValue)
            {
                Validate(value);
                var newNode = new ViaListNode<T>(value);

                if (Head == null && Tail == null)
                {
                    Head = newNode;
                    Tail = newNode;
                    return new SuccessResult();
                }

                if (comparableValue.CompareTo(Tail.Value) > 0)
                {
                    Tail.Next = newNode;
                    newNode.Back = Tail;
                    Tail = newNode;
                    return new SuccessResult();
                }
                else if (comparableValue.CompareTo(Head.Value) < 0)
                {
                    newNode.Next = Head;
                    Head.Back = newNode;
                    Head = newNode;
                }
                else
                {
                    var ptr = Head.Next;
                    while (ptr != null)
                    {
                        if (((IComparable<T>)ptr.Value).CompareTo(value) < 0)
                        {
                            ptr = ptr.Next;
                        }
                        else
                        {
                            ptr.Back.Next = newNode;
                            newNode.Back = ptr.Back;
                            ptr.Back = newNode;
                            newNode.Next = ptr;
                            return new SuccessResult();
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException("Value must implement IComparable<T>", nameof(value));
            }

            return new ErrorResult();
        }

    }
}
