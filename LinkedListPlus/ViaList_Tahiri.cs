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
    }
}
