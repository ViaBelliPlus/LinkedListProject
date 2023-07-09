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

        public ViaListNode<T> Next { get; set; }
        public ViaListNode<T> Back { get; set; }

        public T Value { get; set; }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
