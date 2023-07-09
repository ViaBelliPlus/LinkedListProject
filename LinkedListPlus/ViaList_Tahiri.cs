using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPlus
{
    public partial class ViaList<T>
    {
        public ViaListNode<T> Head { get; set; } //Baş
        public ViaListNode<T> Tail { get; set; } //Kuyruk
        public uint Count { 
            get 
            {
                /*
                #region Control O(n)
                if (Head == null && Tail == null) return 0;
                var ptr = Head;
                uint count = 0;
                while (ptr != null) { ptr = ptr.Next; count++; }
                return count;
                #endregion
                */
                return count;
            }
            private set { count = value; }
        }
        private uint count;

        public ViaList() 
        {
            
        }
        public ViaList(params T[] initial)
        {
            foreach (var item in initial)
            {
                AddLast(item);
            }
        }
        public void AddFirst(T item)
        {
            if (item == null) throw new ArgumentException("Item must not be null");
            ViaListNode<T> newNode = new ViaListNode<T>(item);
            
            if (Head == null & Tail == null)
            {
                Head = newNode;
                Tail = newNode;
                Count++;
                return;
            }

            Head.Back = newNode;
            newNode.Next = Head;
            Head = newNode;
            Count++;
        }
        public void AddLast(T item)
        {
            if (item == null) throw new ArgumentException("Item must not be null");
            ViaListNode<T> newNode = new(item);
            if(Tail == null & Tail == null) { Tail = newNode; Head = newNode; Count++; return; }

            Tail.Next = newNode;
            newNode.Back = Tail;
            Tail = newNode;
            Count++;
        }
        public void AddAfter(ViaListNode<T> node,T item)
        {
            if (node == null || item == null) throw new ArgumentException("Item or node are empty! They are must not be null!");
            ViaListNode<T> newNode = new(item);
            if (!Contains(node)) throw new ArgumentException("The referance node is not in list");

            var prev = node;
            prev.Next.Back = newNode;
            newNode.Next = prev.Next;
            prev.Next = newNode;
            newNode.Back = prev;
            Count++;
        }
        public void AddAfter(ViaListNode<T> node, ViaListNode<T> newNode)
        {
            if (node == null || newNode == null) throw new ArgumentException("NewNode or node are empty! They are must not be null!");
            if (!Contains(node)) throw new ArgumentException("The referance node is not in list");

            var prev = node;
            prev.Next.Back = newNode;
            newNode.Next = prev.Next;
            prev.Next = newNode;
            newNode.Back = prev;
            Count++;
        }
        public void AddBefore(ViaListNode<T> node, T item)
        {
            if (node == null || item == null) throw new ArgumentException("Item or node are empty! They are must not be null!");
            ViaListNode<T> newNode = new(item);
            if (!Contains(node)) throw new ArgumentException("The referance node is not in list");

            var next = node;
            next.Back.Next = newNode;
            newNode.Back = next.Back;
            next.Back = newNode;
            newNode.Next = next;
            Count++;
        }
        public void AddBefore(ViaListNode<T> node, ViaListNode<T> newNode)
        {
            if (node == null || newNode == null) throw new ArgumentException("NewNode or node are empty! They are must not be null!");
            if (!Contains(node)) throw new ArgumentException("The referance node is not in list");

            var next = node;
            next.Back.Next = newNode;
            newNode.Back = next.Back;
            next.Back = newNode;
            newNode.Next = next;
            Count++;
        }
        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                AddLast(item);
            }
        }
        public T[] CopyTo(T[] toCopy, int index)
        {
            if (toCopy == null) throw new ArgumentNullException("The referance array must not be empty!");
            if (Head == null) throw new ArgumentNullException("The current list is empty!");
            if (Count > toCopy.Length - index) throw new ArgumentException("There is not enough space in the specified array");
            var ptr = Head;
            for (int i = index; ptr != null; i++)
            {
                try
                {
                    toCopy[i] = ptr.Value; ptr = ptr.Next;
                }
                catch (Exception)
                {
                    throw new IndexOutOfRangeException();
                }
            }
            return toCopy;
        }
        public T[] CopyToOneDimensionalArray()
        {
            if (Head == null) throw new ArgumentNullException("The current list is empty!");
            var ptr = Head;
            T[] tempArray = new T[Count];
            for (int i = 0; i < tempArray.Length; i++)
            {
                try
                {
                    tempArray[i] = ptr.Value; ptr = ptr.Next;
                }
                catch (Exception)
                {
                    throw new IndexOutOfRangeException();
                }
            }
            return tempArray;
        }
        private bool Contains(ViaListNode<T> node)
        {
            var ptr = Head;
            while (ptr != null) { if (ptr == node) { return true; } ptr = ptr.Next; }
            return false;
        }
        public void Clear()
        {
            ViaListNode<T> currentHead = Head;
            ViaListNode<T> currentTail = Tail;
            while (currentHead != currentTail && (currentHead != null && currentTail != null)) 
            {
                ViaListNode<T> tempHead = currentHead;
                ViaListNode<T> tempTail = currentTail;
                currentHead = currentHead.Next;
                currentTail = currentTail.Back;
                tempHead.Invalidate();
                tempTail.Invalidate();
            }
            currentHead?.Invalidate();
            Head = null;
            Tail = null;
            Count = 0;
        }
    }
}
