using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPlus
{
    public partial interface IViaList<T>
    {
        public ViaListNode<T> Tail { get; set; }
        public ViaListNode<T> Head { get; set; }
        bool IsComparableTypeList { get; init; }
        bool IsEmpty { get;}
        ViaList<ViaListNode<T>> SearchAll(T value);
        bool SerachFirst(T value);
        void Sort();
        IEnumerator<T> GetEnumerator();
        bool IsComparablelType(Type type);
        void Validate(object? toValidate);
        void Validate(object? toValidate, object? toValidate2);
        void IncreaseCount();
        void DecreaseCount();
        void ResetCount();
        void Add(T item);
    }
}
