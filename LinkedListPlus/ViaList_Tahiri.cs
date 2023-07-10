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
        /// <summary>
        /// Listenin uzunluğunu döner.
        /// </summary>
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
        /// <summary>
        /// Kullanıcı istediği kadar öğeyi girerek, listeyi initialize edebilir. 
        /// </summary>
        /// <param name="initial"></param>
        public ViaList(params T[] initial)
        {
            foreach (var item in initial)
            {
                AddLast(item);
            }
        }
        /// <summary>
        /// Stack şeklinde öğe ekler. Son girilen öğeyi başa ekler.
        /// </summary>
        /// <param name="item">İlgili türden nesneyi ifade eder.</param>
        /// <exception cref="ArgumentException">null bir öğe/nesne eklenemez.</exception>
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
        /// <summary>
        /// Queue yapısı olarak çalışır. Son gelen nesneyi/öğeyi sona ekler.
        /// </summary>
        /// <param name="item">İlgili türden nesneyi ifade eder.</param>
        /// <exception cref="ArgumentException">null bir öğe/nesne eklenemez.</exception>
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
        /// <summary>
        /// Belirtilen node'dan sonra, ilgili nesneyi listeye ekler.
        /// </summary>
        /// <param name="node">İlgili öğenin/nesnenin listeye hangi node sonra ekleneceğini belirtir.</param>
        /// <param name="item">İlgili türden nesneyi ifade eder.</param>
        /// <exception cref="ArgumentException">null bir öğe/nesne eklenemez. null olan bir node gönderilemez</exception>
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
        /// <summary>
        /// Belirtilen node'dan sonra belirtilen node ekler.
        /// </summary>
        /// <param name="node">İlgili node'un listeye hangi node sonra ekleneceğini belirtir.</param>
        /// <param name="newNode">Eklenecek olan node.</param>
        /// <exception cref="ArgumentException"></exception>
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
        /// <summary>
        /// Belirtilen nesneyi/öğeyi belirtilen node'dan önce ekler.
        /// </summary>
        /// <param name="node">Hangi node'den önce eklenmesi isteniyorsa o node'u belirtir.</param>
        /// <param name="item">Eklenecek olan nesne/öğe.</param>
        /// <exception cref="ArgumentException"></exception>
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
        /// <summary>
        /// Belirtilen node'u belirtilen node'dan önce ekler.
        /// </summary>
        /// <param name="node">Hangi node'den önce eklenmesi isteniyorsa o node'u belirtir.</param>
        /// <param name="item">Eklenecek olan node.</param>
        /// <exception cref="ArgumentException"></exception>
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
        /// <summary>
        /// IEnumerable sınıfından kalıtım alan tüm koleksiyonları/listeleri/arrayleri tek seferde eklemeyi sağlar.
        /// </summary>
        /// <param name="collection"></param>
        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                AddLast(item);
            }
        }
        /// <summary>
        /// Verilen diziye, belirtilen indexten itibaren, ilgili listeyi kopyalar. Deep copy yapar. 
        /// </summary>
        /// <param name="toCopy">Kopyanın kaydedileceği dizi.</param>
        /// <param name="index">Beliritlen dizinin hangi index değerinden itibaren kopyalama işlemini yapacağını belirten index değeri.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="IndexOutOfRangeException"></exception>
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
        /// <summary>
        /// İlgili diziyi sabit ve tek boyutlu bir arraye kopyalar. Deep copy yapar.
        /// </summary>
        /// <returns>Kopya diziyi döndürür.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="IndexOutOfRangeException"></exception>
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
        /// <summary>
        /// İlgili node listenin içinde var mı kontrol eder.
        /// </summary>
        /// <param name="node"></param>
        /// <returns>İlgli node listede bulunursa true döner.</returns>
        private bool Contains(ViaListNode<T> node)
        {
            var ptr = Head;
            while (ptr != null) { if (ptr == node) { return true; } ptr = ptr.Next; }
            return false;
        }
        /// <summary>
        /// Tüm listeyi siler.s
        /// </summary>
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
