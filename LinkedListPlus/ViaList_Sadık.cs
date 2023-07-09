using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
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
            var value = Head.Value; // Değeri dönmek için geçici bir değişkende sakla
            if (Head != null) // Liste boş değilse devam et
            {
                if (Head.Next != null) // Başka bir öğe varsa
                {
                    Head.Next.Back = null; // İkinci öğenin öncesini null yap
                    Head = Head.Next; // Yeni başlangıç değerimizi ikinci öğe olarak güncelle
                }
                else // Sadece bir öğe varsa
                {
                    Head = null; // Listeyi boşalt
                }
                count--;
            }
            return value; // Kaldırılan değeri dön
        }

        public T this[int index]
        {
            
            get
            {
                var value = Head;
                if (count<=index)
                {
                    for (int i = 0; i < index; i++)
                    {
                        value = value.Next;
                    }
                    return value.Value;
                }
                else
                {
                    throw new Exception();
                }
            }
            set
            {
                if (count <= index)
                {
                    var data = Head;
                    for (int i = 0; i < index; i++)
                    {
                        data = data.Next;
                    }
                    data.Value = value;
                }
                else
                {
                    throw new Exception();
                }
                
            }

        }

        public void RemoveAfter(ViaListNode<T> node)
        {
            // Belirtilen düğümden sonraki düğümü kaldırma işlemi
            var delete = node.Next;
            // İlk olarak, düğümün null olup olmadığını kontrol ediyoruz.
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "Düğüm null olamaz.");
            }
            if (node==Head)
            {
                Head.Next = Head.Next.Next;
                Head.Next.Next.Back = Head;
                disconnection(delete);
                count--;
                return;
            }
            if (node==Tail)
            {
                return; //sonrası yok 
            }
            if (node==Tail.Back)
            {
                Tail = Tail.Back;
                disconnection(delete);
                count--;
                return;
            }
            node.Next.Next.Back = node;
            node.Next=node.Next.Next;

            count--;
            return;

        }



        public T RemoveLast()
        {
            if (Tail == null)
            {
                throw new NullReferenceException("Listede eleman bulunmuyor.");
            }

            var value = Tail.Value; // Silinen düğümün değerini saklamak için bir değişkende tutarız

            // Listenin sadece bir düğümü varsa, Head ve Tail'e null atanır
            if (Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail.Back.Next = null; // Sondan bir önceki düğümün sonraki referansını null yaparız
                Tail = Tail.Back; // Yeni tail, bir önceki düğüm olur
            }

            count--;
            return value; // Saklanan değeri döndürürüz
        }


        public void RemoveBefore(ViaListNode<T> node)
        {
            // Belirtilen düğümden sonraki düğümü kaldırma işlemi
            var delete = node.Next;
            // İlk olarak, düğümün null olup olmadığını kontrol ediyoruz.
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "Düğüm null olamaz.");
            }
            if (node == Head)
            {
                Head.Back = Head.Back.Back;
                Head.Back.Back.Next = Head;
                disconnection(delete);
                count--;
                return;
            }
            if (node == Tail)
            {
                return; //sonrası yok 
            }
            if (node == Tail.Next)
            {
                Tail = Tail.Next;
                disconnection(delete);
                count--;
                return;
            }
            node.Back.Back.Next = node;
            node.Back = node.Back.Back;

            count--;
            return;
        }

        public void disconnection(ViaListNode<T> node)
        {
            node.Next = null;
            node.Back = null;
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

        public void RemoveAtValue(T value)
        {
            if (value == null)
            {
                throw new ArgumentException("Item must not be null");
            }
            var respons = SerchNode(value);
            RemoveAt(respons);
            count--;
            
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
