using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            return value;
        }
        public T RemoveLast()
        {
            var value = Tail.Value;//degeri dönmek için tutuk
            Tail.Back.Next = null;// []<-[] sondan 1 öncekinin sonrasını null yaptık 
            Tail = Tail.Back; //yeni tail bi önceki yapıldı
            return value;
        }

        public ViaListNode<T> RemoveAt(T value)
        {
            if (value == null)
            {
                throw new ArgumentException("Item must not be null");
            }
            var respons = SerchNode(value);

            return respons;
        }
        public T RemoveAtValue(T value)
        {
            if (value == null)
            {
                throw new ArgumentException("Item must not be null");
            }
            var respons = SerchNode(value);

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
