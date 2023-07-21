using Core.Utilities.Messages;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinkedListPlus
{
    public partial class DefaultList<T> : AbsViaList<T>
    {
        public override bool IsComparableTypeList { get; init; }

        public DefaultList()
        {
            IsComparableTypeList = IsComparablelType(typeof(T));
        }
        /// <summary>
        /// Kullanıcı istediği kadar öğeyi girerek, listeyi initialize edebilir. 
        /// </summary>
        /// <param name="initial"></param>
        public DefaultList(params T[] initial) : this()
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
        public override void AddFirst(T item)
        {
            Validate(item);
            ViaListNode<T> newNode = new ViaListNode<T>(item);

            if (Head == null & Tail == null)
            {
                Head = newNode;
                Tail = newNode;
                IncreaseCount();
            }

            Head.Back = newNode;
            newNode.Next = Head;
            Head = newNode;
            IncreaseCount();
        }
        /// <summary>
        /// Queue yapısı olarak çalışır. Son gelen nesneyi/öğeyi sona ekler.
        /// </summary>
        /// <param name="item">İlgili türden nesneyi ifade eder.</param>
        /// <exception cref="ArgumentException">null bir öğe/nesne eklenemez.</exception>
        public override void AddLast(T item)
        {
            Validate(item);
            ViaListNode<T> newNode = new(item);
            if (Tail == null & Tail == null) { Tail = newNode; Head = newNode; Count++; return; }

            Tail.Next = newNode;
            newNode.Back = Tail;
            Tail = newNode;
            IncreaseCount();
        }
        /// <summary>
        /// Belirtilen node'dan sonra, ilgili nesneyi listeye ekler.
        /// </summary>
        /// <param name="node">İlgili öğenin/nesnenin listeye hangi node sonra ekleneceğini belirtir.</param>
        /// <param name="item">İlgili türden nesneyi ifade eder.</param>
        /// <exception cref="ArgumentException">null bir öğe/nesne eklenemez. null olan bir node gönderilemez</exception>
        public override void AddAfter(ViaListNode<T> node, T item)
        {
            Validate(node, item);
            ViaListNode<T> newNode = new(item);
            if (!Contains(node)) throw new ArgumentException(ErrorMessages.MissingNodeMessage);

            var prev = node;
            prev.Next.Back = newNode;
            newNode.Next = prev.Next;
            prev.Next = newNode;
            newNode.Back = prev;
            IncreaseCount();
        }
        /// <summary>
        /// Belirtilen node'dan sonra belirtilen node ekler.
        /// </summary>
        /// <param name="node">İlgili node'un listeye hangi node sonra ekleneceğini belirtir.</param>
        /// <param name="newNode">Eklenecek olan node.</param>
        /// <exception cref="ArgumentException"></exception>
        public override void AddAfter(ViaListNode<T> node, ViaListNode<T> newNode)
        {
            Validate(node, newNode);
            if (!Contains(node)) throw new ArgumentException(ErrorMessages.MissingNodeMessage);

            var prev = node;
            prev.Next.Back = newNode;
            newNode.Next = prev.Next;
            prev.Next = newNode;
            newNode.Back = prev;
            IncreaseCount();
        }
        /// <summary>
        /// Belirtilen nesneyi/öğeyi belirtilen node'dan önce ekler.
        /// </summary>
        /// <param name="node">Hangi node'den önce eklenmesi isteniyorsa o node'u belirtir.</param>
        /// <param name="item">Eklenecek olan nesne/öğe.</param>
        /// <exception cref="ArgumentException"></exception>
        public override void AddBefore(ViaListNode<T> node, T item)
        {
            Validate(node, item);
            ViaListNode<T> newNode = new(item);
            if (!Contains(node)) throw new ArgumentException(ErrorMessages.MissingNodeMessage);

            var next = node;
            next.Back.Next = newNode;
            newNode.Back = next.Back;
            next.Back = newNode;
            newNode.Next = next;
            IncreaseCount();
        }
        /// <summary>
        /// Belirtilen node'u belirtilen node'dan önce ekler.
        /// </summary>
        /// <param name="node">Hangi node'den önce eklenmesi isteniyorsa o node'u belirtir.</param>
        /// <param name="item">Eklenecek olan node.</param>
        /// <exception cref="ArgumentException"></exception>
        public override void AddBefore(ViaListNode<T> node, ViaListNode<T> newNode)
        {
            Validate(node, newNode);
            if (!Contains(node)) throw new ArgumentException(ErrorMessages.MissingNodeMessage);

            var next = node;
            next.Back.Next = newNode;
            newNode.Back = next.Back;
            next.Back = newNode;
            newNode.Next = next;
            IncreaseCount();
        }

        /// <summary>
        /// IEnumerable sınıfından kalıtım alan tüm koleksiyonları/listeleri/arrayleri tek seferde eklemeyi sağlar.
        /// </summary>
        /// <param name="collection"></param>
        public override void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                AddLast(item);
            }
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
        public override void Sort()
        {
            if (IsComparableTypeList)
            {
                SortedList<T> temp = new SortedList<T>(this);

                Clear();
                
                foreach (var item in temp)
                {
                    AddLast(item);
                }
            }
            else
            {
                throw new ArgumentException(ErrorMessages.NotComparable);
            }
        }
    }
    public enum TypeList
    {
        DefaultList = 0,
        SortedList = 1
    }
}
