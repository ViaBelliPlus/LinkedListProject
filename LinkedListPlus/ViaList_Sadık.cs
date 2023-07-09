using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPlus
{
    public partial class ViaList<T> : IEnumerable<T>
    {
        public ViaList(IEnumerable<T> collection)
        {
            //ilk tanımlanma ısrasında hazır bir listeyi bu listeye ekleme işlemini yapar
            foreach (var item in collection)
            {
                this.AddFirst(item);
                throw new NotImplementedException();
            }
            ArrayList a = new();

        }

        public T RemoveFirst()
        {
            var value = Head.Value; //degeri dönmek için tutuk
            Head.Next.Back = null; // []->[]  2. degerın öncesini null yaptık 
            Head = Head.Next; //yeni başlangiç değerimiz bir sonraki
            count--;
            return value;
        }

        public void RemoveFirst(ViaListNode<T> node)// []->[]->[]
        {
            if (node == null)
            {
                throw new ArgumentException("Item must not be null");
            }
            if (Head == null)
            {
                throw new NullReferenceException();
            }
            if (Head == Tail)
            {
                throw new Exception("diniz yeterli büyüklikte değil");
            }
            if (Head == node)
            {
                throw new Exception("Baş kısımın sonrası yok tur");
            }
            else if (Tail == node)
            {
                Tail = Tail.Next;
                Tail.Back = null;
                count--;
                return;
            }
            else if(node.Next.Next==null)
            {
                throw new ArgumentNullException();
            }
            node.Next = node.Next.Next;
            node.Next.Next.Back = node.Next;
            count--;
            return;
        }

        public T RemoveLast()
        {
            var value = Tail.Value;//degeri dönmek için tutuk
            Tail.Back.Next = null;// []<-[] sondan 1 öncekinin sonrasını null yaptık 
            Tail = Tail.Back; //yeni tail bi önceki yapıldı
            count--;
            return value;
        }

        public void RemoveLast(ViaListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentException("Item must not be null");
            }
            if (Head == null)
            {
                throw new NullReferenceException();
            }
            if (Head == Tail)
            {
                throw new Exception("diniz yeterli büyüklikte değil");
            }
            if (Head == node)
            {
                Head = Head.Back;
                Head.Next = null;
            }
            else if (Tail == node)
            {
                throw new Exception("Baş kısımın öncesi yok tur");
            }else if (node.Back.Back==null)
            {
                throw new ArgumentNullException();
            }
            node.Back = node.Back.Back;
            node.Back.Back.Next = node.Back;
            count--;
            return;
        }

        public ViaListNode<T> RemoveAt(T value)
        {
            if (value == null)
            {
                throw new ArgumentException("Item must not be null");
            }
            var respons = SerchNode(value);
            count--;
            return respons;
        }

        public void RemoveAt(ViaListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentException("Item must not be null");
            }
            if (node == Head && node == Tail)
            {
                Head = null;
            }
            if (node == Head)
            {
                Head = Head.Next;
                Head.Back = null;
                count--;
                return;
            }
            if (node == Tail)
            {
                Tail = Tail.Back;
                Tail.Next = null;
                count--;
                return;
            }

            node.Back = node.Next;
            node.Next = node.Back;
            count--;
            return;
        }

        public T RemoveAtValue(T value)
        {
            if (value == null)
            {
                throw new ArgumentException("Item must not be null");
            }
            var respons = SerchNode(value);
            count--;
            return respons.Value;
        }

        public ViaListNode<T> SerchNode(T value)
        {
            if (value == null)
            {
                throw new ArgumentException("Item must not be null");
            }

            var _current = Head;
            while (_current != null)
            {
                if (_current.Value.Equals(value))
                {
                    return _current;
                }
                _current = _current.Next;
            }
            throw new Exception();
        }

        public bool Serch(T value) => SerchNode(value) != null ? true : false;

        public IEnumerator<T> GetEnumerator()
        {
            return new ViaListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
