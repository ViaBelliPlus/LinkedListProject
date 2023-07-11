using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPlus
{
    public class ViaList<T> : IEnumerable<T>
    {
        public readonly IViaList<T> _viaList;
        public ViaListNode<T> Head => _viaList.Head;
        public ViaListNode<T> Tail => _viaList.Tail;
        public T this[int index] { get => _viaList[index]; set => _viaList[index] = value; }

        public uint Count => _viaList.Count;

        public bool IsEmpty => _viaList.IsEmpty;
        public bool IsDecimalTypeList { get;}
        public ViaList(TypeList type = TypeList.DefaultList)
        {
            IsDecimalTypeList = IsDecimalType(typeof(T));
            if(type == TypeList.DefaultList)
            {
                _viaList = new DefaultList<T>();
            }
            else
            {
                _viaList = new SortedList<T>();
            }
        }
        public ViaList(params T[] initial) : this()
        {
            foreach(T value in initial)
            {
                _viaList.AddFirst(value);
            }
        }
        public ViaList(IEnumerable<T> collection, TypeList type = TypeList.DefaultList) : this(type)
        {
            foreach (T value in collection)
            {
                _viaList.AddFirst(value);
            }
        }
        public void AddAfter(ViaListNode<T> node, T item)
        {
            _viaList.AddAfter(node, item);
        }

        public void AddAfter(ViaListNode<T> node, ViaListNode<T> newNode)
        {
            _viaList.AddAfter(node, newNode);
        }

        public void AddBefore(ViaListNode<T> node, T item)
        {
           _viaList.AddBefore(node, item);
        }

        public void AddBefore(ViaListNode<T> node, ViaListNode<T> newNode)
        {
            _viaList.AddBefore(node, newNode);
        }

        public void AddFirst(T item)
        {
            _viaList.AddFirst(item);
        }

        public void AddLast(T item)
        {
            _viaList.AddLast(item);
        }

        public void AddRange(IEnumerable<T> collection)
        {
            _viaList.AddRange(collection);
        }

        public void AddSort(T Value)
        {
            _viaList.AddSort(Value);
        }

        public void Clear()
        {
            _viaList.Clear();
        }

        public T[] CopyTo(T[] toCopy, int index)
        {
            return _viaList.CopyTo(toCopy, index);
        }

        public T[] CopyToOneDimensionalArray()
        {
            return _viaList.CopyToOneDimensionalArray();
        }

        public void RemoveAfter(ViaListNode<T> node)
        {
            _viaList.RemoveAfter(node);
        }

        public void RemoveAt(ViaListNode<T> node)
        {
            _viaList.RemoveAt(node);
        }

        public void RemoveAtValue(T value)
        {
           _viaList.RemoveAtValue(value);
        }

        public void RemoveBefore(ViaListNode<T> node)
        {
            _viaList.RemoveBefore(node);
        }

        public T RemoveFirst()
        {
           return _viaList.RemoveFirst();
        }

        public T RemoveLast()
        {
            return _viaList.RemoveLast();
        }

        public ViaList<ViaListNode<T>> SearchAll(T value)
        {
            return _viaList.SearchAll(value);
        }

        public ViaListNode<T> SearchNode(T value)
        {
            return _viaList.SearchNode(value);
        }

        public bool SerachFirst(T value)
        {
            return _viaList.SerachFirst(value);
        }

        public void Sort()
        {
            _viaList.Sort();
        }
        private bool IsDecimalType(Type type)
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

        public IEnumerator<T> GetEnumerator()
        {
            return _viaList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
