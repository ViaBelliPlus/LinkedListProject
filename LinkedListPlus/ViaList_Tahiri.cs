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

        public ViaList() 
        {
            
        }

        public void AddFirst(T item)
        {
            if (item == null) throw new ArgumentException("Item must not be null");
            ViaListNode<T> newNode = new ViaListNode<T>(item);
            
            if (Head == null & Tail == null)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }

            Head.Back = newNode;
            newNode.Next = Head;
            Head = newNode;
        }
        public void AddLast(T item)
        {
            if (item == null) throw new ArgumentException("Item must not be null");
            ViaListNode<T> newNode = new(item);
            if(Tail == null & Tail == null) { Tail = newNode; Head = newNode; return; }

            Tail.Next = newNode;
            newNode.Back = Tail;
            Tail = newNode;
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
        }
        private bool Contains(ViaListNode<T> node)
        {
            var ptr = Head;
            while (ptr != null) { if (ptr == node) { return true; } ptr = ptr.Next; }
            return false;
        }
    }
}
