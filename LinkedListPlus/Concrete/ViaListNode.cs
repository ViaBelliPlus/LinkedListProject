using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPlus
{
    public class ViaListNode<T> 
    {
        public ViaListNode(T value)
        {
            Value = value;
        }

        public ViaListNode<T> Next { get; set; }  //sonraki nod
        public ViaListNode<T> Back { get; set; }  //önceki nod

        public T Value { get; set; } //nod değeri

        public override string ToString() => $"{Value}";
        /// <summary>
        /// Node'un referans ettiği diğer node'ları geçersiz kılar.
        /// </summary>
        public void Invalidate()
        {
            Next = null;
            Back = null;
        }
    }
}
